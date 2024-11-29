using HA.Product.Dtos.ProductModule.Brand;
using HA.Product.Dtos.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HA.Order.Dtos.OrderPayment;
using HA.Order.Dtos;

namespace HA.Order.ApplicationService.OrderModule.Abstract
{
    public interface IPaymentService
    {
        PaymentDto CreatePayment(CreatePaymentDto input);
        void UpdatePayment(UpdatePaymentDto input);
        void DeletePayment(int id);
        List<PaymentDto> GetAllPayment();
        PaymentDto GetPaymentById(int id);
    }
}
