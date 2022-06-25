using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;

namespace ProyectoDesarrollo.Controllers
{
    public class PropietariosController : Controller
    {
        private readonly DataBaseContext _context;

        public PropietariosController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Propietarios
        public async Task<IActionResult> Index()
        {
            var dataBaseContext = _context.Propietarios.Include(p => p.Poliza);
            return View(await dataBaseContext.ToListAsync());
        }

        // GET: Propietarios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Propietarios == null)
            {
                return NotFound();
            }

            var propietario = await _context.Propietarios
                .Include(p => p.Poliza)
                .FirstOrDefaultAsync(m => m.CedulaRif == id);
            if (propietario == null)
            {
                return NotFound();
            }

            return View(propietario);
        }

        // GET: Propietarios/Create
        public IActionResult Create()
        {
            ViewData["Id_Poliza"] = new SelectList(_context.Polizas, "ID", "ID");
            return View();
        }

        // POST: Propietarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CedulaRif,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,FechaNacimiento,Direccion,Id_Poliza")] Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propietario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Poliza"] = new SelectList(_context.Polizas, "ID", "ID", propietario.Id_Poliza);
            return View(propietario);
        }

        // GET: Propietarios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Propietarios == null)
            {
                return NotFound();
            }

            var propietario = await _context.Propietarios.FindAsync(id);
            if (propietario == null)
            {
                return NotFound();
            }
            ViewData["Id_Poliza"] = new SelectList(_context.Polizas, "ID", "ID", propietario.Id_Poliza);
            return View(propietario);
        }

        // POST: Propietarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CedulaRif,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,FechaNacimiento,Direccion,Id_Poliza")] Propietario propietario)
        {
            if (id != propietario.CedulaRif)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propietario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropietarioExists(propietario.CedulaRif))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Poliza"] = new SelectList(_context.Polizas, "ID", "ID", propietario.Id_Poliza);
            return View(propietario);
        }

        // GET: Propietarios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Propietarios == null)
            {
                return NotFound();
            }

            var propietario = await _context.Propietarios
                .Include(p => p.Poliza)
                .FirstOrDefaultAsync(m => m.CedulaRif == id);
            if (propietario == null)
            {
                return NotFound();
            }

            return View(propietario);
        }

        // POST: Propietarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Propietarios == null)
            {
                return Problem("Entity set 'DataBaseContext.Propietarios'  is null.");
            }
            var propietario = await _context.Propietarios.FindAsync(id);
            if (propietario != null)
            {
                _context.Propietarios.Remove(propietario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropietarioExists(string id)
        {
          return _context.Propietarios.Any(e => e.CedulaRif == id);
        }
    }
}
