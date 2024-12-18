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
        [HttpPost("Create")]
        public IActionResult CreateNewOrder([FromBody] CreateOrderDto input)
        {
            var orders = _orderService.CreateNewOrder(input);
            return Ok(orders);
        }

        [HttpPost("AddOrderUser")]
        public IActionResult AddOrderUser([FromBody] UserOrderDto input)
        {
            try
            {
                if (input == null || input.OrderIds == null || !input.OrderIds.Any())
                {
                    return BadRequest(new { Message = "Invalid input data." });
                }

                _orderService.AddOrdertoUser(input);

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

        [HttpPost("add-products")]
        public IActionResult AddProductsToOrder([FromBody] DetailDto input)
        {
            if (input == null)
            {
                return BadRequest("Input cannot be null.");
            }

            try
            {
                var totalOrderAmount = _orderService.AddProductToOrder(input);

                return Ok(new
                {
                    OrderId = input.OrderId,
                    TotalOrderAmount = totalOrderAmount,
                    Message = "Products added and total amount calculated successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{orderId}/calculate-total")]
        public IActionResult CalculateOrderTotal(int orderId)
        {
            try
            {
                var totalOrderAmount = _orderService.CalculateOrderTotal(orderId);

                return Ok(new
                {
                    OrderId = orderId,
                    TotalOrderAmount = totalOrderAmount
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
