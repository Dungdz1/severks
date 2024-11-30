using HA.Order.ApplicationService.OrderModule.Abstract;
using HA.Order.ApplicationService.OrderModule.Implements;
using HA.Order.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HA.WebAPI.Controllers.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderPaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public OrderPaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpPost("CreateNewPayment")]
        public IActionResult CreatePayment([FromBody] CreatePaymentDto input)
        {
            var discount = _paymentService.CreatePayment(input);
            return Ok();
        }
    }
}
