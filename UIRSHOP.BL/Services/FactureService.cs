using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.IRepositories;
using UIRSHOP.BL.Models.Dtos.FactureDto;
using UIRSHOP.DAL;

namespace UIRSHOP.BL.Services
{
    public class FactureService: IFactureService
    {
        private readonly IGenericRepository<Facture> _repo;
        private readonly IMapper _mapper;
        public FactureService(IGenericRepository<Facture> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<FactureDto> CreateFacture(FactureDto entity)
        {
            var facture = _mapper.Map<FactureDto, Facture>(entity);
            var createdFacture = await _repo.Post(facture);
            return _mapper.Map<Facture, FactureDto>(createdFacture);
        }

        public async Task DeleteFacture(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<FactureDto> GetFacture(int id)
        {
            var facture = await _repo.Get(id);

            if (facture == null)
            {
                return null;
            }

            return _mapper.Map<Facture, FactureDto>(facture);
        }

        public async Task<IEnumerable<FactureDto>> GetAllFactures()
        {
            var factures = await _repo.GetAll();

            return _mapper.Map<IEnumerable<Facture>, IEnumerable<FactureDto>>(factures);
        }

        public async Task<FactureDto> UpdateFacture(int id, FactureDto entity)
        {
            var existingFacture = await _repo.Get(id);

            if (existingFacture == null)
            {
                return null;
            }

            // Map from the ClientDto to the existing Client entity
            _mapper.Map(entity, existingFacture);

            var updatedFacture = await _repo.Update(id, existingFacture);

            return _mapper.Map<Facture, FactureDto>(updatedFacture);
        }

    }
}
