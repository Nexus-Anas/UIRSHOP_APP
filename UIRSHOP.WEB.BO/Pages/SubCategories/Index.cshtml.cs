using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UIRSHOP.BL.Models.Dtos.SubCategory;
using UIRSHOP.WEB.BO.Services;

namespace UIRSHOP.WEB.BO.Pages.SubCategories;

public class IndexModel : PageModel
{
    private readonly SubCategoryService _service;
    public IndexModel(SubCategoryService service) => _service = service;


    public IEnumerable<SubCategoryDto> SubCategoryDtos { get; set; }


    public async Task OnGet()
        => SubCategoryDtos = await _service.FindAll();
}
