using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.IRepositories;
using UIRSHOP.BL.Models.Dtos.DetailsFactureDto;
using UIRSHOP.DAL;

namespace UIRSHOP.BL.Services
{
    public class DetailsFactureService: IDetailsFactureService
    {
        private readonly IGenericRepository<DetailsFacture> _repo;
        private readonly IMapper _mapper;
        public DetailsFactureService(IGenericRepository<DetailsFacture> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<DetailsFactureDto> CreateDetailsFacture(DetailsFactureDto entity)
        {
            var detailsFacture = _mapper.Map<DetailsFactureDto, DetailsFacture>(entity);
            var createdClient = await _repo.Post(detailsFacture);
            return _mapper.Map<DetailsFacture, DetailsFactureDto>(createdClient);
        }

        public async Task DeleteDetailsFacture(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<IEnumerable<DetailsFactureDto>> GetAllDetailsFactures()
        {
            var detailsFactures = await _repo.GetAll();

            return _mapper.Map<IEnumerable<DetailsFacture>, IEnumerable<DetailsFactureDto>>(detailsFactures);
        }

        public async Task<DetailsFactureDto> GetDetailsFacture(int id)
        {
            var detailsFacture = await _repo.Get(id);

            if (detailsFacture == null)
            {
                return null;
            }

            return _mapper.Map<DetailsFacture, DetailsFactureDto>(detailsFacture);
        }

        public async Task<DetailsFactureDto> UpdateDetailsFacture(int id, DetailsFactureDto entity)
        {
            var existingDetailsFacture = await _repo.Get(id);

            if (existingDetailsFacture == null)
            {
                return null;
            }

            // Map from the ClientDto to the existing Client entity
            _mapper.Map(entity, existingDetailsFacture);

            var updatedDetailsFacture = await _repo.Update(id, existingDetailsFacture);

            return _mapper.Map<DetailsFacture, DetailsFactureDto>(updatedDetailsFacture);
        }
    }
}
