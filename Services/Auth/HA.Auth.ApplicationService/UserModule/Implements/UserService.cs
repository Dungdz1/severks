using HA.Auth.ApplicationService.Common;
using HA.Auth.ApplicationService.UserModule.Abstract;
using HA.Auth.Domain;
using HA.Auth.Dtos.UserModule;
using HA.Auth.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.ApplicationService.UserModule.Implements
{
    public class UserService : AuthServiceBase, IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly AuthDbContext _dbContext;
        public UserService(ILogger<UserService> logger, AuthDbContext dbContext) : base(logger, dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<AuthUser> CreateUserAsync(CreateUserDto input)
        {
            var user = new AuthUser
            {
                UserName = input.UserName,
                Password = input.Password,
                PhoneNumber = input.PhoneNumber,
                Address = input.Address,
                CreatedDate = DateTime.UtcNow,
            };
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"User {input.UserName} created successfully.");

            return new AuthUser
            {
                UserName = user.UserName,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
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
                Address = s.Address
            });

            return result.ToList();
        }

        public void UpdateUser(UpdateUserDto input)
        {
            var userFind = FindUserById(input.Id);
            userFind.UserName = input.UserName;
            userFind.Password = input.Password;
            userFind.PhoneNumber = input.PhoneNumber;
            userFind.Address = input.Address;
            userFind.CreatedDate = DateTime.UtcNow;

            _dbContext.SaveChanges();
        }
    }
}
