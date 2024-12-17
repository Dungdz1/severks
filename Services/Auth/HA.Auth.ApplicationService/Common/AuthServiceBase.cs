using HA.Auth.ApplicationService.UserModule.Implements;
using HA.Auth.Domain;
using HA.Shared.ApplicationService;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.ApplicationService.Common
{
    public abstract class AuthServiceBase
    {
        protected readonly ILogger _logger;
        protected readonly BasethDbContext _dbContext;

        protected AuthServiceBase(ILogger logger, BasethDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        protected AuthUser FindUserById(int userId)
        {
            var userFind = _dbContext.Users.FirstOrDefault(s => s.Id == userId && !s.IsDelete);
            if (userFind == null)
            {
                _logger.LogInformation($"Khong tim thay nguoi dung {userId}");
            }

            return userFind;
        }
    }
}
