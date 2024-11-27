using HA.Product.ApplicationService.Common;
using HA.Product.ApplicationService.ProductModule.Abstracts;
using HA.Product.Domain;
using HA.Product.Dtos.ProductModule;
using HA.Product.Dtos.ProductModule.Brand;
using HA.Product.Dtos.ProductModule.Sale;
using HA.Product.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.ApplicationService.ProductModule.Implement
{
    public class SaleService : ProductServiceBase, ISaleService
    {
        private readonly ILogger<SaleService> _logger;
        private readonly ProductDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public SaleService(ILogger<SaleService> logger, ProductDbContext dbContext, IConfiguration configuration) : base(logger, dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public SaleDto CreatenewSale(CreateSaleDto input)
        {
            var sale = new ProdSale
            {
                DiscountPersent = input.DiscountPersent,
                StartDate = input.StartDate,
                EndDate = input.EndDate,
                SaleDescriptioon = input.SaleDescriptioon,
            };
            _dbContext.Sales.Add(sale);
            _dbContext.SaveChanges();
            return new SaleDto
            {
                Id = sale.Id,
                DiscountPersent = sale.DiscountPersent,
                StartDate = sale.StartDate,
                EndDate = sale.EndDate,
                SaleDescriptioon = sale.SaleDescriptioon
            };
        }

        public void DeleteSale(int id)
        {
            var sale = _dbContext.Sales.FirstOrDefault(c => c.Id == id);
            if (sale == null)
                throw new KeyNotFoundException("Sale not found");

            _dbContext.Sales.Remove(sale);
            _dbContext.SaveChanges();
        }

        public List<SaleDto> GetAllSale()
        {
            return _dbContext.Sales.Select(c => new SaleDto
            {
                Id = c.Id,
                DiscountPersent = c.DiscountPersent,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                SaleDescriptioon = c.SaleDescriptioon,
            }).ToList();
        }

        public SaleDto GetSaleById(int id)
        {
            var sale = _dbContext.Sales.FirstOrDefault(c => c.Id == id);
            if (sale == null)
                throw new KeyNotFoundException("Sale not found");

            return new SaleDto
            {
                Id = sale.Id,
                DiscountPersent = sale.DiscountPersent,
                StartDate = sale.StartDate,
                EndDate = sale.EndDate,
                SaleDescriptioon = sale.SaleDescriptioon,
            };
        }

        public void UpdateSale(UpdateSaleDto input)
        {
            var sale = _dbContext.Sales.FirstOrDefault(c => c.Id == input.Id);
            if (sale == null)
                throw new KeyNotFoundException("Sale not found");

            sale.DiscountPersent = input.DiscountPersent;
            sale.StartDate = input.StartDate;
            sale.EndDate = input.EndDate;
            sale.SaleDescriptioon = input.SaleDescriptioon;

            _dbContext.SaveChanges();
        }
    }
}
