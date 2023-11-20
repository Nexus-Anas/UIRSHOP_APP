using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.IRepositories;
using UIRSHOP.BL.Models.Dtos.CategoryDtos;
using UIRSHOP.DAL;

namespace UIRSHOP.BL.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly IGenericRepository<Category> _repo;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateCategory(CategoryDto entity)
        {
            var category = _mapper.Map<CategoryDto, Category>(entity);
            var createdCategory = await _repo.Post(category);
            return _mapper.Map<Category, CategoryDto>(createdCategory);
        }

        public async Task DeleteCategory(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<CategoryDto> GetCategory(int id)
        {
            var category = await _repo.Get(id);

            if (category == null)
            {
                return null;
            }

            return _mapper.Map<Category, CategoryDto>(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var categories = await _repo.GetAll();

            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> UpdateCategory(int id, CategoryDto entity)
        {
            var existingCategory = await _repo.Get(id);

            if (existingCategory == null)
            {
                return null;
            }

            // Map from the ClientDto to the existing Client entity
            _mapper.Map(entity, existingCategory);

            var updatedCCategory = await _repo.Update(id, existingCategory);

            return _mapper.Map<Category, CategoryDto>(updatedCCategory);
        }
    }

}

