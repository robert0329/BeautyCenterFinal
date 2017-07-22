using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeautyCenterCore.Models;
using BeautyCenterCore.BLL;

namespace BeautyCenterCore.Controllers
{
    public class CargadorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ServiciosCitas(int id)
        {
            var listado = BLL.ServiciosBLL.ListarId(id);

            return Json(listado);
        }
        [HttpGet]
        public JsonResult ListaServiciosCitas(int id)
        {
            var listado = BLL.ServiciosBLL.Listar();

            return Json(listado);
        }
        [HttpGet]
        public JsonResult ListaClientesCitas(int id)
        {
            var listado = BLL.ClientesBLL.Listar();

            return Json(listado);
        }
        [HttpGet]
        public JsonResult ListaEmpleadosCitas(int id)
        {
            var listado = BLL.EmpleadosBLL.Listar();

            return Json(listado);
        }
        [HttpPost]
        public JsonResult GuardarCitas(Citas nueva)
        {
            int id = 0;
            if (ModelState.IsValid)
            {
                if (CitasBLL.Guardar(nueva))
                {
                    id = nueva.CitaId;
                }
            }
            return Json(id);
        }
        [HttpPost]
        public JsonResult GuardarDetalleCitas([FromBody]List<CitasDetalles> detalles)
        {
            bool resultado = BLL.DetalleCitasBLL.Insertar(detalles);

            return Json(resultado);
        }

        [HttpGet]
        public JsonResult BuscarCitas(int? Id)
        {
            Clases nuevo = BLL.CitasBLL.Buscar(Id);
            if (nuevo != null)
            {
                return Json(nuevo);
            }
            else
            {
                return Json(false);
            }
        }
    }
}
