using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaShared
{
    public class ProductDTO
    {
        [Required]
        public required string name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser positivo.")]
        public decimal price { get; set; }
        public int stock { get; set; }
    }
}
