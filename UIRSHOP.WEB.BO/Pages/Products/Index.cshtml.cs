using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UIRSHOP.BL.Models.Dtos.ProductDtos;
using UIRSHOP.BL.Models.Dtos.CategoryDtos;
using UIRSHOP.WEB.BO.Services;
using UIRSHOP.BL.Models.Dtos.SupplierDtos;

namespace UIRSHOP.WEB.BO.Pages.Products;

public class IndexModel : PageModel
{
    private readonly ProductService _serviceP;
    private readonly CategoryService _serviceC;
    private readonly SupplierService _serviceS;
    public IndexModel(ProductService serviceP, CategoryService serviceC, SupplierService serviceS)
    {
        _serviceP = serviceP;
        _serviceC = serviceC;
        _serviceS = serviceS;
    }
    public IEnumerable<ProductDto> ProductDtos { get; set; }
    public IEnumerable<CategoryDto> CategoryDtos { get; set; }
    public IEnumerable<SupplierDto> SupplierDtos { get; set; }
    public async Task OnGet()
    {
        ProductDtos = await _serviceP.FindAll();
        CategoryDtos = await _serviceC.FindAll();
        SupplierDtos = await _serviceS.FindAll();
    }
}
