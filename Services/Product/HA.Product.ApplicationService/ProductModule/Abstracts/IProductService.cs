using HA.Product.Dtos.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.ApplicationService.ProductModule.Abstracts
{
    public interface IProductService
    {
        ProductDto CreatenewProduct(CreateProductDto input);
        void UpdateProduct(UpdateProductDto input);
        List<ProductDto> GetProducts();
        void DeleteProduct(int id);
    }
}
