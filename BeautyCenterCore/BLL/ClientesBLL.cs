using BeautyCenterCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeautyCenterCore.BLL
{
    public class ClientesBLL
    {
        public static bool Guardar(Clientes cliente)
        {
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    conexion.Clientes.Add(cliente);
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
        public static Clientes Buscar(int? clienteId)
        {
            Clientes cliente = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    cliente =  conexion.Clientes.Find(clienteId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return cliente;
        }
        public static bool Modificar(Clientes cliente)
        {
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    conexion.Entry(cliente).State = EntityState.Modified;
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
        public static bool Eliminar(Clientes cliente)
        {
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    conexion.Entry(cliente).State = EntityState.Deleted;
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
        public static List<Clientes> Listar()
        {
            List<Clientes> listado = null;
            using (var conexion = new BeautyCoreDb())
            {
                try
                {
                    listado = conexion.Clientes.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }

        public static bool Eliminar(int? clienteId)
        {
            try
            {
                return Eliminar(Buscar(clienteId));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}