using Microsoft.AspNetCore.Mvc;
using UIRSHOP.BL.Models.Dtos.ProductDtos;
using UIRSHOP.BL.Models.Dtos.SubCategory;
using UIRSHOP.BL.Services;

namespace UIRSHOP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;
        public SubCategoriesController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoryDto>>> Get()
        {
            try
            {
                var subCategories = await _subCategoryService.GetAllSubCategories();
                return Ok(subCategories);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving subCategories");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoryDto>> GetById(int id)
        {
            try
            {
                var subCategory = await _subCategoryService.GetSubCategory(id);
                if(subCategory == null)
                {
                    return NotFound();
                }
                return Ok(subCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving SubCategory");
            }
        }

        [HttpPost]
        public async Task<ActionResult<SubCategoryDto>> Post([FromBody] SubCategoryDto subCategoryDto)
        {
            if(subCategoryDto == null)
            {
                return BadRequest("Product data is null");
            }
            try
            {
                var newSubCategory = await _subCategoryService.CreateSubCategory(subCategoryDto);
                return CreatedAtAction(nameof(GetById), new { name = newSubCategory.Name }, newSubCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating product");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SubCategoryDto>> Update(int id, [FromBody] SubCategoryDto subCategoryDto)
        {
            if (id != subCategoryDto.Id)
            {
                return BadRequest("subCategory ID mismatch");
            }

            try
            {
                await _subCategoryService.UpdateSubCategory(id, subCategoryDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating subCategory");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _subCategoryService.DeleteSubCategory(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting subCategory");
            }
        }
    }
}
