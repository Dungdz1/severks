using HA.Auth.ApplicationService.Common;
using HA.Auth.ApplicationService.UserModule.Abstract;
using HA.Auth.Domain;
using HA.Auth.Infrastructure;
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
        public UserPermissionService(ILogger<UserPermissionService> logger, AuthDbContext dbContext) : base(logger, dbContext)
        {
        }


        public void GrandPermission(GrandPermission input)
        {
            foreach (var userId in input.UserIds)
            {
                var userFind = _dbContext.UserPermissions.FirstOrDefault(s => s.UserId == userId && s.PermissionId == input.PermissionId);
                if (userFind != null)
                {
                    continue;
                }

                _dbContext.UserRoles.Add(
                    new AuthUserRoles
                    {
                        UserId = userId,
                        RoleId = input.PermissionId
                    }
                    );
                {

                }
            }
        }
    }
}
