using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UIRSHOP.BL.Models.Dtos.ProductDtos;
using UIRSHOP.BL.Models.Dtos.SupplierDtos;
using UIRSHOP.WEB.BO.Services;

namespace UIRSHOP.WEB.BO.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ProductService _serviceP;
        private readonly SupplierService _serviceS;


        public IndexModel(ILogger<IndexModel> logger, ProductService serviceP, SupplierService serviceS)
        {
            _logger = logger;
            _serviceP = serviceP;
            _serviceS = serviceS;
        }


        public IEnumerable<ProductDto> ProductDtos { get; set; }
        public IEnumerable<SupplierDto> SupplierDtos { get; set; }

        public int ProductCount { get; set; }
        public int SupplierCount { get; set; }

        public async Task OnGet()
        {
            ProductDtos = await _serviceP.FindAll();
            SupplierDtos = await _serviceS.FindAll();
            ProductCount = ProductDtos.Count();
            SupplierCount = SupplierDtos.Count();
        }
    }
}