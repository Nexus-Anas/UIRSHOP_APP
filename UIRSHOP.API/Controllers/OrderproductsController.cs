using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UIRSHOP.BL.Models.Dtos.OrderproductDtos;
using UIRSHOP.BL.Services;

namespace UIRSHOP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderproductsController : ControllerBase
    {
        private readonly IOrderproductService _orderproductService;
        public OrderproductsController(IOrderproductService orderproductService)
        {
            _orderproductService = orderproductService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderproductDto>>> Get()
        {
            try
            {
                var orderproducts = await _orderproductService.GetAllOrderproducts();
                return Ok(orderproducts);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving orderproducts");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderproductDto>> GetById(int id)
        {
            try
            {
                var orderproduct = await _orderproductService.GetOrderproduct(id);
                if (orderproduct == null)
                {
                    return NotFound();
                }
                return Ok(orderproduct);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving orderproduct");
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderproductDto>> Create([FromBody] OrderproductDto orderproductDto)
        {
            if (orderproductDto == null)
            {
                return BadRequest("orderproduct data is null");
            }

            try
            {
                var newOrderproduct = await _orderproductService.CreateOrderproduct(orderproductDto);
                return CreatedAtAction(nameof(GetById), new { id = newOrderproduct.Id }, newOrderproduct);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating orderproduct");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OrderproductDto orderproductDto)
        {
            if (id != orderproductDto.Id)
            {
                return BadRequest("orderproduct ID mismatch");
            }

            try
            {
                await _orderproductService.UpdateOrderproduct(id, orderproductDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating orderproduct");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _orderproductService.DeleteOrderproduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting orderproduct");
            }
        }
    }
}