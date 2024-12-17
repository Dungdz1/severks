using HA.Auth.ApplicationService.Common;
using HA.Auth.ApplicationService.UserModule.Abstract;
using HA.Auth.Domain;
using HA.Auth.Infrastructure;
using HA.Shared.ApplicationService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.ApplicationService.UserModule.Implements
{
    public class UserPermissionService : AuthServiceBase, IUserPermission
    {
        private readonly ILogger<UserPermissionService> _logger;
        private readonly BasethDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public UserPermissionService(ILogger<UserPermissionService> logger, BasethDbContext dbContext, IConfiguration configuration) : base(logger, dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _configuration = configuration;
        }


        //public void GrandPermission(GrandPermission input)
        //{
        //foreach (var userId in input.UserIds)
        //{
        //var userFind = _dbContext.UserPermissions.FirstOrDefault(s => s.UserId == userId && s.PermissionId == input.PermissionId);
        //if (userFind != null)
        //{
        //continue;
        //}

        //_dbContext.UserRoles.Add(
        //new AuthUserRoles
        //{
        //UserId = userId,
        //RoleId = input.PermissionId
        //}
        //);
        //{

        //}
        //}
        //}
    }
}
