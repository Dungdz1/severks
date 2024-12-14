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
        private ILogger<UserPermissionService> logger;
        private Infrastructure.BasethDbContext dbContext;
        private ILogger<UserService> logger1;
        private ILogger<UserRoleService> logger2;

        protected AuthServiceBase(ILogger logger, BasethDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        protected AuthServiceBase(ILogger<UserPermissionService> logger, Infrastructure.BasethDbContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        protected AuthServiceBase(ILogger<UserService> logger1, Infrastructure.BasethDbContext dbContext)
        {
            this.logger1 = logger1;
            this.dbContext = dbContext;
        }

        protected AuthServiceBase(ILogger<UserRoleService> logger2, Infrastructure.BasethDbContext dbContext)
        {
            this.logger2 = logger2;
            this.dbContext = dbContext;
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
