using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HA.Auth.ApplicationService.UserModule.Implements
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;
        private readonly CheckUser _checkUser;

        public AuthService(IConfiguration configuration, CheckUser checkUser)
        {
            _configuration = configuration;
            _checkUser = checkUser;
        }

        public string GenerateJwtToken(string username, string password)
        {
            var token = _checkUser.AuthenticateUser(username, password); 

            if (string.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            return token;
        }
    }
}
