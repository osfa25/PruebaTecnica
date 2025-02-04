using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace PruebaTecnicaShared
{
    public class InvoiceDTO
    {

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public Guid ClientID { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Total must be a positive value.")]
        public decimal Total { get; set; }

        public ClientDTO? client { get; set; }
    }
}
