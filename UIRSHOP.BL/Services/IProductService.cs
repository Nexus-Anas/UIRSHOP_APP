using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.Models.Dtos.ProductDtos;
using UIRSHOP.DAL;

namespace UIRSHOP.BL.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetProduct(int id);
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> CreateProduct(ProductDto entity);
        Task<ProductDto> UpdateProduct(int id, ProductDto entity);
        Task DeleteProduct(int id);
    }
}