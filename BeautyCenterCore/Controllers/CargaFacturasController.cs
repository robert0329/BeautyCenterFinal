using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeautyCenterCore.Models;
using BeautyCenterCore.BLL;

namespace BeautyCenterCore.Controllers
{
    public class CargaFacturasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ServiciosFacturas(int id)
        {
            var listado = BLL.ServiciosBLL.ListarId(id);

            return Json(listado);
        }
        [HttpGet]
        public JsonResult ListaServiciosFacturas(int id)
        {
            var listado = BLL.ServiciosBLL.Listar();

            return Json(listado);
        }
        [HttpGet]
        public JsonResult ListaClientesFacturas(int id)
        {
            var listado = BLL.ClientesBLL.Listar();

            return Json(listado);
        }
        [HttpGet]
        public JsonResult ListaEmpleadosFacturas(int id)
        {
            var listado = BLL.EmpleadosBLL.Listar();

            return Json(listado);
        }
        [HttpPost]
        public JsonResult GuardarFacturas(Facturas nueva)
        {
            int id = 0;
            if (ModelState.IsValid)
            {
                if (FacturasBLL.Guardar(nueva))
                {
                    id = nueva.FacturaId;
                }
            }
            return Json(id);
        }
        [HttpPost]
        public JsonResult GuardarDetalleFacturas([FromBody]List<FacturaDetalles> detalles)
        {
            bool resultado = BLL.FacturaDetallesBLL.Insertar(detalles);

            return Json(resultado);
        }
        
    }
}
