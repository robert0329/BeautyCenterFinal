using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenterCore.Models
{
    public class CitasDetalles
    {
        [Key]
        public int Id { get; set; }

        public int CitaId { get; set; }

        public int ClienteId { get; set; }

        public int ServicioId { get; set; }

        public int EmpleadoId { get; set; }
    }
}
    