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
    public class UserRoleService : AuthServiceBase, IUserRole
    {
        public UserRoleService(ILogger<UserRoleService> logger, AuthDbContext dbContext) : base(logger, dbContext)
        {
        }


        public void GrandRole(GrandRole input)
        {
            foreach (var userId in input.UserIdss)
            {
                var userFind = _dbContext.UserRoles.FirstOrDefault(s => s.UserId == userId && s.RoleId == input.RoleId);
                if (userFind != null)
                {
                    continue;
                }

                _dbContext.UserRoles.Add(
                    new AuthUserRoles
                    {
                        UserId = userId,
                        RoleId = input.RoleId
                    }
                    );
                {
                    
                }
            }
        }
    }
}
