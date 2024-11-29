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
        public IActionResult CreateDiscount([FromBody] CreateDiscountDto input)
        {
            var discount = _discountService.CreateNewDiscount(input);
            return Ok();
        }
    }
}
