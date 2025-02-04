using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaShared
{
    public class ClientDTO
    {
        public Guid Id { get; set; }
        public required string name { get; set; }
        public required string email { get; set; }

        public string? phone { get; set; }
    }
}
