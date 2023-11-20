using AutoMapper;
using UIRSHOP.BL.IRepositories;
using UIRSHOP.BL.Models.Dtos.OrderproductDtos;
using UIRSHOP.DAL;

namespace UIRSHOP.BL.Services
{
    public class OrderproductService: IOrderproductService
    {
        private readonly IGenericRepository<Orderproduct> _repo;
        private readonly IMapper _mapper;
        public OrderproductService(IGenericRepository<Orderproduct> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<OrderproductDto> CreateOrderproduct(OrderproductDto entity)
        {
            var orderProduct = _mapper.Map<OrderproductDto, Orderproduct>(entity);
            var createdOrderProduct = await _repo.Post(orderProduct);
            return _mapper.Map<Orderproduct, OrderproductDto>(createdOrderProduct);
        }

        public async Task DeleteOrderproduct(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<IEnumerable<OrderproductDto>> GetAllOrderproducts()
        {
            var orderProducts = await _repo.GetAll();

            return _mapper.Map<IEnumerable<Orderproduct>, IEnumerable<OrderproductDto>>(orderProducts);
        }

        public async Task<OrderproductDto> GetOrderproduct(int id)
        {
            var orderProduct = await _repo.Get(id);

            if (orderProduct == null)
            {
                return null;
            }

            return _mapper.Map<Orderproduct, OrderproductDto>(orderProduct);
        }

        public async Task<OrderproductDto> UpdateOrderproduct(int id, OrderproductDto entity)
        {
            var existingOrderProduct = await _repo.Get(id);

            if (existingOrderProduct == null)
            {
                return null;
            }

            // Map from the ClientDto to the existing Client entity
            _mapper.Map(entity, existingOrderProduct);

            var updatedOrderProduct = await _repo.Update(id, existingOrderProduct);

            return _mapper.Map<Orderproduct, OrderproductDto>(updatedOrderProduct);
        }
    }
}
