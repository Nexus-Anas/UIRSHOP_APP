using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.Models.Dtos.OrderproductDtos;

namespace UIRSHOP.BL.Services
{
    public interface IOrderproductService
    {
        Task<OrderproductDto> CreateOrderproduct(OrderproductDto entity);
        Task<OrderproductDto> GetOrderproduct(int id);
        Task<IEnumerable<OrderproductDto>> GetAllOrderproducts();
        Task<OrderproductDto> UpdateOrderproduct(int id, OrderproductDto entity);
        Task DeleteOrderproduct(int id);
    }
}
