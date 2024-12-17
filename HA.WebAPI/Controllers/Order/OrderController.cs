using HA.Order.ApplicationService.OrderModule.Abstract;
using HA.Order.Dtos;
using HA.Order.Dtos.Delivery;
using HA.Order.Dtos.OrderDiscount;
using HA.Order.Dtos.OrderPayment;
using HA.Order.Dtos.ProductOrder;
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
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("CreateOrder")]
        public IActionResult CreateOrder([FromBody] CreateOrderDto input)
        {
            var order = _orderService.CreatenewOrder(input);
            return Ok(order);
        }

        [HttpPut("update")]
        public IActionResult UpdateOrder([FromBody] UpdateOrderDto input)
        {
            try
            {
                _orderService.UpdateOrder(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        public IActionResult DeleteProduct(int id)
        {
            _orderService.DeleteOrder(id);
            return Ok();
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

        [HttpPost("AddProductToOrder")]
        public IActionResult AddProductOrder([FromBody] AddProducttoOrder input)
        {
            try
            {
                if (input == null || input.ProductIds == null || !input.ProductIds.Any())
                {
                    return BadRequest(new { Message = "Invalid input data." });
                }

                _orderService.AddProducttoOrder(input);

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

        [HttpGet("calculate-total/{orderId}")]
        public IActionResult CalculateOrderTotal(int orderId)
        {
            var totalAmount = _orderService.CalculateOrderTotal(orderId);
            return Ok(new
            {
                OrderId = orderId,
                TotalAmount = totalAmount
            });
        }
    }
}
