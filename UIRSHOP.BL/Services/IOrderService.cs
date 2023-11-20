using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.Models.Dtos.ClientDtos;
using UIRSHOP.BL.Models.Dtos.OrderDtos;

namespace UIRSHOP.BL.Services
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrder(OrderDto entity);
        Task<OrderDto> GetOrder(int id);
        Task<IEnumerable<OrderDto>> GetAllOrders();
        Task<OrderDto> UpdateOrder(int id, OrderDto entity);
        Task DeleteOrder(int id);
    }
}
