using HA.Order.ApplicationService.OrderModule.Abstract;
using HA.Order.Dtos;
using HA.Product.ApplicationService.ProductModule.Abstracts;
using HA.Product.ApplicationService.ProductModule.Implement;
using HA.Product.Dtos.ProductModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HA.WebAPI.Controllers.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public OrderDiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpPost("CreateDiscount")]
        public IActionResult CreateDiscount([FromBody] CreateDiscountDto input)
        {
            var discount = _discountService.CreateNewDiscount(input);
            return Ok();
        }

        [HttpPut("updatediscount")]
        public IActionResult UpdateDiscount([FromBody] UpdateDiscountDto input)
        {
            try
            {
                _discountService.UpdateDiscount(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteBy{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            _discountService.DeleteDiscount(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dis = _discountService.GetAllDiscount();
            return Ok(dis);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var disc = _discountService.GetDiscountById(id);
            return Ok(disc);
        }
    }
}
