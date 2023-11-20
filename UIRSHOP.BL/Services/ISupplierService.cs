using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.Models.Dtos.SupplierDtos;

namespace UIRSHOP.BL.Services
{
    public interface ISupplierService
    {
        Task<SupplierDto> CreateSupplier(SupplierDto entity);
        Task<SupplierDto> GetSupplier(int id);
        Task<IEnumerable<SupplierDto>> GetAllSuppliers();
        Task<SupplierDto> UpdateSupplier(int id, SupplierDto entity);
        Task DeleteSupplier(int id);
    }
}
