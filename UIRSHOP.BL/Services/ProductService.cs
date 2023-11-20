using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.IRepositories;
using UIRSHOP.BL.Models.Dtos.ProductDtos;
using UIRSHOP.BL.IRepositories;
using UIRSHOP.DAL;

namespace UIRSHOP.BL.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _ProductRepo;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repo, IMapper mapper)
        {
            _ProductRepo = repo;
            _mapper = mapper;
        }


        public async Task<ProductDto> CreateProduct(ProductDto newProduct)
        {
            var productEntity = _mapper.Map<Product>(newProduct);
            await _ProductRepo.Post(productEntity);
            var createdProductDto = _mapper.Map<ProductDto>(productEntity);
            return createdProductDto;
        }


        public async Task DeleteProduct(int id)
        {
             await _ProductRepo.Delete(id);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var products = await _ProductRepo.GetAll();

            return products.Select(product => _mapper.Map<ProductDto>(product));
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            var product=  await _ProductRepo.Get(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProduct(int id, ProductDto entity)
        {
            Product product = _mapper.Map<Product>(entity);
            await _ProductRepo.Update(id, product);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
