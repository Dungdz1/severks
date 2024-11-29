using HA.Product.Dtos.ProductModule.Brand;
using HA.Product.Dtos.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HA.Order.Dtos.OrderDiscount;
using HA.Order.Dtos;

namespace HA.Order.ApplicationService.OrderModule.Abstract
{
    public interface IDiscountService
    {
        DiscountDto CreateNewDiscount(CreateDiscountDto input);
        void UpdateDiscount(UpdateDiscountDto input);
        void DeleteDiscount(int id);
        List<DiscountDto> GetAllDiscount();
        DiscountDto GetDiscountById(int id);
    }
}
