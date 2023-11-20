using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using UIRSHOP.BL.Models.Dtos.SupplierDtos;
using UIRSHOP.WEB.BO.Services;

namespace UIRSHOP.WEB.BO.Pages.Suppliers;

public class CreateModel : PageModel
{
    private readonly SupplierService _service;
    private readonly IWebHostEnvironment _env;
    public CreateModel(SupplierService service, IWebHostEnvironment env)
    {
        _service = service;
        _env = env;
    }


    [BindProperty]
    public SupplierDto SupplierDto { get; set; }




    public async Task<IActionResult> OnPostCreate()
    {
        SupplierDto.ImagePath = await InsertImagesAsync();
        if (string.IsNullOrEmpty(SupplierDto.Name) || !ModelState.IsValid)
        {
            ModelState.AddModelError("SupplierDto.Name", "The field \"Name\" is required!");
            return Page();
        }

        await _service.Create(SupplierDto);
        return RedirectToPage("/Suppliers/Index");
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
                var filePath = Path.Combine(_env.WebRootPath, "images", "suppliers", fileName);

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
