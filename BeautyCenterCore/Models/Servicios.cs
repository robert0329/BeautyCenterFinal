using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenterCore.Models
{
    public class Servicios
    {
        [Key]
        public int ServicioId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio y de suma importancia")]
        public double Precio { get; set; }
    }
}
