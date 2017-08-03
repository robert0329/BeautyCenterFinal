using BeautyCenterCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenterCore.BLL
{
    public class FacturaDetallesBLL
    {
        public static bool Guardar(FacturaDetalles detalle)
        {
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    conexion.FacturaDetalles.Add(detalle);
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
        public static bool Guardar(List<FacturaDetalles> detalles)
        {
            bool resultado = false;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    foreach (FacturaDetalles detail in detalles)
                    {
                        resultado = Guardar(detail);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static bool Insertar(List<FacturaDetalles> detalles)
        {
            bool resultado = false;
            using (var db = new BeautyCoreDb())
            {
                try
                {
                    foreach (FacturaDetalles detail in detalles)
                    {
                        db.FacturaDetalles.Add(detail);
                        db.SaveChanges();
                        resultado = true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static bool Modificar(FacturaDetalles detalle)
        {
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    if (Buscar(detalle.Id) != null)
                    {
                        conexion.Entry(detalle).State = EntityState.Modified;
                        if (conexion.SaveChanges() > 0)
                            return true;
                    }
                    else
                    {
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }
        public static bool Modificar(List<FacturaDetalles> detalles)
        {
            bool resultado = false;
            try
            {
                foreach (FacturaDetalles detail in detalles)
                {
                    resultado = Modificar(detail);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }
        public static FacturaDetalles Buscar(int nuevoId)
        {
            FacturaDetalles ID = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    ID = conexion.FacturaDetalles.Find(nuevoId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return ID;
        }
        public static List<FacturaDetalles> Listar(int? Id)
        {
            List<FacturaDetalles> listado = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    listado = conexion.FacturaDetalles.
                        Where(d => d.FacturaId == Id).
                        OrderBy(d => d.FacturaId).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }
        public static bool Eliminar(FacturaDetalles detalle)
        {
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    conexion.Entry(detalle).State = EntityState.Deleted;
                    conexion.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }
        public static bool Eliminar(List<FacturaDetalles> detalles)
        {
            bool resultado = false;
            try
            {
                foreach (var detail in detalles)
                {
                    resultado = Eliminar(detail);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }
        public static List<FacturaDetalles> GetLista()
        {
            var lista = new List<FacturaDetalles>();
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    lista = conexion.FacturaDetalles.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lista;

        }
        public static List<FacturaDetalles> GetListaId(int Id)
        {
            List<FacturaDetalles> list = new List<FacturaDetalles>();
            using (var db = new BeautyCoreDb())
            {
                try
                {
                    list = db.FacturaDetalles.Where(p => p.Id == Id).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return list;
        }
    }
}
