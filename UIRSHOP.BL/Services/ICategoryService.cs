using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.Models.Dtos.CategoryDtos;

namespace UIRSHOP.BL.Services
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateCategory(CategoryDto entity);
        Task<CategoryDto> GetCategory(int id);
        Task<IEnumerable<CategoryDto>> GetAllCategories();
        Task<CategoryDto> UpdateCategory(int id, CategoryDto entity);
        Task DeleteCategory(int id);

    }
}
