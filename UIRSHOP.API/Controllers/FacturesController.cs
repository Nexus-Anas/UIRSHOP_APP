using Microsoft.AspNetCore.Mvc;
using UIRSHOP.BL.Models.Dtos.FactureDto;
using UIRSHOP.BL.Services;

namespace UIRSHOP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturesController : ControllerBase
    {
        private readonly IFactureService _factureService;
        public FacturesController(IFactureService factureService)
        {
            _factureService = factureService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FactureDto>>> Get()
        {
            try
            {
                var factures = await _factureService.GetAllFactures();
                return Ok(factures);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving factures");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FactureDto>> GetById(int id)
        {
            try
            {
                var facture = await _factureService.GetFacture(id);
                if (facture == null)
                {
                    return NotFound();
                }
                return Ok(facture);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving facture");
            }
        }

        [HttpPost]
        public async Task<ActionResult<FactureDto>> Create([FromBody] FactureDto factureDto)
        {
            if (factureDto == null)
            {
                return BadRequest("Facture data is null");
            }

            try
            {
                var newFacture = await _factureService.CreateFacture(factureDto);
                return CreatedAtAction(nameof(GetById), new { id = newFacture.Num }, newFacture);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating facture");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FactureDto factureDto)
        {
            if (id != factureDto.Id)
            {
                return BadRequest("Facture ID mismatch");
            }

            try
            {
                await _factureService.UpdateFacture(id, factureDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating Facture");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _factureService.DeleteFacture(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting facture");
            }
        }
    }
}
