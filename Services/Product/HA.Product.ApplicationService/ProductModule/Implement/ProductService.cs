using HA.Product.ApplicationService.Common;
using HA.Product.ApplicationService.ProductModule.Abstracts;
using HA.Product.Domain;
using HA.Product.Dtos.ProductModule;
using HA.Product.Dtos.ProductModule.Sale;
using HA.Product.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.ApplicationService.ProductModule.Implement
{
    public class ProductService : ProductServiceBase, IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly ProductDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public ProductService(ILogger<ProductService> logger, ProductDbContext dbContext, IConfiguration configuration) : base(logger, dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        ProductDto IProductService.CreatenewProduct(CreateProductDto input)
        {
            var product = new ProdProduct
            {
                ProductName = input.ProductName,
                ProdPrice = input.ProdPrice,
                ProdImg = input.ProdImg,
                ProdDescription = input.ProdDescription,
                ProdStock = input.ProdStock
            };
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return new ProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProdPrice = product.ProdPrice,
                ProdImg = product.ProdImg,
                ProdDescription = product.ProdDescription,
                ProdStock = product.ProdStock,
            };
        }

        void IProductService.DeleteProduct(int id)
        {
            var productFind = FindProductById(id);
            _dbContext.Products.Remove(productFind);
            _dbContext.SaveChanges();
        }

        List<ProductDto> IProductService.GetProducts()
        {
            var result = _dbContext.Products.Select(s => new ProductDto
            {
                Id = s.Id,
                ProductName = s.ProductName,
                ProdPrice = s.ProdPrice,
                ProdImg = s.ProdImg,
                ProdDescription = s.ProdDescription,
                ProdStock = s.ProdStock,
            });
            return result.ToList();
        }

        void IProductService.UpdateProduct(UpdateProductDto input)
        {
            var productFind = FindProductById(input.Id);
            productFind.ProductName = input.ProductName;
            productFind.ProdPrice = input.ProdPrice;
            productFind.ProdImg = input.ProdImg;
            productFind.ProdDescription = input.ProdDescription;
            productFind.ProdStock = input.ProdStock;
        }
    }
}
