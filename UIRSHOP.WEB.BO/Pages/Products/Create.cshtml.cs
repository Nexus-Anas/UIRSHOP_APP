using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UIRSHOP.BL.Models.Dtos.ProductDtos;
using UIRSHOP.BL.Models.Dtos.CategoryDtos;
using UIRSHOP.WEB.BO.Services;
using UIRSHOP.BL.Models.Dtos.SupplierDtos;

namespace UIRSHOP.WEB.BO.Pages.Products;

public class CreateModel : PageModel
{
    private readonly ProductService _serviceP;
    private readonly CategoryService _serviceC;
    private readonly SupplierService _serviceS;
    private readonly IWebHostEnvironment _env;
    public CreateModel(ProductService serviceP, CategoryService serviceC, SupplierService serviceS, IWebHostEnvironment env)
    {
        _serviceP = serviceP;
        _serviceC = serviceC;
        _serviceS = serviceS;
        _env = env;
    }


    [BindProperty]
    public ProductDto ProductDto { get; set; }
    public IEnumerable<CategoryDto> CategoryDtos { get; set; }
    public IEnumerable<SupplierDto> SupplierDtos { get; set; }

    public async Task OnGet()
    {
        CategoryDtos = await _serviceC.FindAll();
        SupplierDtos = await _serviceS.FindAll();
    }


    public async Task<IActionResult> OnPostCreate()
    {
        if (string.IsNullOrEmpty(ProductDto.Name) || !ModelState.IsValid)
        {
            ModelState.AddModelError("ProductDto.Name", "The field \"Name\" is required!");
            return Page();
        }
        ProductDto.ImagePath = await InsertImagesAsync();
        await _serviceP.Create(ProductDto);
        return RedirectToPage("/Products/Index");
    }




    private async Task<string> InsertImagesAsync()
    {
        string path = string.Empty;
        try
        {
            var file = HttpContext.Request.Form.Files[0];

            if (file != null)
            {
                var fileName = $"{Guid.NewGuid()}_{file.FileName}";
                var filePath = Path.Combine(_env.WebRootPath, "images", "products", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                    await file.CopyToAsync(stream);

                path = fileName;
            }
        }
        catch (Exception)
        {
            return null;
        }
        return path;
    }
}
