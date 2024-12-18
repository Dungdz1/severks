using HA.Order.Dtos;
using HA.Order.Dtos.Delivery;
using HA.Order.Dtos.Detail;
using HA.Order.Dtos.OrderDiscount;
using HA.Order.Dtos.OrderPayment;
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
        List<OrderDto> GetOrders();
        void DeleteOrder(int id);
        List<OrderDto> GetAllProductOrder(int productId);
        List<ProductDto> GetAllUserOrder(int userId);
        void AddPaymentToOrder(AddPaymentDto input);
        void AddDiscointToOrder(AddDiscounttoOrder input);
        void AddDelivery(DeliveryDto input);
        void AddProductToOrders(DetailDto input);
        OrderDto CreateNewOrder(CreateOrderDto input);
        void AddOrdertoUser(UserOrderDto input);
        decimal AddProductToOrder(DetailDto input);
        decimal CalculateOrderTotal(int orderId);
    }
}
