using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BeautyCenterCore.Models;

namespace BeautyCenterCore.Migrations
{
    [DbContext(typeof(BeautyCoreDb))]
    partial class BeautyCoreDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeautyCenterCore.Models.Citas", b =>
                {
                    b.Property<int>("CitaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteId");

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("Nombres");

                    b.HasKey("CitaId");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("BeautyCenterCore.Models.CitasDetalles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CitaId");

                    b.Property<int>("ClienteId");

                    b.Property<string>("Servicio");

                    b.Property<int>("ServicioId");

                    b.HasKey("Id");

                    b.ToTable("CitasDetalles");
                });

            modelBuilder.Entity("BeautyCenterCore.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cedula")
                        .IsRequired();

                    b.Property<string>("Ciudad")
                        .IsRequired();

                    b.Property<string>("Direccion")
                        .IsRequired();

                    b.Property<DateTime>("FechaNac");

                    b.Property<string>("Nombres")
                        .IsRequired();

                    b.Property<string>("Provincia")
                        .IsRequired();

                    b.Property<string>("Telefono")
                        .IsRequired();

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("BeautyCenterCore.Models.Empleados", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cedula")
                        .IsRequired();

                    b.Property<string>("Ciudad")
                        .IsRequired();

                    b.Property<string>("Direccion")
                        .IsRequired();

                    b.Property<DateTime>("FechaNac");

                    b.Property<string>("Nombres")
                        .IsRequired();

                    b.Property<string>("Provincia")
                        .IsRequired();

                    b.Property<double>("SueldoFijo");

                    b.Property<string>("Telefono")
                        .IsRequired();

                    b.HasKey("EmpleadoId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("BeautyCenterCore.Models.FacturaDetalles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cantidad");

                    b.Property<double>("Descuento");

                    b.Property<int>("FacturaId");

                    b.Property<double>("Precio");

                    b.Property<int>("ServicioId");

                    b.Property<string>("Servicios");

                    b.Property<double>("SubTotal");

                    b.HasKey("Id");

                    b.ToTable("FacturaDetalles");
                });

            modelBuilder.Entity("BeautyCenterCore.Models.Facturas", b =>
                {
                    b.Property<int>("FacturaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteId");

                    b.Property<string>("Clientes");

                    b.Property<string>("Empleados");

                    b.Property<DateTime>("Fecha");

                    b.Property<double>("Total");

                    b.HasKey("FacturaId");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("BeautyCenterCore.Models.Servicios", b =>
                {
                    b.Property<int>("ServicioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<double>("Precio");

                    b.HasKey("ServicioId");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("BeautyCenterCore.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellido")
                        .IsRequired();

                    b.Property<string>("ConfirmContraseña");

                    b.Property<string>("Contraseña")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.Property<string>("NombreUsuario")
                        .IsRequired();

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });
        }
    }
}
