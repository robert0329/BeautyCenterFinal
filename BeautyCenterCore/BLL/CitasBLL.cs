using BeautyCenterCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenterCore.BLL
{
    public class CitasBLL
    {
        public static bool Guardar(Citas nuevo)
        {
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    conexion.Citas.Add(nuevo);
                    if (conexion.SaveChanges() > 0)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }
        public static Citas Buscarr(int? nuevoId)
        {
            Citas cliente = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    cliente = conexion.Citas.Find(nuevoId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return cliente;
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
        public static Clases Buscar(int? facturaId)
        {
            Clases nuevo = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    nuevo = new Clases()
                    {
                        variable = conexion.Citas.Find(facturaId)
                    };
                    if (nuevo.variable != null)
                    {
                        nuevo.Detalle =
                        BLL.DetalleCitasBLL.Listar(nuevo.variable.CitaId);
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
