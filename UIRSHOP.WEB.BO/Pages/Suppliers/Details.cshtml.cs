using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UIRSHOP.BL.Models.Dtos.SupplierDtos;
using UIRSHOP.DAL;
using UIRSHOP.WEB.BO.Services;

namespace UIRSHOP.WEB.BO.Pages.Suppliers;

public class DetailsModel : PageModel
{
    private readonly SupplierService _service;
    private readonly IWebHostEnvironment _env;

    public DetailsModel(SupplierService service, IWebHostEnvironment env)
    {
        _service = service;
        _env = env;
    }

    [BindProperty]
    public SupplierDto SupplierDto { get; set; }



    public async Task OnGet(int id)
        => SupplierDto = await _service.Find(id);


    public async Task<IActionResult> OnPostUpdate()
    {
        if (string.IsNullOrEmpty(SupplierDto.Name) || !ModelState.IsValid)
        {
            ModelState.AddModelError("SupplierDto.Name", "The field \"Name\" is required!");
            return Page();
        }
        var imagePath = await InsertImagesAsync();
        SupplierDto.ImagePath = imagePath ?? SupplierDto.ImagePath;
        await _service.Update(SupplierDto.Id, SupplierDto);
        return RedirectToPage("/Suppliers/Index");
    }


    public async Task<IActionResult> OnPostDelete()
    {
        await _service.Delete(SupplierDto.Id);
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
