using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HA.Order.Dtos.OrderDiscount;
using HA.Order.Dtos;
using HA.Order.ApplicationService.Common;
using System.Collections.Specialized;
using HA.Order.ApplicationService.OrderModule.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using HA.Order.Infrastructure;
using HA.Order.Domain;
using HA.Shared.ApplicationService;

namespace HA.Order.ApplicationService.OrderModule.Implements
{
    public class DiscountService : OrderServiceBase, IDiscountService
    {
        private readonly ILogger<DiscountService> _logger;
        private readonly BasethDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public DiscountService(ILogger<DiscountService> logger, BasethDbContext dbContext, IConfiguration configuration) : base(logger, dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public DiscountDto CreateNewDiscount(CreateDiscountDto input)
        {
            var discount = new OdDiscount
            {
                CodeDiscount = input.CodeDiscount,
                DiscountValue = input.DiscountValue,
                StartDate = input.StartDate,
                EndDate = input.EndDate,
                DiscountDescription = input.DiscountDescription,
                Status = input.Status,
            };
            _dbContext.Discounts.Add(discount);
            _dbContext.SaveChanges();
            return new DiscountDto
            {
                Id = discount.Id,
                CodeDiscount = discount.CodeDiscount,
                DiscountValue = discount.DiscountValue,
                StartDate = discount.StartDate,
                EndDate = discount.EndDate,
                DiscountDescription = discount.DiscountDescription,
                Status = discount.Status,
            };
        }

        public void DeleteDiscount(int id)
        {
            var discount = _dbContext.Discounts.FirstOrDefault(c => c.Id == id);
            if (discount == null)
                throw new KeyNotFoundException("Discount not found");

            _dbContext.Discounts.Remove(discount);
            _dbContext.SaveChanges();
        }

        public List<DiscountDto> GetAllDiscount()
        {
            return _dbContext.Discounts.Select(c => new DiscountDto
            {
                Id = c.Id,
                CodeDiscount = c.CodeDiscount,
                DiscountDescription = c.DiscountDescription,
                Status = c.Status,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                DiscountValue = c.DiscountValue,
            }).ToList();
        }

        public DiscountDto GetDiscountById(int id)
        {
            var discount = _dbContext.Discounts.FirstOrDefault(c => c.Id == id);
            if (discount == null)
                throw new KeyNotFoundException("Discount not found");

            return new DiscountDto
            {
                Id = discount.Id,
                CodeDiscount = discount.CodeDiscount,
                StartDate = discount.StartDate,
                EndDate = discount.EndDate,
                DiscountValue = discount.DiscountValue,
                DiscountDescription = discount.DiscountDescription,
                Status = discount.Status
            };
        }

        public void UpdateDiscount(UpdateDiscountDto input)
        {
            var discount = _dbContext.Discounts.FirstOrDefault(c => c.Id == input.Id);
            if (discount == null)
                throw new KeyNotFoundException("Discount not found");
            discount.CodeDiscount = input.CodeDiscount;
            discount.DiscountValue = input.DiscountValue;
            discount.StartDate = input.StartDate;
            discount.EndDate = input.EndDate;
            discount.Status = input.Status;
            discount.DiscountDescription = input.DiscountDescription;

            _dbContext.SaveChanges();
        }
    }
}
