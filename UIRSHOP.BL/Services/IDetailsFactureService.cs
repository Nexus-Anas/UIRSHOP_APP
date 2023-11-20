using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.Models.Dtos.DetailsFactureDto;

namespace UIRSHOP.BL.Services
{
    public interface IDetailsFactureService
    {
        Task<DetailsFactureDto> CreateDetailsFacture(DetailsFactureDto entity);
        Task<DetailsFactureDto> GetDetailsFacture(int id);
        Task<IEnumerable<DetailsFactureDto>> GetAllDetailsFactures();
        Task<DetailsFactureDto> UpdateDetailsFacture(int id, DetailsFactureDto entity);
        Task DeleteDetailsFacture(int id);
    }
}
