using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.IRepositories;
using UIRSHOP.BL.Models.Dtos.SubCategory;
using UIRSHOP.DAL;

namespace UIRSHOP.BL.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IGenericRepository<SubCategory> _subCategoryRepos;
        private readonly IMapper _mapper;

        public SubCategoryService(IGenericRepository<SubCategory> subCategoryRepos, IMapper mapper)
        {
            _subCategoryRepos = subCategoryRepos;
            _mapper = mapper;
            
        }

        public async Task<SubCategoryDto> CreateSubCategory(SubCategoryDto entityDto)
        {
            var subCategoryEntity = _mapper.Map<SubCategory>(entityDto);
            await _subCategoryRepos.Post(subCategoryEntity);
            var createdSubCategory = _mapper.Map<SubCategoryDto>(subCategoryEntity);
            return createdSubCategory;
        }

        public async Task DeleteSubCategory(int id)
        {
            await _subCategoryRepos.Delete(id);
        }

        public async Task<SubCategoryDto> GetSubCategory(int id)
        {
            var subCategory = await _subCategoryRepos.Get(id);
            return _mapper.Map<SubCategoryDto>(subCategory);
        }

        public async Task<IEnumerable<SubCategoryDto>> GetAllSubCategories()
        {
            var subCategories = await _subCategoryRepos.GetAll();
            return subCategories.Select(subCat => _mapper.Map<SubCategoryDto>(subCat));
        }

        public async Task<SubCategoryDto> UpdateSubCategory(int id, SubCategoryDto entityDto)
        {
            var subCategoryEntity = _mapper.Map<SubCategory>(entityDto);
            await _subCategoryRepos.Update(id, subCategoryEntity);
            return _mapper.Map<SubCategoryDto>(subCategoryEntity);
        }
    }
}
