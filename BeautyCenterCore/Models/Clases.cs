using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenterCore.Models
{
    public class Clases
    {
        public Citas variable { get; set; }

        public List<CitasDetalles> Detalle { get; set; }

        public Clases()
        {
            Detalle = new List<CitasDetalles>();
        }
    }
}
