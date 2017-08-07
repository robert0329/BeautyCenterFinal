using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenterCore.Models
{
    public class Citas
    {
        [Key]
        public int CitaId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        
        public DateTime Fecha { get; set; }
    }
}
