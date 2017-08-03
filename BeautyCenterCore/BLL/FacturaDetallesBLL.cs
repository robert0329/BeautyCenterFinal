﻿using BeautyCenterCore.Models;
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
                        OrderBy(d => d.Id).ToList();
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

        public static bool Guardar(List<FacturaDetalles> detalles)
        {
            bool resultado = false;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    foreach (FacturaDetalles detail in detalles)
                    {
                        conexion.FacturaDetalles.Add(detail);
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
        public static bool Modificar(List<FacturaDetalles> detalles)
        {
            bool resultado = false;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    foreach (FacturaDetalles detail in detalles)
                    {
                        if (Buscar(detail.Id) != null)
                        {
                            conexion.Entry(detail).State = EntityState.Modified;
                            if (conexion.SaveChanges() > 0)
                                resultado = true;
                        }
                        else
                        {
                            conexion.FacturaDetalles.Add(detail);
                            if (conexion.SaveChanges() > 0)
                            {
                                resultado = true;
                            }
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
        public static bool Eliminar(List<FacturaDetalles> detalles)
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
