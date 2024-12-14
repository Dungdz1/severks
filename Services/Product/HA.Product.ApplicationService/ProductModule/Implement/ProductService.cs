using HA.Product.ApplicationService.Common;
using HA.Product.ApplicationService.ProductModule.Abstracts;
using HA.Product.Domain;
using HA.Product.Dtos.ProductModule;
using HA.Product.Dtos.ProductModule.Brand;
using HA.Product.Dtos.ProductModule.Cart;
using HA.Product.Dtos.ProductModule.Category;
using HA.Product.Dtos.ProductModule.Img;
using HA.Product.Dtos.ProductModule.Sale;
using HA.Product.Dtos.ProductModule.Type;
using HA.Product.Infrastructure;
using HA.Shared.ApplicationService;
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
        private readonly BasethDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public ProductService(ILogger<ProductService> logger, BasethDbContext dbContext, IConfiguration configuration) : base(logger, dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public void AddProducttoCart(AddtoCart input)
        {
            foreach (var productId in input.ProductIds)
            {
                var productFind = _dbContext.ProductCarts.FirstOrDefault(s =>
                s.ProductId == productId && s.CustomerId == input.CustomerId);

                if (productFind != null)
                {
                    continue;
                }
                _dbContext.ProductCarts.Add(
                    new ProdCart
                    {
                        ProductId = productId,
                        CustomerId = input.CustomerId,
                    });
                _dbContext.SaveChanges();
            }
        }
        public void AddProductBrand(ProductBrand input)
        {
            foreach (var productId in input.ProductId1)
            {
                var productFind = _dbContext.ProductBrands.FirstOrDefault(s => 
                s.ProductId == productId && s.BrandId == input.BrandId);
                
                if (productFind != null)
                {
                    continue;
                }
                _dbContext.ProductBrands.Add(
                    new ProdProductBrand
                    {
                        ProductId = productId,
                        BrandId = input.BrandId,
                    });
                _dbContext.SaveChanges();
            }
        }

        public void AddProductSale(ProductSale input)
        {
            foreach (var productId in input.ProductIds)
            {
                var productFind = _dbContext.ProductSales.FirstOrDefault(s =>
                s.ProductId == productId && s.SaleId == input.SaleId);

                if (productFind != null)
                {
                    continue;
                }
                _dbContext.ProductSales.Add(
                    new ProdSale
                    {
                        ProductId = productId,
                        SaleId = input.SaleId,
                    });
                _dbContext.SaveChanges();
            }
        }
        public void AddProductImage(ProductImage input)
        {
            foreach (var imageId in input.ImageIds)
            {
                var imageFind = _dbContext.ProductImages.FirstOrDefault(s =>
                s.ImageId == imageId && s.ProductId == input.ProductId);

                if (imageFind != null)
                {
                    continue;
                }
                _dbContext.ProductImages.Add(
                    new ProdProductImage
                    {
                        ImageId = imageId,
                        ProductId = input.ProductId,
                    });
                _dbContext.SaveChanges();
            }
        }

        public void AddProductType(ProductType input)
        {
            foreach (var productId in input.ProductIds)
            {
                var productFind = _dbContext.ProductTypes.FirstOrDefault(s =>
                s.ProductId == productId && s.TypeId == input.TypeId);

                if (productFind != null)
                {
                    continue;
                }
                _dbContext.ProductTypes.Add(
                    new ProdProductType
                    {
                        ProductId = productId,
                        TypeId = input.TypeId,
                    });
                _dbContext.SaveChanges();
            }
        }

        public void AddProductCategory(ProductCategory input)
        {
            foreach (var productId in input.ProductIds)
            {
                var productFind = _dbContext.ProductCategories.FirstOrDefault(s =>
                    s.ProductId == productId && s.CategoryId == input.CategoryId
                );

                if (productFind != null)
                {
                    continue;
                }

                _dbContext.ProductCategories.Add(
                    new ProdProductCategory
                    {
                        ProductId = productId,
                        CategoryId = input.CategoryId,
                    });
            }
            _dbContext.SaveChanges();
        }


        public List<ProductDto> GetAllProduct(int categoryId)
        {
            throw new NotImplementedException();
            // Viet tiep truy van neu can thiet
        }

        public List<ProductDto> GetAllProductBrand(int brandId)
        {
            throw new NotImplementedException();
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

        public List<ProductDto> GetAllProductType(int typeId)
        {
            throw new NotImplementedException();
        }

        public List<ProductDto> GetAllProductImage(int imageId)
        {
            throw new NotImplementedException();
        }

        public List<ProductDto> GetAllProductSale(int saleId)
        {
            throw new NotImplementedException();
        }

        public List<ProductDto> GetAllProductToCart(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}