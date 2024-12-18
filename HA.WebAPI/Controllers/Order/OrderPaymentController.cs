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

        [HttpPut("updatepayment")]
        public IActionResult UpdatePayment([FromBody] UpdatePaymentDto input)
        {
            try
            {
                _paymentService.UpdatePayment(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteBy{id}")]
        public IActionResult DeletePayment(int id)
        {
            _paymentService.DeletePayment(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var pay = _paymentService.GetAllPayment();
            return Ok(pay);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pay = _paymentService.GetPaymentById(id);
            return Ok(pay);
        }
    }
}
