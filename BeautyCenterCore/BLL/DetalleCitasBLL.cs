using BeautyCenterCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenterCore.BLL
{
    public class DetalleCitasBLL
    {
        public static bool Insertar(List<CitasDetalles> detalles)
        {
            bool resultado = false;
            using (var db = new BeautyCoreDb())
            {
                try
                {
                    foreach (CitasDetalles detail in detalles)
                    {
                        db.CitasDetalles.Add(detail);
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
                    list = db.CitasDetalles.Where(p => p.ClienteId == Id).ToList();
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
