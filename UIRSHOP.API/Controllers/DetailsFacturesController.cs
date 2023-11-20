using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UIRSHOP.BL.Models.Dtos.DetailsFactureDto;
using UIRSHOP.BL.Services;

namespace UIRSHOP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsFacturesController : ControllerBase
    {
        private readonly IDetailsFactureService _detailsFactureService;
        public DetailsFacturesController(IDetailsFactureService detailsFactureService)
        {
            _detailsFactureService = detailsFactureService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailsFactureDto>>> Get()
        {
            try
            {
                var dfs = await _detailsFactureService.GetAllDetailsFactures();
                return Ok(dfs);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving Details Facture");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetailsFactureDto>> GetById(int id)
        {
            try
            {
                var df = await _detailsFactureService.GetDetailsFacture(id);
                if (df == null)
                {
                    return NotFound();
                }
                return Ok(df);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving Details Facture");
            }
        }

        [HttpPost]
        public async Task<ActionResult<DetailsFactureDto>> Create([FromBody] DetailsFactureDto detailsFactureDto)
        {
            if (detailsFactureDto == null)
            {
                return BadRequest("Details Facture data is null");
            }

            try
            {
                var newDfacture = await _detailsFactureService.CreateDetailsFacture(detailsFactureDto);
                return CreatedAtAction(nameof(GetById), new { id = newDfacture.Id }, newDfacture);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating Details Facture");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DetailsFactureDto detailsFactureDto)
        {
            if (id != detailsFactureDto.Id)
            {
                return BadRequest("Details Facture ID mismatch");
            }

            try
            {
                await _detailsFactureService.UpdateDetailsFacture(id, detailsFactureDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating Details Facture");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _detailsFactureService.DeleteDetailsFacture(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting Details Facture");
            }
        }
    }
}