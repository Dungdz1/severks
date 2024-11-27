using HA.Product.ApplicationService.ProductModule.Abstracts;
using HA.Product.ApplicationService.ProductModule.Implement;
using HA.Product.Dtos.ProductModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HA.WebAPI.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly ITypeService _typeService;
        public ProductTypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }
        [HttpPost("CreateType")]
        public IActionResult CreateType([FromBody] CreateTypeDto input)
        {
            var type = _typeService.CreateType(input);
            return Ok(type);
        }

        [HttpPut("updatetype")]
        public IActionResult UpdateTypes([FromBody] UpdateTypeDto input)
        {
            try
            {
                _typeService.UpdateType(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteBy{id}")]
        public IActionResult DeleteType(int id)
        {
            _typeService.DeleteType(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var brand = _typeService.GetAllTypes();
            return Ok(brand);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var type = _typeService.GetTypeById(id);
            return Ok(type);
        }
    }
}
