using HA.Auth.ApplicationService.Common;
using HA.Auth.ApplicationService.UserModule.Abstract;
using HA.Auth.Domain;
using HA.Auth.Dtos.Sale;
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
    public class SaleService : AuthServiceBase, ISaleService
    {
        private readonly ILogger<SaleService> _logger;
        private readonly BasethDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public SaleService(ILogger<SaleService> logger, BasethDbContext dbContext, IConfiguration configuration) : base(logger, dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public SaleDto CreatenewSale(CreateSaleDto input)
        {
            var sale = new AuthSale
            {
                SaleName = input.SaleName,
                Password = input.Password,
                SaleDes = input.SaleDes
            };
            _dbContext.Sales.Add(sale);
            _dbContext.SaveChanges();
            return new SaleDto
            {
                Id = sale.Id,
                SaleName = sale.SaleName,
                SaleDes = sale.SaleDes
            };
        }

        public void DeleteSale(int id)
        {
            var sale = _dbContext.Sales.FirstOrDefault(c => c.Id == id);
            if (sale == null)
                throw new KeyNotFoundException("Category not found");

            _dbContext.Sales.Remove(sale);
            _dbContext.SaveChanges();
        }

        public List<SaleDto> GetAllSale()
        {
            return _dbContext.Sales.Select(c => new SaleDto
            {
                Id = c.Id,
                SaleName = c.SaleName,
                SaleDes = c.SaleDes,
            }).ToList();
        }

        public SaleDto GetSaleById(int id)
        {
            var sale = _dbContext.Sales.FirstOrDefault(c => c.Id == id);
            if (sale == null)
                throw new KeyNotFoundException("Category not found");

            return new SaleDto
            {
                Id = sale.Id,
                SaleName = sale.SaleName,
                SaleDes = sale.SaleDes,
            };
        }

        public void UpdateSale(UpdateSaleDto input)
        {
            var sale = _dbContext.Sales.FirstOrDefault(c => c.Id == input.Id);
            if (sale == null)
                throw new KeyNotFoundException("Category not found");

            sale.SaleName = sale.SaleName;
            sale.Password = input.Password;
            sale.SaleDes = input.SaleDes;

            _dbContext.SaveChanges();
        }
    }
}
