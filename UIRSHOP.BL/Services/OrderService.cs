using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.IRepositories;
using UIRSHOP.BL.Models.Dtos.ClientDtos;
using UIRSHOP.BL.Models.Dtos.OrderDtos;
using UIRSHOP.DAL;

namespace UIRSHOP.BL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _repo;
        private readonly IMapper _mapper;
        public OrderService(IGenericRepository<Order> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<OrderDto> CreateOrder(OrderDto entity)
        {
            var order = _mapper.Map<OrderDto, Order>(entity);
            var createdOrder = await _repo.Post(order);
            return _mapper.Map<Order, OrderDto>(createdOrder);

        }

        public async Task DeleteOrder(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<OrderDto> GetOrder(int id)
        {
            var order = await _repo.Get(id);

            if (order == null)
            {
                return null;
            }

            return _mapper.Map<Order, OrderDto>(order);

        }

        public async Task<IEnumerable<OrderDto>> GetAllOrders()
        {
            var orders = await _repo.GetAll();

            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> UpdateOrder(int id, OrderDto entity)
        {
            var existingOrder = await _repo.Get(id);

            if (existingOrder == null)
            {
                return null;
            }

            _mapper.Map(entity, existingOrder);

            var updatedOrder = await _repo.Update(id, existingOrder);

            return _mapper.Map<Order, OrderDto>(updatedOrder);
        }


    }
}

