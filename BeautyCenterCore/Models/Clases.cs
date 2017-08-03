using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenterCore.Models
{
    public class Clases
    {
        public Facturas Encabezado { get; set; }

        public List<FacturaDetalles> Detalle { get; set; }

        public Clases()
        {
            Detalle = new List<FacturaDetalles>();
        }
    }
}
