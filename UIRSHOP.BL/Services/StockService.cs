using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.IRepositories;
using UIRSHOP.BL.Models.Dtos.StockDtos;
using UIRSHOP.DAL;

namespace UIRSHOP.BL.Services
{
    public class StockService: IStockService
    {
        private readonly IGenericRepository<Stock> _repo;
        private readonly IMapper _mapper;
        public StockService(IGenericRepository<Stock> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<StockDto> CreateStock(StockDto entity)
        {
            var stock = _mapper.Map<StockDto, Stock>(entity);
            var createdStock = await _repo.Post(stock);
            return _mapper.Map<Stock, StockDto>(createdStock);

        }

        public async Task DeleteStock(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<IEnumerable<StockDto>> GetAllStocks()
        {
            var stocks = await _repo.GetAll();

            return _mapper.Map<IEnumerable<Stock>, IEnumerable<StockDto>>(stocks);
        }

        public async Task<StockDto> GetStock(int id)
        {
            var stock = await _repo.Get(id);

            if (stock == null)
            {
                return null;
            }

            return _mapper.Map<Stock, StockDto>(stock);
        }

        public async Task<StockDto> UpdateStock(int id, StockDto entity)
        {
            var existingStock = await _repo.Get(id);

            if (existingStock == null)
            {
                return null;
            }

            // Map from the ClientDto to the existing Client entity
            _mapper.Map(entity, existingStock);

            var updatedStock = await _repo.Update(id, existingStock);

            return _mapper.Map<Stock, StockDto>(updatedStock);
        }
    }

}

