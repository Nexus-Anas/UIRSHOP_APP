using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIRSHOP.BL.Models.Dtos.DetailsFactureDto
{
    public class DetailsFactureDto
    {
        public int Id { get; set; }

        public int FactureId { get; set; }

        public int ProductId { get; set; }

        public decimal ProductPu { get; set; }

        public int ProductQty { get; set; }
    }
}
