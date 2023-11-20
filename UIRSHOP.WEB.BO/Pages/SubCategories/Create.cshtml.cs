using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UIRSHOP.BL.Models.Dtos.SubCategory;
using UIRSHOP.BL.Models.Dtos.CategoryDtos;
using UIRSHOP.WEB.BO.Services;

namespace UIRSHOP.WEB.BO.Pages.SubCategories;

public class CreateModel : PageModel
{
    private readonly SubCategoryService _service;
    private readonly CategoryService _categoryService;
    public CreateModel(SubCategoryService service, CategoryService categoryService)
    {
        _service = service;
        _categoryService = categoryService;
    }


    [BindProperty]
    public SubCategoryDto SubCategoryDto { get; set; }

    public IEnumerable<CategoryDto> CategoryDtos { get; set; }

    public async Task OnGet()
        => CategoryDtos = await _categoryService.FindAll();




    public async Task<IActionResult> OnPostCreate()
    {
        if (string.IsNullOrEmpty(SubCategoryDto.Name) || !ModelState.IsValid)
        {
            ModelState.AddModelError("SubCategoryDto.Name", "The field \"Name\" is required!");
            return Page();
        }
        SubCategoryDto.CreatedDate = DateTime.Now;
        await _service.Create(SubCategoryDto);
        return RedirectToPage("/SubCategories/Index");
    }
}
