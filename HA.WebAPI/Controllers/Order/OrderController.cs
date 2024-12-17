using HA.Order.ApplicationService.OrderModule.Abstract;
using HA.Order.Dtos;
using HA.Order.Dtos.Delivery;
using HA.Order.Dtos.Detail;
using HA.Order.Dtos.OrderDiscount;
using HA.Order.Dtos.OrderPayment;
using HA.Product.ApplicationService.ProductModule.Abstracts;
using HA.Product.ApplicationService.ProductModule.Implement;
using HA.Product.Dtos.ProductModule;
using HA.Product.Dtos.ProductModule.Brand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HA.WebAPI.Controllers.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;
        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }
        

        [HttpPost("AddOrderDiscount")]
        public IActionResult AddOrderDiscount([FromBody] AddDiscounttoOrder input)
        {
            try
            {
                if (input == null || input.OrderIds == null || !input.OrderIds.Any())
                {
                    return BadRequest(new { Message = "Invalid input data." });
                }

                _orderService.AddDiscointToOrder(input);

                return Ok(new { Message = "Order brands added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "An error occurred while adding Discount.",
                    Error = ex.Message
                });
            }
        }

        [HttpPost("AddOrderPayment")]
        public IActionResult AddOrderPayment([FromBody] AddPaymentDto input)
        {
            try
            {
                if (input == null || input.OrderIds == null || !input.OrderIds.Any())
                {
                    return BadRequest(new { Message = "Invalid input data." });
                }

                _orderService.AddPaymentToOrder(input);

                return Ok(new { Message = "Order brands added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "An error occurred while adding Discount.",
                    Error = ex.Message
                });
            }
        }

        [HttpPost("AddOrderAddress")]
        public IActionResult AddOrderAddress([FromBody] DeliveryDto input)
        {
            try
            {
                if (input == null || input.OrderIds <= 0)
                {
                    return BadRequest(new { Message = "Invalid input data." });
                }

                _orderService.AddDelivery(input);

                return Ok(new { Message = "Order brands added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "An error occurred while adding Address.",
                    Error = ex.Message
                });
            }
        }
        [HttpPost]
        public IActionResult CreateNewOrder([FromBody] OrderDto input)
        {
            try
            {
                _orderService.CreateNewOrder(input);
                return Ok(new { Message = "Order đã được tạo thành công.", Order = input });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Đã xảy ra lỗi trong quá trình tạo Order.", Details = ex.Message });
            }
        }

        [HttpPost("add_product")]
        public IActionResult AddtoOrder([FromBody] DetailDto input)
        {
            try
            {
                if (input == null)
                {
                    return BadRequest(new { Message = "Input data is required." });
                }

                _orderService.AddProductToOrder(input);
                return Ok(new { Message = "Products have been successfully added to the order." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while adding products to the order.", Details = ex.Message });
            }
        }
    }
}
