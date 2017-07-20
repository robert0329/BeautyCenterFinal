using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeautyCenterCore.Models;

namespace BeautyCenterCore.Models
{
    public class BeautyCoreDb : DbContext
    {
        public BeautyCoreDb (DbContextOptions<BeautyCoreDb> options)
            : base(options)
        {
        }

        public DbSet<BeautyCenterCore.Models.Citas> Citas { get; set; }

        public DbSet<BeautyCenterCore.Models.Clientes> Clientes { get; set; }

        public DbSet<BeautyCenterCore.Models.Empleados> Empleados { get; set; }

        public DbSet<BeautyCenterCore.Models.Servicios> Servicios { get; set; }
    }
}
