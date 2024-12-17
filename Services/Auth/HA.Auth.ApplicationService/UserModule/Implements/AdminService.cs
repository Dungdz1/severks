using HA.Auth.ApplicationService.Common;
using HA.Auth.ApplicationService.UserModule.Abstract;
using HA.Auth.Domain;
using HA.Auth.Dtos.Address;
using HA.Auth.Dtos.Admins;
using HA.Auth.Dtos.UserModule;
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
    public class AdminService : AuthServiceBase, IAdminService
    {
        private readonly ILogger<AdminService> _logger;
        private readonly BasethDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public AdminService(ILogger<AdminService> logger, BasethDbContext dbContext, IConfiguration configuration) : base(logger, dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public AdminDto CreatenewAdmin(CreateAdminDto input)
        {
            var add = new AuthAdmin
            {
                AdminName = input.AdminName,
                AdminPassword = input.AdminPassword,
            };
            _dbContext.Admins.Add(add);
            _dbContext.SaveChanges();
            return new AdminDto
            {
                Id = add.Id,
                AdminName = add.AdminName,
                AdminPassword = add.AdminPassword,
            };
        }

        public void DeleteAdmin(int id)
        {
            var add = _dbContext.Admins.FirstOrDefault(c => c.Id == id);
            if (add == null)
                throw new KeyNotFoundException("Address not found");

            _dbContext.Admins.Remove(add);
            _dbContext.SaveChanges();
        }

        public void UpdateAdmin(UpdateAdmin input)
        {
            var add = _dbContext.Admins.FirstOrDefault(c => c.Id == input.Id);
            if (add == null)
                throw new KeyNotFoundException("Category not found");
            add.AdminPassword = input.AdminPassword;
            _dbContext.SaveChanges();
        }
    }
}
