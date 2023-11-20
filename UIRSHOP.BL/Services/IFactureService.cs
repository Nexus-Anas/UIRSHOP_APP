using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.Models.Dtos.FactureDto;

namespace UIRSHOP.BL.Services
{
    public interface IFactureService
    {
        Task<FactureDto> CreateFacture(FactureDto entity);
        Task<FactureDto> GetFacture(int id);
        Task<IEnumerable<FactureDto>> GetAllFactures();
        Task<FactureDto> UpdateFacture(int id, FactureDto entity);
        Task DeleteFacture(int id);
    }
}
