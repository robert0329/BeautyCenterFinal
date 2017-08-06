using BeautyCenterCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenterCore.BLL
{
    public class CitasBLL
    {
        
        public static bool Guardar(ClasesC nuevo)
        {
            bool resultado = false;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    conexion.Citas.Add(nuevo.Encabezado);
                    if (conexion.SaveChanges() > 0)
                    {
                        resultado = BLL.DetalleCitasBLL.Guardar(nuevo.Detalle);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static Citas BuscarEncabezado(int? Id)
        {
            Citas nuevo = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    nuevo = conexion.Citas.Find(Id);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return nuevo;
        }
        public static int Identity()
        {
            int identity = 0;
            string con =
            @"Server=tcp:personasserver.database.windows.net,1433;Initial Catalog=BaseDatos;Persist Security Info=False;User ID=dante0329;Password=Onepiece29;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            using (SqlConnection conexion = new SqlConnection(con))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("SELECT IDENT_CURRENT('Citas')", conexion);
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
        public static Citas Buscar(int nuevoId)
        {
            Citas ID = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    ID = conexion.Citas.Find(nuevoId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return ID;
        }
        public static ClasesC Buscarr(int? Id)
        {
            ClasesC nuevo = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    nuevo = new ClasesC()
                    {
                        Encabezado = conexion.Citas.Find(Id)
                    };
                    if (nuevo.Encabezado != null)
                    {
                        nuevo.Detalle = BLL.DetalleCitasBLL.Listar(nuevo.Encabezado.CitaId);
                    }
                    else
                    {
                        nuevo = null;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return nuevo;
        }
        public static bool Modificar(ClasesC nuevo)
        {
            bool resultado = false;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    conexion.Entry(nuevo.Encabezado).State = EntityState.Modified;
                    if (conexion.SaveChanges() > 0)
                    {
                        resultado = BLL.DetalleCitasBLL.Modificar(nuevo.Detalle,nuevo.Encabezado.CitaId);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static ClasesC Buscar(int? facturaId)
        {
            ClasesC factura = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    factura = new ClasesC()
                    {
                        Encabezado = conexion.Citas.Find(facturaId)
                    };
                    if (factura.Encabezado != null)
                    {
                        factura.Detalle = BLL.DetalleCitasBLL.Listar(factura.Encabezado.CitaId);
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
        public static bool Eliminar(ClasesC nuevo)
        {
            bool resultado = false;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    nuevo = BLL.CitasBLL.Buscarr(nuevo.Encabezado.CitaId);
                    BLL.CitasBLL.Eliminar(nuevo.Encabezado);
                    BLL.DetalleCitasBLL.Eliminar(nuevo.Detalle);

                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static bool Eliminar(Citas nuevo)
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
        public static List<Citas> Listar()
        {
            List<Citas> listado = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    listado = conexion.Citas.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        } 
        public static bool Modificar(Citas nuevo)
        {
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    conexion.Entry(nuevo).State = EntityState.Modified;
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
        public static List<CitasDetalles> ListarId(int Id)
        {
            List<CitasDetalles> list = new List<CitasDetalles>();
            using (var db = new BeautyCoreDb())
            {
                try
                {
                    list = db.CitasDetalles.Where(p => p.ClienteId == Id).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return list;
        }
        public static List<Citas> GetListaFecha(DateTime D, DateTime H)
        {
            List<Citas> lista = new List<Citas>();
            using (var db = new BeautyCoreDb())
            {
                try
                {
                    lista = db.Citas.Where(p => p.Fecha >= D && p.Fecha <= H).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lista;
        }
    }
}
