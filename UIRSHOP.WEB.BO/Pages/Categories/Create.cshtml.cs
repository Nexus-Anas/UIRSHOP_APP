using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UIRSHOP.BL.Models.Dtos.CategoryDtos;
using UIRSHOP.WEB.BO.Services;

namespace UIRSHOP.WEB.BO.Pages.Categories;

public class CreateModel : PageModel
{
    private readonly CategoryService _service;
    public CreateModel(CategoryService service) => _service = service;


    [BindProperty]
    public CategoryDto CategoryDto { get; set; }




    public async Task<IActionResult> OnPostCreate()
    {
        if (string.IsNullOrEmpty(CategoryDto.Name) || !ModelState.IsValid)
        {
            ModelState.AddModelError("CategoryDto.Name", "The field \"Name\" is required!");
            return Page();
        }
        CategoryDto.CreatedDate = DateTime.Now;
        await _service.Create(CategoryDto);
        return RedirectToPage("/Categories/Index");
    }
}
