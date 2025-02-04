using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaShared
{
    public class InvoiceDetailDTO
    {
        [Required]
        public Guid InvoiceID { get; set; }

        [Required]
        public Guid ProductID { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Unit price must be positive.")]
        public decimal UnitPrice { get; set; }

        [NotMapped]
        public decimal Subtotal => Quantity * UnitPrice;

        public InvoiceDTO? invoice { get; set; }

        public ProductDTO? product { get; set; }
    }
}
