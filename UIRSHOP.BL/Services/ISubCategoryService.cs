using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.Models.Dtos.SubCategory;
using UIRSHOP.DAL;

namespace UIRSHOP.BL.Services
{
    public interface ISubCategoryService
    {
        Task<SubCategoryDto> GetSubCategory(int id);
        Task<IEnumerable<SubCategoryDto>> GetAllSubCategories();
        Task<SubCategoryDto> CreateSubCategory(SubCategoryDto entityDto);
        Task<SubCategoryDto> UpdateSubCategory(int id, SubCategoryDto entityDto);
        Task DeleteSubCategory(int id);
    }
}
