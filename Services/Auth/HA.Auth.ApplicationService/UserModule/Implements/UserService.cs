using HA.Auth.ApplicationService.Common;
using HA.Auth.ApplicationService.UserModule.Abstract;
using HA.Auth.Domain;
using HA.Auth.Dtos.Address;
using HA.Auth.Dtos.Logg;
using HA.Auth.Dtos.UserModule;
using HA.Auth.Infrastructure;
using HA.Shared.ApplicationService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.ApplicationService.UserModule.Implements
{
    public class UserService : AuthServiceBase, IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly BasethDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public UserService(ILogger<UserService> logger, BasethDbContext dbContext, IConfiguration configuration) : base(logger, dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public UserDto CreateNewUser(CreateUserDto input)
        {
            var user = new AuthUser
            {
                UserName = input.UserName,
                Password = input.Password,
                PhoneNumber = input.PhoneNumber,
                CreatedDate = DateTime.UtcNow,
            };
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            _logger.LogInformation($"User {input.UserName} created successfully.");

            return new UserDto
            {
                UserName = user.UserName,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                CreatedDate = DateTime.UtcNow,
            };
        }

        public void DeleteUser(int id)
        {
            var userFind = FindUserById(id);
            _dbContext.Users.Remove(userFind);
            _dbContext.SaveChanges();
        }

        public List<AuthUser> GetAll()
        {
            var result = _dbContext.Users.Select(s => new AuthUser
            {
                Id = s.Id,
                UserName = s.UserName,
                PhoneNumber = s.PhoneNumber,
            });

            return result.ToList();
        }

        public void UpdateUser(UpdateUserDto input)
        {
            var userFind = FindUserById(input.Id);
            userFind.UserName = input.UserName;
            userFind.Password = input.Password;
            userFind.PhoneNumber = input.PhoneNumber;
            userFind.CreatedDate = DateTime.UtcNow;

            _dbContext.SaveChanges();
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto input)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == input.UserName && u.Password == input.Password);
            if (user == null)
            {
                _logger.LogWarning("Login failed: Invalid credentials.");
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            var token = GenerateJwtToken(user);

            _logger.LogInformation($"User {user.UserName} logged in successfully.");
            return new LoginResponseDto
            {
                UserId = user.Id,
                UserName = user.UserName,
                Token = token,
                Expiration = DateTime.UtcNow.AddHours(1)
            };
        }

        private string GenerateJwtToken(AuthUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public void AddAddressToUser(AddressUser input)
        {
            foreach (var addressId in input.AddressIds)
            {
                var addressFind = _dbContext.AddressesUsers.FirstOrDefault(s =>
                s.AddressId == addressId && s.CustomerId == input.CustomerId);

                if (addressFind != null)
                {
                    continue;
                }
                _dbContext.AddressesUsers.Add(
                    new AuthAddressUser
                    {
                        AddressId = addressId,
                        CustomerId = input.CustomerId,
                    });
                _dbContext.SaveChanges();
            }
        }
    }
}
