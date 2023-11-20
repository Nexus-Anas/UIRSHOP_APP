
using Microsoft.AspNetCore.Mvc;
using UIRSHOP.BL.Models.Dtos.OrderDtos;
using UIRSHOP.BL.Services;

namespace UIRSHOP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderservice;
        public OrdersController(IOrderService orderService)
        {
            _orderservice = orderService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> Get()
        {
            try
            {
                var orders = await _orderservice.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving orders");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            try
            {
                var order = await _orderservice.GetOrder(id);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving order");
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> Create([FromBody] OrderDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("order data is null");
            }

            try
            {
                var newOrder = await _orderservice.CreateOrder(orderDto);
                return CreatedAtAction(nameof(GetById), new { id = newOrder.Id }, newOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating order");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OrderDto orderDto)
        {
            if (id != orderDto.Id)
            {
                return BadRequest("order ID mismatch");
            }

            try
            {
                await _orderservice.UpdateOrder(id, orderDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating order");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _orderservice.DeleteOrder(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting order");
            }
        }

    }
}
