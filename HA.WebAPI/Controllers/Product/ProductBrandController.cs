using HA.Product.ApplicationService.ProductModule.Abstracts;
using HA.Product.ApplicationService.ProductModule.Implement;
using HA.Product.Dtos.ProductModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HA.WebAPI.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public ProductBrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpPost("CreateBrand")]
        public IActionResult CreateBrand([FromBody] CreateBrandDto input)
        {
            var brand = _brandService.CreatenewBrand(input);
            return Ok(brand);
        }

        [HttpPut("updatebrand")]
        public IActionResult UpdateBrands([FromBody] UpdateBrandDto input)
        {
            try
            {
                _brandService.UpdateBrand(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteBy{id}")]
        public IActionResult DeleteBrand(int id)
        {
            _brandService.DeleteBrand(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var brand = _brandService.GetAllBrand();
            return Ok(brand);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var brand = _brandService.GetBrandById(id);
            return Ok(brand);
        }
    }
}
