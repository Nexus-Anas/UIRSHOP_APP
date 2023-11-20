using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIRSHOP.BL.Models.Dtos.StockDtos
{
    public class StockDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public int ProductId { get; set; }
    }
}
