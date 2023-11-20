using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UIRSHOP.BL.Models.Dtos.CategoryDtos;
using UIRSHOP.BL.Models.Dtos.SupplierDtos;
using UIRSHOP.BL.Services;

namespace UIRSHOP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> Get()
        {
            try
            {
                var suppliers = await _supplierService.GetAllSuppliers();
                return Ok(suppliers);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving suppliers");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDto>> GetById(int id)
        {
            try
            {
                var supplier = await _supplierService.GetSupplier(id);
                if (supplier == null)
                {
                    return NotFound();
                }
                return Ok(supplier);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving supplier");
            }
        }

        [HttpPost]
        public async Task<ActionResult<SupplierDto>> Create([FromBody] SupplierDto supplierDto)
        {
            if (supplierDto == null)
            {
                return BadRequest("Supplier data is null");
            }

            try
            {
                var newSupplier = await _supplierService.CreateSupplier(supplierDto);
                return CreatedAtAction(nameof(GetById), new { id = newSupplier.Name }, newSupplier);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating Supplier");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SupplierDto supplierDto)
        {
            if (id != supplierDto.Id)
            {
                return BadRequest("supplier ID mismatch");
            }

            try
            {
                await _supplierService.UpdateSupplier(id, supplierDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating supplier");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _supplierService.DeleteSupplier(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting supplier");
            }
        }

    }
}
