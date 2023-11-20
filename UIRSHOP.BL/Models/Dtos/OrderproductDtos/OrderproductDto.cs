using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIRSHOP.BL.Models.Dtos.OrderproductDtos
{
    public class OrderproductDto
    {
        public int Id { get; set; }

        public int Qty { get; set; }

        public int ProductId { get; set; }

        public int CategoryId { get; set; }
    }
}
