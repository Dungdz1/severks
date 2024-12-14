using HA.Product.Dtos.ProductModule;
using HA.Product.Dtos.ProductModule.Brand;
using HA.Product.Dtos.ProductModule.Cart;
using HA.Product.Dtos.ProductModule.Category;
using HA.Product.Dtos.ProductModule.Img;
using HA.Product.Dtos.ProductModule.Sale;
using HA.Product.Dtos.ProductModule.Type;
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
        void AddProductCategory(ProductCategory input);
        List<ProductDto> GetAllProduct(int categoryId);
        void AddProductBrand(ProductBrand input);
        List<ProductDto> GetAllProductBrand(int brandId);
        void AddProductType(ProductType input);
        List<ProductDto> GetAllProductType(int typeId);
        void AddProductImage(ProductImage input);
        List<ProductDto> GetAllProductImage(int imageId);
        void AddProductSale(ProductSale input);
        List<ProductDto> GetAllProductSale(int saleId);
        void AddProducttoCart(AddtoCart input);
        List<ProductDto> GetAllProductToCart(int customerId);
    }
}
