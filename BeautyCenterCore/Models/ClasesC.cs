using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenterCore.Models
{
    public class ClasesC
    {
        public Citas Encabezado { get; set; }

        public List<CitasDetalles> Detalle { get; set; }

        public ClasesC()
        {
            Detalle = new List<CitasDetalles>();
        }
    }
}
