using BeautyCenterCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenterCore.BLL
{
    public class DetalleCitasBLL
    {
        public static bool Guardar(CitasDetalles detalle)
        {
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    conexion.CitasDetalles.Add(detalle);
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

        public static bool Modificar(CitasDetalles detalle)
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
                        return Guardar(detalle);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }
        public static CitasDetalles Buscar(int nuevoId)
        {
            CitasDetalles ID = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    ID = conexion.CitasDetalles.Find(nuevoId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return ID;
        }
        public static List<CitasDetalles> Listar(int? Id)
        {
            List<CitasDetalles> listado = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    listado = conexion.CitasDetalles.
                        Where(d => d.CitaId == Id).
                        OrderBy(d => d.Id).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }
        public static bool Eliminar(CitasDetalles detalle)
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
        public static List<CitasDetalles> GetLista()
        {
            var lista = new List<CitasDetalles>();
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    lista = conexion.CitasDetalles.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lista;

        }
        public static List<CitasDetalles> GetListaId(int Id)
        {
            List<CitasDetalles> list = new List<CitasDetalles>();
            using (var db = new BeautyCoreDb())
            {
                try
                {
                    list = db.CitasDetalles.Where(p => p.Id == Id).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return list;
        }

        public static bool Guardar(List<CitasDetalles> detalles)
        {
            bool resultado = false;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    foreach (CitasDetalles detail in detalles)
                    {
                        conexion.CitasDetalles.Add(detail);
                        if (conexion.SaveChanges() > 0)
                        {

                            resultado = true;
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static bool Modificar(List<CitasDetalles> detalles, int Id)
        {
            bool resultado = false;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    //si no esta vacio
                    List<CitasDetalles> inFacturas = conexion.CitasDetalles.Where(d => d.CitaId == Id).ToList();
                    List<CitasDetalles> estaEnArreglo = new List<CitasDetalles>();
                    if (inFacturas.Count > 0)
                    {
                        foreach (CitasDetalles detail in detalles)
                        {

                            foreach (var f in inFacturas)
                            {
                                if (detail.Id == f.Id)
                                {
                                    estaEnArreglo.Add(f);
                                }
                            }
                        }
                        foreach (var d in estaEnArreglo)
                        {


                            conexion.Entry(d).State = EntityState.Modified;
                            conexion.SaveChanges();

                        }
                        foreach (var e in inFacturas)
                        {
                            bool found = false;

                            foreach (var inf in detalles)
                            {
                                if (e.Id == inf.Id)
                                {
                                    found = true;
                                    break;
                                }

                            }
                            if (!found)
                            {
                                conexion.CitasDetalles.Remove(e);
                                conexion.SaveChanges();
                            }
                        }

                        resultado = true;

                    }
                    else
                    {
                        foreach (var d in detalles)
                        {
                            conexion.CitasDetalles.Add(d);
                            conexion.SaveChanges();
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return resultado;
            }
        }
        public static bool Eliminar(List<CitasDetalles> detalles)
        {
            bool resultado = false;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    foreach (var detail in detalles)
                    {
                        conexion.Entry(detail).State = EntityState.Deleted;
                        conexion.SaveChanges();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return resultado;
            }
        }
    }
}
