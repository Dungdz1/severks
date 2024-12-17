using HA.Order.ApplicationService.Common;
using HA.Order.ApplicationService.OrderModule.Abstract;
using HA.Order.Domain;
using HA.Order.Dtos;
using HA.Order.Dtos.Delivery;
using HA.Order.Dtos.Detail;
using HA.Order.Dtos.OrderDiscount;
using HA.Order.Dtos.OrderPayment;
using HA.Order.Infrastructure;
using HA.Product.Domain;
using HA.Product.Dtos.ProductModule;
using HA.Product.Dtos.ProductModule.Cart;
using HA.Shared.ApplicationService;
using Microsoft.EntityFrameworkCore;
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
                UserId = s.UserId,
                Status = s.Status,
                OrderDate = s.OrderDate,
            });
            return result.ToList();
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
        public void AddProductToOrder(DetailDto input)
        {
            if (input.ProductIds == null || input.Quantitys == null)
            {
                throw new ArgumentException("ProductIds and Quantitys cannot be null.");
            }

            if (input.ProductIds.Count != input.Quantitys.Count)
            {
                throw new ArgumentException("The number of ProductIds must match the number of Quantitys.");
            }

            decimal totalAmount = 0;

            for (int i = 0; i < input.ProductIds.Count; i++)
            {
                var productId = input.ProductIds[i];
                var quantity = input.Quantitys[i];

                // Lấy thông tin sản phẩm từ database
                var product = _dbContext.Products.FirstOrDefault(p => p.Id == productId);
                if (product == null)
                {
                    throw new ArgumentException($"Product with ID {productId} not found.");
                }

                var productTotal = product.ProdPrice * quantity;
                totalAmount += productTotal;

                var orderDetail = _dbContext.OrderDetails.FirstOrDefault(od =>
                    od.ProductId == productId && od.OrderId == input.OrderId);

                if (orderDetail != null)
                {
                    orderDetail.Quantity += quantity;
                    orderDetail.TotalAmount += productTotal;
                }
                else
                {
                    // Thêm mới OrderDetail nếu chưa có
                    _dbContext.OrderDetails.Add(new OdDetail
                    {
                        OrderId = input.OrderId,
                        ProductId = productId,
                        Quantity = quantity,
                        TotalAmount = productTotal
                    });
                }
            }

            // Cập nhật tổng tiền cho đơn hàng (nếu cần)
            var order = _dbContext.OrderDetails.FirstOrDefault(o => o.Id == input.OrderId);
            if (order != null)
            {
                order.TotalAmount += totalAmount;
            }

            _dbContext.SaveChanges();

            // Cập nhật lại TotalAmount trong DTO để trả về
            input.TotalAmount = totalAmount;
        }
        


        public void CreateNewOrder(OrderDto input)
        {
            var existingOrder = _dbContext.Orders
                .FirstOrDefault(o => o.UserId == input.UserId);

            if (existingOrder != null)
            {
                // Nếu đã tồn tại, ném ngoại lệ
                throw new InvalidOperationException($"User với ID {input.UserId} đã có một Order.");
            }

            // Nếu không tồn tại, tạo mới Order
            var newOrder = new OdOrder
            {
                UserId = input.UserId,
                OrderDate = input.OrderDate,
                Status = input.Status
            };

            // Thêm Order mới vào database
            _dbContext.Orders.Add(newOrder);
            _dbContext.SaveChanges();
        }

    }
}
