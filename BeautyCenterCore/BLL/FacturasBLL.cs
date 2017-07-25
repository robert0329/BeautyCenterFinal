using BeautyCenterCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenterCore.BLL
{
    public class FacturasBLL
    {

        public static bool Guardar(Facturas nuevo)
        {
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    conexion.Facturas.Add(nuevo);
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
        public static Facturas Buscarr(int? nuevoId)
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

        public static bool Modificar(Facturas nuevo)
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
