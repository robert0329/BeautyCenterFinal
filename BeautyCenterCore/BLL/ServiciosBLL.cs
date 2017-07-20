using BeautyCenterCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BeautyCenterCore.BLL
{
    public class ServiciosBLL
    {
        public static bool Guardar(Servicios nuevo)
        {
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    conexion.Servicios.Add(nuevo);
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
        public static Servicios Buscar(int? nuevoId)
        {
            Servicios cliente = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    cliente = conexion.Servicios.Find(nuevoId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return cliente;
        }
        public static bool Modificar(Servicios nuevo)
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
        public static bool Eliminar(Servicios nuevo)
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
        public static List<Servicios> Listar()
        {
            List<Servicios> listado = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    listado = conexion.Servicios.ToList();
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