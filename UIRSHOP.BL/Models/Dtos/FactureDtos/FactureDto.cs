using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIRSHOP.BL.Models.Dtos.FactureDto
{
    public class FactureDto
    {
        public int Id { get; set; }
        public string Num { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public int OrderId { get; set; }
    }
}
