using HA.Auth.ApplicationService.Common;
using HA.Auth.ApplicationService.UserModule.Abstract;
using HA.Auth.Domain;
using HA.Auth.Dtos.Address;
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
    public class AddressService : AuthServiceBase, IAddressService
    {
        private readonly ILogger<AddressService> _logger;
        private readonly BasethDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public AddressService(ILogger<AddressService> logger, BasethDbContext dbContext, IConfiguration configuration) : base(logger, dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public AddressDto CreateNewAddress(CreateAddressDto input)
        {
            var add = new AuthAddress
            {
                FullAddress = input.FullAddress,
                State = input.State,
                City = input.City,
            };
            _dbContext.Addresses.Add(add);
            _dbContext.SaveChanges();
            return new AddressDto
            {
                Id = add.Id,
                FullAddress = add.FullAddress,
                State = add.State,
                City = add.City,
            };
        }

        public void DeleteAddress(int id)
        {
            var add = _dbContext.Addresses.FirstOrDefault(c => c.Id == id);
            if (add == null)
                throw new KeyNotFoundException("Address not found");

            _dbContext.Addresses.Remove(add);
            _dbContext.SaveChanges();
        }

        public AddressDto GetAddressById(int id)
        {
            var add = _dbContext.Addresses.FirstOrDefault(c => c.Id == id);
            if (add == null)
                throw new KeyNotFoundException("Address not found");

            return new AddressDto
            {
                Id = add.Id,
                FullAddress = add.FullAddress,
                State = add.State,
                City = add.City,
            };
        }

        public List<AddressDto> GetAllAddress()
        {
            return _dbContext.Addresses.Select(c => new AddressDto
            {
                Id = c.Id,
                FullAddress = c.FullAddress,
                State = c.State,
                City = c.City,
            }).ToList();
        }

        public void UpdateAddress(UpdateAddressDto input)
        {
            var add = _dbContext.Addresses.FirstOrDefault(c => c.Id == input.Id);
            if (add == null)
                throw new KeyNotFoundException("Category not found");
            add.FullAddress = input.FullAddress;
            add.State = input.State;
            add.City = input.City;

            _dbContext.SaveChanges();
        }
    }
}
