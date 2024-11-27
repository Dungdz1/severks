using HA.Product.Dtos.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.ApplicationService.ProductModule.Abstracts
{
    public interface IProductSearchService
    {
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDto>> SearchProductsByNameAsync(string name);
    }
}
