using HA.Order.Dtos;
using HA.Order.Dtos.Delivery;
using HA.Order.Dtos.Detail;
using HA.Order.Dtos.OrderDiscount;
using HA.Order.Dtos.OrderPayment;
using HA.Order.Dtos.ProductOrder;
using HA.Order.Dtos.UserOrder;
using HA.Product.Dtos.ProductModule;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.ApplicationService.OrderModule.Abstract
{
    public interface IOrderService
    {
        OrderDto CreatenewOrder(CreateOrderDto input);
        void UpdateOrder(UpdateOrderDto input);
        List<OrderDto> GetOrders();
        void DeleteOrder(int id);
        void AddProducttoOrder(AddProducttoOrder input);
        List<OrderDto> GetAllProductOrder(int productId);
        void NewUserOrder(UserOrder input);
        List<ProductDto> GetAllUserOrder(int userId);
        void AddPaymentToOrder(AddPaymentDto input);
        void AddDiscointToOrder(AddDiscounttoOrder input);
        void AddDelivery(DeliveryDto input);
        void OrderDetail(DetailDto input);
        decimal CalculateOrderTotal(int orderId);
    }
}
