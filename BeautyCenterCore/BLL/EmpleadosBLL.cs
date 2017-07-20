using BeautyCenterCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenterCore.BLL
{
    public class EmpleadosBLL
    {
        public static bool Guardar(Empleados nuevo)
        {
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    conexion.Empleados.Add(nuevo);
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
        public static Empleados Buscar(int? nuevoId)
        {
            Empleados cliente = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    cliente = conexion.Empleados.Find(nuevoId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return cliente;
        }
        public static bool Modificar(Empleados nuevo)
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
        public static bool Eliminar(Empleados nuevo)
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
        public static List<Empleados> Listar()
        {
            List<Empleados> listado = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    listado = conexion.Empleados.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }

        public static bool Eliminar(int? nuevoId)
        {
            try
            {
                return Eliminar(Buscar(nuevoId));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
