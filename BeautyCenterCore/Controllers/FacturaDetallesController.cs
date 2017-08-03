using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeautyCenterCore.Models;

namespace BeautyCenterCore.Controllers
{
    public class FacturaDetallesController : Controller
    {
        private readonly BeautyCoreDb _context;

        public FacturaDetallesController(BeautyCoreDb context)
        {
            _context = context;    
        }
        [HttpGet]
        public JsonResult BuscarF(int facturaId)
        {
            var factura = BLL.FacturaDetallesBLL.Listar(facturaId);
            return Json(factura);
        }
        // GET: FacturaDetalles
        public async Task<IActionResult> Index()
        {
            return View(await _context.FacturaDetalles.ToListAsync());
        }

        // GET: FacturaDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDetalles = await _context.FacturaDetalles
                .SingleOrDefaultAsync(m => m.Id == id);
            if (facturaDetalles == null)
            {
                return NotFound();
            }

            return View(facturaDetalles);
        }

        // GET: FacturaDetalles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FacturaDetalles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FacturaId,ClienteId,ServicioId,Precio,Descuento,Cantidad,SubTotal")] FacturaDetalles facturaDetalles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturaDetalles);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(facturaDetalles);
        }

        // GET: FacturaDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDetalles = await _context.FacturaDetalles.SingleOrDefaultAsync(m => m.Id == id);
            if (facturaDetalles == null)
            {
                return NotFound();
            }
            return View(facturaDetalles);
        }

        // POST: FacturaDetalles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FacturaId,ClienteId,ServicioId,Precio,Descuento,Cantidad,SubTotal")] FacturaDetalles facturaDetalles)
        {
            if (id != facturaDetalles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturaDetalles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaDetallesExists(facturaDetalles.Id))
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
            return View(facturaDetalles);
        }

        // GET: FacturaDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDetalles = await _context.FacturaDetalles
                .SingleOrDefaultAsync(m => m.Id == id);
            if (facturaDetalles == null)
            {
                return NotFound();
            }

            return View(facturaDetalles);
        }

        // POST: FacturaDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturaDetalles = await _context.FacturaDetalles.SingleOrDefaultAsync(m => m.Id == id);
            _context.FacturaDetalles.Remove(facturaDetalles);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FacturaDetallesExists(int id)
        {
            return _context.FacturaDetalles.Any(e => e.Id == id);
        }
    }
}
