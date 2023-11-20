using Microsoft.AspNetCore.Mvc.RazorPages;
using UIRSHOP.BL.Models.Dtos.CategoryDtos;
using UIRSHOP.WEB.BO.Services;

namespace UIRSHOP.WEB.BO.Pages.Categories;

public class IndexModel : PageModel
{
    private readonly CategoryService _service;
    public IndexModel(CategoryService service) => _service = service;


    public IEnumerable<CategoryDto> CategoryDtos { get; set; }


    public async Task OnGet()
        => CategoryDtos = await _service.FindAll();
}
