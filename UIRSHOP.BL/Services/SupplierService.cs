using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.IRepositories;
using UIRSHOP.BL.Models.Dtos.SupplierDtos;
using UIRSHOP.DAL;

namespace UIRSHOP.BL.Services
{
    public class SupplierService: ISupplierService
    {
        private readonly IGenericRepository<Supplier> _repo;
        private readonly IMapper _mapper;
        public SupplierService(IGenericRepository<Supplier> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<SupplierDto> CreateSupplier(SupplierDto entity)
        {
            var supplier = _mapper.Map<SupplierDto, Supplier>(entity);
            var createdSupplier = await _repo.Post(supplier);
            return _mapper.Map<Supplier, SupplierDto>(createdSupplier);
        }

        public async Task DeleteSupplier(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<SupplierDto> GetSupplier(int id)
        {
            var supplier = await _repo.Get(id);

            if (supplier == null)
            {
                return null;
            }

            return _mapper.Map<Supplier, SupplierDto>(supplier);
        }

        public async Task<IEnumerable<SupplierDto>> GetAllSuppliers()
        {
            var suppliers = await _repo.GetAll();

            return _mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDto>>(suppliers);
        }

        public async Task<SupplierDto> UpdateSupplier(int id, SupplierDto entity)
        {
            var existingSupplier = await _repo.Get(id);

            if (existingSupplier == null)
            {
                return null;
            }

            // Map from the ClientDto to the existing Client entity
            _mapper.Map(entity, existingSupplier);

            var updatedSupplier = await _repo.Update(id, existingSupplier);

            return _mapper.Map<Supplier, SupplierDto>(updatedSupplier);
        }
    }

}

