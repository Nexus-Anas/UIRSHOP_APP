using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.Models.Dtos.ClientDtos;

namespace UIRSHOP.BL.Services
{
    public interface IClientService
    {
        Task<ClientDto> CreateClient(ClientDto entity);
        Task<ClientDto> GetClient(int id);
        Task<IEnumerable<ClientDto>> GetAllClients();
        Task<ClientDto> UpdateClient(int id, ClientDto entity);
        Task DeleteClient(int id);

    }
}
