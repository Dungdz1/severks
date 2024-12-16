using HA.Product.ApplicationService.ProductModule.Abstracts;
using HA.Product.ApplicationService.ProductModule.Implement;
using HA.Product.Dtos.ProductModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HA.WebAPI.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ProductImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("CreateType")]
        public IActionResult CreateType([FromBody] CreateImageDto input)
        {
            var type = _imageService.AddNewImage(input);
            return Ok(type);
        }

        [HttpPut("updateimg")]
        public IActionResult UpdateImages([FromBody] UpdateImageDto input)
        {
            try
            {
                _imageService.UpdateImage(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteBy{id}")]
        public IActionResult DeleteImage(int id)
        {
            _imageService.DeleteImage(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var brand = _imageService.GetAllImages();
            return Ok(brand);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var type = _imageService.GetImageById(id);
            return Ok(type);
        }
    }
}