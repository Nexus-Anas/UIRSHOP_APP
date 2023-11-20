using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIRSHOP.BL.Models.Dtos.ClientDtos
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string? Address { get; set; }

        public string Tel { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

    }
}
