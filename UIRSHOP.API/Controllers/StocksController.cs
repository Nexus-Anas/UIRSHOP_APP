using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UIRSHOP.BL.Models.Dtos.CategoryDtos;
using UIRSHOP.BL.Models.Dtos.StockDtos;
using UIRSHOP.BL.Services;

namespace UIRSHOP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockService _stockService;
        public StocksController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockDto>>> Get()
        {
            try
            {
                var stocks = await _stockService.GetAllStocks();
                return Ok(stocks);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving stocks");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockDto>> GetById(int id)
        {
            try
            {
                var stock = await _stockService.GetStock(id);
                if (stock == null)
                {
                    return NotFound();
                }
                return Ok(stock);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving stock");
            }
        }

        [HttpPost]
        public async Task<ActionResult<StockDto>> Create([FromBody] StockDto stockDto)
        {
            if (stockDto == null)
            {
                return BadRequest("Stock data is null");
            }

            try
            {
                var newStock = await _stockService.CreateStock(stockDto);
                return CreatedAtAction(nameof(GetById), new { id = newStock.Id }, newStock);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating stock");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StockDto stockDto)
        {
            if (id != stockDto.Id)
            {
                return BadRequest("Stock ID mismatch");
            }

            try
            {
                await _stockService.UpdateStock(id, stockDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating stock");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _stockService.DeleteStock(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting stock");
            }
        }
    }
}
