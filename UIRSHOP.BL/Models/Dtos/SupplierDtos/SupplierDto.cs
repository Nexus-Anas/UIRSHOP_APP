using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIRSHOP.BL.Models.Dtos.SupplierDtos
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? ImagePath { get; set; }

        public string Type { get; set; }

        public string? FacebookUrl { get; set; }

        public string? TwitterUrl { get; set; }

        public string? InstagramUrl { get; set; }

        public string? TikTokUrl { get; set; }
    }
}
