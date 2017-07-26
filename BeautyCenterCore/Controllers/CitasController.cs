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
   // [Authorize(ActiveAuthenticationSchemes = "CookiePolicy")]
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
        public IActionResult Create([Bind("CitaId,ClienteId,Nombres,ServicioId,Servicio,EmpleadoId,NombreE,Fecha")] Citas citas)
        {
            if (ModelState.IsValid)
            {
                BLL.CitasBLL.Guardar(citas);
                return RedirectToAction("Index");
            }
            return View(citas);
        }

        // GET: Citas/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = BLL.CitasBLL.Buscar(id);
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
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = BLL.CitasBLL.Buscar(id);
            if (citas == null)
            {
                return NotFound();
            }

            return View(citas);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var citas = BLL.CitasBLL.Buscarr(id);
            BLL.CitasBLL.Eliminar(citas);
            return RedirectToAction("Index");
        }

        private bool CitasExists(int id)
        {
            return _context.Citas.Any(e => e.CitaId == id);
        }
    }
}
