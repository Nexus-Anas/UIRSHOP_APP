using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UIRSHOP.BL.Models.Dtos.CategoryDtos;
using UIRSHOP.WEB.BO.Services;

namespace UIRSHOP.WEB.BO.Pages.Categories;

public class DetailsModel : PageModel
{
    private readonly CategoryService _service;
    public DetailsModel(CategoryService service) => _service = service;



    [BindProperty]
    public CategoryDto CategoryDto { get; set; }




    public async Task OnGet(int id)
        => CategoryDto = await _service.Find(id);



    public async Task<IActionResult> OnPostUpdate()
    {
        if (string.IsNullOrEmpty(CategoryDto.Name) || !ModelState.IsValid)
        {
            ModelState.AddModelError("CategoryDto.Name", "The field \"Name\" is required!");
            return Page();
        }
        CategoryDto.UpdatedDate = DateTime.Now;
        await _service.Update(CategoryDto.Id, CategoryDto);
        return RedirectToPage("/Categories/Index");
    }


    public async Task<IActionResult> OnPostDelete()
    {
        await _service.Delete(CategoryDto.Id);
        return RedirectToPage("/Categories/Index");
    }
}
