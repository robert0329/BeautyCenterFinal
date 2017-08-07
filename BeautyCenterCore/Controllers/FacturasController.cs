using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeautyCenterCore.Models;
using Microsoft.AspNetCore.Authorization;

namespace BeautyCenterCore.Controllers
{
    [Authorize(ActiveAuthenticationSchemes = "CookiePolicy")]
    public class FacturasController : Controller
    {
        private readonly BeautyCoreDb _context;

        public FacturasController(BeautyCoreDb context)
        {
            _context = context;    
        }
        [HttpGet]
        public JsonResult Buscar(int Id)
        {
            Facturas factura = BLL.FacturasBLL.Buscar(Id);
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
            var listado = BLL.CitasBLL.Listar(id);

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
                DateTime now = DateTime.Now;
                int y, m, d, h, min, s;
                y = nueva.Encabezado.Fecha.Year;
                m = nueva.Encabezado.Fecha.Month;
                d = nueva.Encabezado.Fecha.Day;
                h = now.Hour;
                min = now.Minute;
                s = now.Second;
                nueva.Encabezado.Fecha = new DateTime(y, m, d, h, min, s);

                resultado = BLL.FacturasBLL.Guardar(nueva);
            }
            return Json(resultado);
        }
        [HttpPost]
        public JsonResult Modificar(Clases factura)
        {
            var existe = (BLL.FacturasBLL.Buscarr(factura.Encabezado.FacturaId) != null);
            if (existe)
            {
                existe = BLL.FacturasBLL.Modificar(factura);
                return Json(existe);
            }
            else
            {
                return Json(null);
            }
        }
        [HttpGet]
        public JsonResult LastIndex()
        {
            int id = BLL.FacturasBLL.Identity();
            if (id > 1 || BLL.FacturasBLL.Listar().Count > 0)
                ++id;
            return Json(id);
        }
        [HttpPost]
        public JsonResult Eliminar(Clases factura)
        {
            var existe = (BLL.FacturasBLL.BuscarEncabezado(factura.Encabezado.FacturaId) != null);

            if (existe)
            {
                existe = BLL.FacturasBLL.Eliminar(factura);
                return Json(existe);
            }
            else
            {
                return Json(null);
            }
        }
        // GET: Facturas
        public IActionResult Index()
        {
            return View(BLL.FacturasBLL.Listar());
        }

        // GET: Facturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturas = await _context.Facturas
                .SingleOrDefaultAsync(m => m.FacturaId == id);
            if (facturas == null)
            {
                return NotFound();
            }

            return View(facturas);
        }

        // GET: Facturas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacturaId,ClienteId,Clientes,Fecha,Total,Empleados")] Facturas facturas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturas);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(facturas);
        }

        // GET: Facturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturas = await _context.Facturas.SingleOrDefaultAsync(m => m.FacturaId == id);
            if (facturas == null)
            {
                return NotFound();
            }
            return View(facturas);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FacturaId,ClienteId,Clientes,Fecha,Total,Empleados")] Facturas facturas)
        {
            if (id != facturas.FacturaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //BLL.FacturasBLL.Modificar(facturas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturasExists(facturas.FacturaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(facturas);
        }

        // GET: Facturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturas = await _context.Facturas
                .SingleOrDefaultAsync(m => m.FacturaId == id);
            if (facturas == null)
            {
                return NotFound();
            }

            return View(facturas);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturas = await _context.Facturas.SingleOrDefaultAsync(m => m.FacturaId == id);
            _context.Facturas.Remove(facturas);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FacturasExists(int id)
        {
            return _context.Facturas.Any(e => e.FacturaId == id);
        }
    }
}
