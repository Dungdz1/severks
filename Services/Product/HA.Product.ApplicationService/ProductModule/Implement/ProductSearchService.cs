using HA.Product.ApplicationService.Common;
using HA.Product.ApplicationService.ProductModule.Abstracts;
using HA.Product.Domain;
using HA.Product.Dtos.ProductModule;
using HA.Product.Infrastructure;
using HA.Shared.ApplicationService;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.ApplicationService.ProductModule.Implement
{
    public class ProductSearchService : ProductServiceBase, IProductSearchService
    {
        public ProductSearchService(ILogger<ProductSearchService> logger, BasethDbContext dbContext)
            : base(logger, dbContext)
        {
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = FindProductById(id);
            if (product == null)
            {
                return null;
            }

            return MapToDto(product);
        }

        public async Task<IEnumerable<ProductDto>> SearchProductsByNameAsync(string name)
        {
            var products = await Task.Run(() =>
                _dbContext.Products
                    .Where(p => !p.IsDelete && p.ProductName.Contains(name))
                    .ToList());

            return products.Select(MapToDto);
        }

        private ProductDto MapToDto(ProdProduct product)
        {
            return new ProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProdPrice = product.ProdPrice.ToString(),
                ProdImg = product.ProdImg,
                ProdDescription = product.ProdDescription,
                ProdStock = product.ProdStock.ToString()
            };
        }
    }
}