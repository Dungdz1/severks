using HA.Auth.ApplicationService.Common;
using HA.Auth.ApplicationService.UserModule.Abstract;
using HA.Auth.Domain;
using HA.Auth.Dtos.Customer;
using HA.Auth.Dtos.Sale;
using HA.Auth.Dtos.UserModule;
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
    public class CustomerService : AuthServiceBase, ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly Shared.ApplicationService.BasethDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public CustomerService(ILogger<CustomerService> logger, Shared.ApplicationService.BasethDbContext dbContext, IConfiguration configuration) : base(logger, dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public CustomerDto CreatenewCustomer(CreateCustomerDto input)
        {
            var cus = new AuthCustomer
            {
                CustomerName = input.CustomerName,
                Password = input.Password,
            };
            _dbContext.Customers.Add(cus);
            _dbContext.SaveChanges();
            return new CustomerDto
            {
                Id = cus.Id,
                CustomerName = cus.CustomerName,
                Password = cus.Password,
            };
        }

        public void DeleteCustomer(int id)
        {
            var cus = _dbContext.Customers.FirstOrDefault(c => c.Id == id);
            if (cus == null)
                throw new KeyNotFoundException("Customer not found");

            _dbContext.Customers.Remove(cus);
            _dbContext.SaveChanges();
        }

        public List<CustomerDto> GetAllCustomer()
        {
            return _dbContext.Customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                CustomerName = c.CustomerName,
            }).ToList();
        }

        public CustomerDto GetCustomerById(int id)
        {
            var cus = _dbContext.Customers.FirstOrDefault(c => c.Id == id);
            if (cus == null)
                throw new KeyNotFoundException("Category not found");

            return new CustomerDto
            {
                Id = cus.Id,
                CustomerName = cus.CustomerName,
            };
        }

        public void UpdateCustomer(UpdateCustomerDto input)
        {
            var cus = _dbContext.Customers.FirstOrDefault(c => c.Id == input.Id);
            if (cus == null)
                throw new KeyNotFoundException("Category not found");

            cus.CustomerName = cus.CustomerName;
            cus.Password = input.Password;

            _dbContext.SaveChanges();
        }
    }
}
