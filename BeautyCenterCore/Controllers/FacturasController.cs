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
        public IActionResult Create([Bind("FacturaId,ClienteId,Fecha,Total")] Facturas facturas)
        {
            if (ModelState.IsValid)
            {
                BLL.FacturasBLL.Guardar(facturas);
                return RedirectToAction("Index");
            }
            return View(facturas);
        }

        // GET: Facturas/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturas = BLL.FacturasBLL.Buscarr(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("FacturaId,ClienteId,Fecha,Total")] Facturas facturas)
        {
            if (id != facturas.FacturaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    BLL.FacturasBLL.Modificar(facturas);
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
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturas = BLL.FacturasBLL.Buscarr(id);
            if (facturas == null)
            {
                return NotFound();
            }

            return View(facturas);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var Facturas = BLL.FacturasBLL.Buscarr(id);
            BLL.FacturasBLL.Eliminar(Facturas);
            return RedirectToAction("Index");
        }

        private bool FacturasExists(int id)
        {
            return _context.Facturas.Any(e => e.FacturaId == id);
        }
    }
}
