using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.IRepositories;
using UIRSHOP.BL.Models.Dtos.ClientDtos;
using UIRSHOP.DAL;

namespace UIRSHOP.BL.Services
{
    public class ClientService:IClientService
    {
        private readonly IGenericRepository<Client> _repo;
        private readonly IMapper _mapper;
        public ClientService(IGenericRepository<Client> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ClientDto> CreateClient(ClientDto entity)
        {
            var client = _mapper.Map<ClientDto, Client>(entity);
            var createdClient = await _repo.Post(client);
            return _mapper.Map<Client, ClientDto>(createdClient);

        }

        public async Task DeleteClient(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<ClientDto> GetClient(int id)
        {
            var client = await _repo.Get(id);

            if (client == null)
            {
                return null;
            }

            return _mapper.Map<Client, ClientDto>(client);

        }

        public async Task<IEnumerable<ClientDto>> GetAllClients()
        {
            var clients = await _repo.GetAll();

            return _mapper.Map<IEnumerable<Client>, IEnumerable<ClientDto>>(clients);
        }

        public async Task<ClientDto> UpdateClient(int id, ClientDto entity)
        {
            var existingClient = await _repo.Get(id);

            if (existingClient == null)
            {
                return null;
            }

            // Map from the ClientDto to the existing Client entity
            _mapper.Map(entity, existingClient);

            var updatedClient = await _repo.Update(id, existingClient);

            return _mapper.Map<Client, ClientDto>(updatedClient);
        }


    }
}
