using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeautyCenterCore.Models;
using BeautyCenterCore.BLL;
using Microsoft.AspNetCore.Authorization;

namespace BeautyCenterCore.Controllers
{
    [Authorize(ActiveAuthenticationSchemes = "CookiePolicy")]
    public class CitasController : Controller
    {
        private readonly BeautyCoreDb _context;

        public CitasController(BeautyCoreDb context)
        {
            _context = context;    
        }
        
        // GET: Citas
        public IActionResult Index()
        {
            return View(BLL.CitasBLL.Listar());
        }

        // GET: Citas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = await _context.Citas
                .SingleOrDefaultAsync(m => m.CitaId == id);
            if (citas == null)
            {
                return NotFound();
            }

            return View(citas);
        }

        // GET: Citas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CitaId,ClienteId,Nombres,ServicioId,Servicio,EmpleadoId,NombreE,Fecha")] Citas citas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citas);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(citas);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = await _context.Citas.SingleOrDefaultAsync(m => m.CitaId == id);
            if (citas == null)
            {
                return NotFound();
            }
            return View(citas);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CitaId,ClienteId,Nombres,ServicioId,Servicio,EmpleadoId,NombreE,Fecha")] Citas citas)
        {
            if (id != citas.CitaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    BLL.CitasBLL.Modificar(citas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitasExists(citas.CitaId))
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
            return View(citas);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = await _context.Citas
                .SingleOrDefaultAsync(m => m.CitaId == id);
            if (citas == null)
            {
                return NotFound();
            }

            return View(citas);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var citas = await _context.Citas.SingleOrDefaultAsync(m => m.CitaId == id);
            _context.Citas.Remove(citas);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CitasExists(int id)
        {
            return _context.Citas.Any(e => e.CitaId == id);
        }
        public JsonResult Guardar(ClasesC nueva)
        {
            bool resultado = false;
            if (ModelState.IsValid)
            {
                resultado = CitasBLL.Guardar(nueva);
            }
            return Json(resultado);
        }
        [HttpGet]
        public JsonResult ListaServicios(int id)
        {
            var listado = BLL.ServiciosBLL.Listar();

            return Json(listado);
        }
        [HttpGet]
        public JsonResult ListaClientes(int id)
        {
            var listado = BLL.ClientesBLL.Listar();

            return Json(listado);
        }
        public JsonResult Modificar(ClasesC nuevo)
        {
            var existe = (BLL.CitasBLL.Buscarr(nuevo.Encabezado.CitaId) != null);
            if (existe)
            {
                existe = BLL.CitasBLL.Modificar(nuevo);
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
            int id = BLL.CitasBLL.Identity();
            if (id > 1 || BLL.CitasBLL.Listar().Count > 0)
                ++id;
            return Json(id);
        }
        [HttpPost]
        public JsonResult Eliminar(ClasesC nuevo)
        {
            var existe = (BLL.CitasBLL.BuscarEncabezado(nuevo.Encabezado.CitaId) != null);

            if (existe)
            {
                existe = BLL.CitasBLL.Eliminar(nuevo);
                return Json(existe);
            }
            else
            {
                return Json(null);
            }
        }
        [HttpGet]
        public ActionResult Buscar(int Id)
        {
            Citas var = BLL.CitasBLL.Buscar(Id);

            return Json(var);
        }
        [HttpGet]
        public JsonResult BuscarD(int Id)
        {
            var nuevo = BLL.DetalleCitasBLL.Listar(Id);
            return Json(nuevo);
        }
        [HttpGet]
        public ActionResult BuscarFecha(DateTime Desde, DateTime Hasta)
        {
            return Json(BLL.CitasBLL.GetListaFecha(Desde, Hasta));
        }
    }
}
