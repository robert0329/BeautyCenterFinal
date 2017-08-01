using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenterCore.Models
{
    public class FacturaDetalles
    {
        [Key]
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int ServicioId { get; set; }
        public string Servicios { get; set; }
        public double Precio { get; set; }
        public double Descuento { get; set; }
        public int Cantidad { get; set; }
        public double SubTotal { get; set; }
    }
}
