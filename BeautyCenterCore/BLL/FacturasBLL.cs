using BeautyCenterCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenterCore.BLL
{
    public class FacturasBLL
    {
        public static int Identity()
        {
            int identity = 0;
            string con =
            @"Data Source=ROBERT\SERVIDORES;Initial Catalog=Db;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection conexion = new SqlConnection(con))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("SELECT IDENT_CURRENT('Facturas')", conexion);
                    identity = Convert.ToInt32(comando.ExecuteScalar());
                    conexion.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return identity;
        }
        public static bool Guardar(Clases factura)
        {
            bool resultado = false;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    conexion.Facturas.Add(factura.Encabezado);
                    if (conexion.SaveChanges() > 0)
                    {
                        resultado = BLL.FacturaDetallesBLL.Guardar(factura.Detalle);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static Facturas BuscarEncabezado(int? facturaId)
        {
            Facturas factura = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    factura = conexion.Facturas.Find(facturaId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return factura;
        }
        public static Facturas Buscar(int nuevoId)
        {
            Facturas ID = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    ID = conexion.Facturas.Find(nuevoId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return ID;
        }       
        public static Clases Buscarr(int? facturaId)
        {
            Clases factura = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    factura = new Clases()
                    {
                        Encabezado = conexion.Facturas.Find(facturaId)
                    };
                    if (factura.Encabezado != null)
                    {
                        factura.Detalle =BLL.FacturaDetallesBLL.Listar(factura.Encabezado.FacturaId);
                    }
                    else
                    {
                        factura = null;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return factura;
        }
        public static bool Modificar(Clases factura)
        {
            bool resultado = false;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    conexion.Entry(factura.Encabezado).State = EntityState.Modified;
                    if (conexion.SaveChanges() > 0)
                    {
                        resultado = BLL.FacturaDetallesBLL.Modificar(factura.Detalle);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static bool Eliminar(Clases factura)
        {
            bool resultado = false;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    factura = BLL.FacturasBLL.Buscarr(factura.Encabezado.FacturaId);
                    BLL.FacturasBLL.Eliminar(factura.Encabezado);
                    BLL.FacturaDetallesBLL.Eliminar(factura.Detalle);
                    
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static bool Eliminar(Facturas nuevo)
        {
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    conexion.Entry(nuevo).State = EntityState.Deleted;
                    if (conexion.SaveChanges() > 0)
                        return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }
        public static List<Facturas> Listar()
        {
            List<Facturas> listado = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    listado = conexion.Facturas.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }
       
    }
}
