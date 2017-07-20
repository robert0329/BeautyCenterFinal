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
    public class ClientesController : Controller
    {
        private readonly BeautyCoreDb _context;

        public ClientesController(BeautyCoreDb context)
        {
            _context = context;    
        }

        // GET: Clientes
        public IActionResult Index()
        {
            return View(BLL.ClientesBLL.Listar());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .SingleOrDefaultAsync(m => m.ClienteId == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ClienteId,Nombres,Provincia,Ciudad,Direccion,Cedula,Telefono,FechaNac")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                BLL.ClientesBLL.Guardar(clientes);
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = BLL.ClientesBLL.Buscar(id);
            if (clientes == null)
            {
                return NotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Nombres,Provincia,Ciudad,Direccion,Cedula,Telefono,FechaNac")] Clientes clientes)
        {
            if (id != clientes.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    BLL.ClientesBLL.Modificar(clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesExists(clientes.ClienteId))
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
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = BLL.ClientesBLL.Buscar(id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var clientes = BLL.ClientesBLL.Buscar(id);
            BLL.ClientesBLL.Eliminar(clientes);
            return RedirectToAction("Index");
        }

        private bool ClientesExists(int id)
        {
            return _context.Clientes.Any(e => e.ClienteId == id);
        }
    }
}
