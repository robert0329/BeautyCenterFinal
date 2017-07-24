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
        public BeautyCoreDb() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:otroproyecto.database.windows.net,1433;Initial Catalog=BeautyCoreDb;Persist Security Info=False;User ID=yinetjc;Password=C@sa9797;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //"Server=tcp:otroproyecto.database.windows.net,1433;Initial Catalog=BeautyCoreDb;Persist Security Info=False;User ID=yinetjc;Password=C@sa9797;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        }

        public DbSet<BeautyCenterCore.Models.Citas> Citas { get; set; }

        public DbSet<BeautyCenterCore.Models.Clientes> Clientes { get; set; }

        public DbSet<BeautyCenterCore.Models.Empleados> Empleados { get; set; }

        public DbSet<BeautyCenterCore.Models.Servicios> Servicios { get; set; }

        public DbSet<BeautyCenterCore.Models.Usuarios> Usuarios { get; set; }

        public DbSet<BeautyCenterCore.Models.CitasDetalles> CitasDetalles { get; set; }

        public DbSet<BeautyCenterCore.Models.FacturaDetalles> FacturaDetalles { get; set; }
    }
}
