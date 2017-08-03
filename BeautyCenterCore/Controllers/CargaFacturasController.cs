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
        public JsonResult Buscar(int facturaId)
        {
             Facturas factura = BLL.FacturasBLL.Buscar(facturaId);
                return Json(factura);
        }
        [HttpGet]
        public JsonResult BuscarF(int facturaId)
        {
            var factura = BLL.FacturasBLL.Listar();
            return Json(factura);
        }
        [HttpGet]
        public JsonResult BuscarClientes(int? clienteId)
        {
            var cliente = BLL.ClientesBLL.Buscar(clienteId);
            return Json(cliente);
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
        public JsonResult GuardarFacturas(Clases nueva)
        {
            bool resultado = false;
            if (ModelState.IsValid)
            {
               resultado = FacturasBLL.Guardar(nueva);
            }
            return Json(resultado);
        }
        [HttpPost]
        public JsonResult GuardarDetalleFacturas([FromBody]List<FacturaDetalles> detalles)
        {
            bool resultado = BLL.FacturaDetallesBLL.Insertar(detalles);

            return Json(resultado);
        }
    }
}
