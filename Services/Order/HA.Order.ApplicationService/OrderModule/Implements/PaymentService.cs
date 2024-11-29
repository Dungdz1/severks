using HA.Order.ApplicationService.Common;
using HA.Order.ApplicationService.OrderModule.Abstract;
using HA.Order.Domain;
using HA.Order.Dtos;
using HA.Order.Dtos.OrderPayment;
using HA.Order.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.ApplicationService.OrderModule.Implements
{
    public class PaymentService : OrderServiceBase, IPaymentService
    {
        private readonly ILogger<PaymentService> _logger;
        private readonly OrderDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public PaymentService(ILogger<PaymentService> logger, OrderDbContext dbContext, IConfiguration configuration) : base(logger, dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public PaymentDto CreatePayment(CreatePaymentDto input)
        {
            var pay = new OdPayment
            {
                PaymentMethod = input.PaymentMethod,
                Amount = input.Amount,
                PaymentDate = input.PaymentDate,
                Status = input.Status,
                TransactionCode = input.TransactionCode,
            };
            _dbContext.Payments.Add(pay);
            _dbContext.SaveChanges();
            return new PaymentDto
            {
                PaymentMethod = pay.PaymentMethod,
                Amount = pay.Amount,
                PaymentDate = pay.PaymentDate,
                Status = pay.Status,
                TransactionCode = pay.TransactionCode,
            };
        }

        public void DeletePayment(int id)
        {
            var pay = _dbContext.Payments.FirstOrDefault(c => c.Id == id);
            if (pay == null)
                throw new KeyNotFoundException("Payment not found");

            _dbContext.Payments.Remove(pay);
            _dbContext.SaveChanges();
        }

        public List<PaymentDto> GetAllPayment()
        {
            return _dbContext.Payments.Select(c => new PaymentDto
            {
                Id = c.Id,
                Amount = c.Amount,
                Status = c.Status,
                TransactionCode = c.TransactionCode,
                PaymentMethod = c.PaymentMethod,
                PaymentDate = c.PaymentDate,
            }).ToList();
        }

        public PaymentDto GetPaymentById(int id)
        {
            var pay = _dbContext.Payments.FirstOrDefault(c => c.Id == id);
            if (pay == null)
                throw new KeyNotFoundException("Payment not found");

            return new PaymentDto
            {
                Id = pay.Id,
                Amount = pay.Amount,
                Status = pay.Status,
                TransactionCode = pay.TransactionCode,
                PaymentMethod = pay.PaymentMethod,
                PaymentDate = pay.PaymentDate,
            };
        }

        public void UpdatePayment(UpdatePaymentDto input)
        {
            var pay = _dbContext.Payments.FirstOrDefault(c => c.Id == input.Id);
            if (pay == null)
                throw new KeyNotFoundException("Payment not found");
            pay.PaymentMethod = input.PaymentMethod;
            pay.PaymentDate = input.PaymentDate;
            pay.Status = input.Status;
            pay.TransactionCode = input.TransactionCode;
        }
    }
}
