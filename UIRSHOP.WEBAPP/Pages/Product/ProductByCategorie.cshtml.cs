using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UIRSHOP.WEBAPP.Services;
using M = UIRSHOP.BL.Models.Dtos;
namespace UIRSHOP.WEBAPP.Pages.Product
{
    public class ProductByCategorieModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Services.ProductService _product;
        private readonly CategorieService _category;
        private readonly SubCategoryService _subCategory;

        public ProductByCategorieModel(ILogger<IndexModel> logger, Services.ProductService product, CategorieService category, Services.SubCategoryService subCategory)
        {
            _logger = logger;
            _product = product;
            _category = category;
            _subCategory = subCategory;
        }
        public int productCount;


        public IEnumerable<M.ProductDtos.ProductDto> products { get; set; }
        public IEnumerable<M.CategoryDtos.CategoryDto> categories { get; set; }
        public IEnumerable<M.SubCategory.SubCategoryDto> subCategories { get; set; }
        public IEnumerable<M.ProductDtos.ProductDto> FilteredProducts { get; set; }
        public string MyVariable { get; set; }
        public int idCategory { get; set; }
        public async Task OnGetAsync(string myVariable)
        {
            products = await _product.FindAll();
            categories = await _category.FindAll();
            subCategories = await _subCategory.FindAll();
            MyVariable = myVariable;
            foreach(var item in categories) 
            { 
                if(item.Name == MyVariable)
                {
                    idCategory=item.Id;
                }
            }




        }


       

	
	}
}
