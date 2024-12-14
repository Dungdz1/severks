using HA.Order.ApplicationService.Common;
using HA.Order.ApplicationService.OrderModule.Abstract;
using HA.Order.Domain;
using HA.Order.Dtos;
using HA.Order.Dtos.Delivery;
using HA.Order.Dtos.OrderDiscount;
using HA.Order.Dtos.OrderPayment;
using HA.Order.Dtos.ProductOrder;
using HA.Order.Dtos.UserOrder;
using HA.Order.Infrastructure;
using HA.Product.Domain;
using HA.Product.Dtos.ProductModule;
using HA.Product.Dtos.ProductModule.Cart;
using HA.Shared.ApplicationService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.ApplicationService.OrderModule.Implements
{
    public class OrderService : OrderServiceBase, IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly BasethDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public OrderService(ILogger<OrderService> logger, BasethDbContext dbContext, IConfiguration configuration) : base(logger, dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public OrderDto CreatenewOrder(CreateOrderDto input)
        {
            var order = new OdOrder
            {
                OrderDate = input.OrderDate,
                Status = input.Status,
            };
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return new OrderDto
            {
                Id = order.Id,
                Status = order.Status,
            };
        }

        public void DeleteOrder(int id)
        {
            var orderFind = FindOrderById(id);
            _dbContext.Orders.Remove(orderFind);
            _dbContext.SaveChanges();
        }

        public List<OrderDto> GetOrders()
        {
            var result = _dbContext.Orders.Select(s => new OrderDto
            {
                Id = s.Id,
                Status = s.Status,
                OrderDate = s.OrderDate,
                TotalAmount = s.TotalAmount,
            });
            return result.ToList();
        }

        public void UpdateOrder(UpdateOrderDto input)
        {
            var orderFind = FindOrderById(input.Id);
            orderFind.OrderDate = input.OrderDate;
            orderFind.Status = input.Status;
        }

        public void AddProducttoOrder(AddProducttoOrder input)
        {
            foreach (var productId in input.ProductIds)
            {
                var productFind = _dbContext.OrderDetails.FirstOrDefault(s =>
                s.ProductId == productId && s.OrderId == input.OrderId);

                if (productFind != null)
                {
                    continue;
                }
                _dbContext.OrderDetails.Add(
                    new OdDetail
                    {
                        ProductId = productId,
                        OrderId = input.OrderId,
                    });
                _dbContext.SaveChanges();
            }
        }

        public void NewUserOrder(UserOrder input)
        {
            var orderFind = _dbContext.OrderUsers.FirstOrDefault(s =>
        s.OrderId == input.OrderIds && s.UserId == input.UserId);

            if (orderFind == null)
            {
                _dbContext.OrderUsers.Add(
                    new OrderUser
                    {
                        OrderId = input.OrderIds,
                        UserId = input.UserId,
                    });
                _dbContext.SaveChanges();
            }
        }
        public List<OrderDto> GetAllProductOrder(int productId)
        {
            throw new NotImplementedException();
        }

        public List<ProductDto> GetAllUserOrder(int userId)
        {
            throw new NotImplementedException();
        }

        public void AddPaymentToOrder(AddPaymentDto input)
        {
            foreach (var orderId in input.OrderIds)
            {
                var orderFind = _dbContext.OrderPayments.FirstOrDefault(s =>
                s.OrderId == orderId && s.PaymentId == input.PaymentId);

                if (orderFind != null)
                {
                    continue;
                }
                _dbContext.OrderPayments.Add(
                    new OdOrderPayment
                    {
                        OrderId = orderId,
                        PaymentId = input.PaymentId,
                    });
                _dbContext.SaveChanges();
            }
        }

        public void AddDiscointToOrder(AddDiscounttoOrder input)
        {
            foreach (var orderId in input.OrderIds)
            {
                var orderFind = _dbContext.OrderDiscounts.FirstOrDefault(s =>
                s.OrderId == orderId && s.DiscountId == input.DiscountId);

                if (orderFind != null)
                {
                    continue;
                }
                _dbContext.OrderDiscounts.Add(
                    new OdOrderDiscount
                    {
                        OrderId = orderId,
                        DiscountId = input.DiscountId,
                    });
                _dbContext.SaveChanges();
            }
        }

        public void AddDelivery(DeliveryDto input)
        {
            var orderFind = _dbContext.Deliverys.FirstOrDefault(s =>
            s.OrderId == input.OrderIds && s.AddressId == input.AddressId);

            if (orderFind == null)
            {
                _dbContext.Deliverys.Add(
                    new OdDelivery
                    {
                        OrderId = input.OrderIds,
                        AddressId = input.AddressId,
                    });
                _dbContext.SaveChanges();
            }
        }

    }
}
