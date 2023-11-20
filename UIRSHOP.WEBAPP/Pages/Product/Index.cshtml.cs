using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UIRSHOP.DAL;
using UIRSHOP.WEBAPP.Services;

using M = UIRSHOP.BL.Models.Dtos;

namespace UIRSHOP.WEBAPP.Pages.Product
{
    public class IndexModel : PageModel
    {
		

		
		private readonly ILogger<IndexModel> _logger;
		private readonly Services.ProductService _product;

		private readonly SupplierService _supplier;

		public IndexModel(SupplierService supplierService,ILogger<IndexModel> logger, Services.ProductService product)
		{
			_logger = logger;
			_product = product;
	
			_supplier = supplierService;
		}
		public int productCount;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public M.ProductDtos.ProductDto product { get; set; }
        public IEnumerable<M.SupplierDtos.SupplierDto> Suppliers { get; set; }
        public async Task OnGetAsync()
		{
			 product = await _product.Find(Id);
			Suppliers = await _supplier.FindAll();
			 
			



		}
	}
}
