using HA.Auth.Dtos.UserModule;
using HA.Product.ApplicationService.ProductModule.Abstracts;
using HA.Product.Dtos.ProductModule;
using HA.Product.Dtos.ProductModule.Brand;
using HA.Product.Dtos.ProductModule.Category;
using HA.Product.Dtos.ProductModule.Img;
using HA.Product.Dtos.ProductModule.Sale;
using HA.Product.Dtos.ProductModule.Type;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HA.WebAPI.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductSearchService _productSearchService;
        private static int _id = 0;

        public ProductController(IProductService productService, IProductSearchService productSearchService)
        {
            _productService = productService;
            _productSearchService = productSearchService;
        }

        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct([FromBody] CreateProductDto input)
        {
            var product = _productService.CreatenewProduct(input);
            return Ok(product);
        }

        /// <summary>
        /// Get product by ID
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>ProductDto</returns>
        /// 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productSearchService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            return Ok(product);
        }

        /// <summary>
        /// Search products by name
        /// </summary>
        /// <param name="name">Partial or full name of the product</param>
        /// <returns>List of ProductDto</returns>
        [HttpGet("search")]
        public async Task<IActionResult> SearchProductsByName([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest(new { message = "Search term cannot be empty" });
            }

            var products = await _productSearchService.SearchProductsByNameAsync(name);
            if (products == null || !products.Any())
            {
                return NotFound(new { message = "No products found" });
            }

            return Ok(products);
        }

        [HttpPut("update")]
        public IActionResult UpdateProduct([FromBody] UpdateProductDto input)
        {
            try
            {
                _productService.UpdateProduct(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }

        [HttpPost("AddProductCategory")]
        public IActionResult AddProductCategory([FromBody] ProductCategory input)
        {
            try
            {
                if (input == null || input.ProductIds == null || !input.ProductIds.Any())
                {
                    return BadRequest(new { Message = "Invalid input data." });
                }

                _productService.AddProductCategory(input);

                return Ok(new { Message = "Product categories added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "An error occurred while adding product categories.",
                    Error = ex.Message
                });
            }
        }

        [HttpPost("AddProductBrand")]
        public IActionResult AddProductBrand([FromBody] ProductBrand input)
        {
            try
            {
                if (input == null || input.ProductId1 == null || !input.ProductId1.Any())
                {
                    return BadRequest(new { Message = "Invalid input data." });
                }

                _productService.AddProductBrand(input);

                return Ok(new { Message = "Product brands added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "An error occurred while adding product brands.",
                    Error = ex.Message
                });
            }
        }

        [HttpPost("AddProductType")]
        public IActionResult AddProductType([FromBody] ProductType input)
        {
            try
            {
                if (input == null || input.ProductIds == null || !input.ProductIds.Any())
                {
                    return BadRequest(new { Message = "Invalid input data." });
                }

                _productService.AddProductType(input);

                return Ok(new { Message = "Product types added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "An error occurred while adding product types.",
                    Error = ex.Message
                });
            }
        }

        [HttpPost("AddProductImage")]
        public IActionResult AddProductImage([FromBody] ProductImage input)
        {
            try
            {
                if (input == null || input.ProductIds == null || !input.ProductIds.Any())
                {
                    return BadRequest(new { Message = "Invalid input data." });
                }

                _productService.AddProductImage(input);

                return Ok(new { Message = "Product images added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "An error occurred while adding product images.",
                    Error = ex.Message
                });
            }
        }

        [HttpPost("AddProductSale")]
        public IActionResult AddProductSale([FromBody] ProductSale input)
        {
            try
            {
                if (input == null || input.ProductIds == null || !input.ProductIds.Any())
                {
                    return BadRequest(new { Message = "Invalid input data." });
                }

                _productService.AddProductSale(input);

                return Ok(new { Message = "Product categories added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "An error occurred while adding product sales.",
                    Error = ex.Message
                });
            }
        }
    }
}
