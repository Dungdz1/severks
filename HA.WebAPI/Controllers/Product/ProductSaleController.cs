using HA.Product.ApplicationService.ProductModule.Abstracts;
using HA.Product.ApplicationService.ProductModule.Implement;
using HA.Product.Dtos.ProductModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HA.WebAPI.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        public ProductSaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }
        [HttpPost("CreateSale")]
        public IActionResult CreateSale([FromBody] CreateSaleDto input)
        {
            var brand = _saleService.CreatenewSale(input);
            return Ok(brand);
        }

        [HttpPut("updatesale")]
        public IActionResult Updatesales([FromBody] UpdateSaleDto input)
        {
            try
            {
                _saleService.UpdateSale(input);
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
            _saleService.DeleteSale(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var brand = _saleService.GetAllSale();
            return Ok(brand);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var brand = _saleService.GetSaleById(id);
            return Ok(brand);
        }
    }
}
