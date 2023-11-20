using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIRSHOP.BL.Models.Dtos.StockDtos;

namespace UIRSHOP.BL.Services
{
    public interface IStockService
    {
        Task<StockDto> CreateStock(StockDto entity);
        Task<StockDto> GetStock(int id);
        Task<IEnumerable<StockDto>> GetAllStocks();
        Task<StockDto> UpdateStock(int id, StockDto entity);
        Task DeleteStock(int id);
    }
}
