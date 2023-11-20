using Microsoft.AspNetCore.Mvc.RazorPages;
using UIRSHOP.WEB.BO.Services;
using UIRSHOP.BL.Models.Dtos.SupplierDtos;
using Microsoft.Extensions.Logging;

namespace UIRSHOP.WEB.BO.Pages.Suppliers;

public class IndexModel : PageModel
{
    private readonly SupplierService _service;
    public IndexModel(SupplierService service) => _service = service;




    public IEnumerable<SupplierDto> SupplierDtos { get; set; }


    public async Task OnGet()
        => SupplierDtos = await _service.FindAll();
}
