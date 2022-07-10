using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDesarrollo.Persistence.Data;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;

namespace ProyectoDesarrollo.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresMarcasController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public ProveedoresMarcasController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/ProveedoresMarcas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProveedorMarca>>> GetProveedoresMarcas()
        {
            return await _context.ProveedoresMarcas.ToListAsync();
        }

        // GET: api/ProveedoresMarcas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProveedorMarca>> GetProveedorMarca(string id)
        {
            var proveedorMarca = await _context.ProveedoresMarcas.FindAsync(id);

            if (proveedorMarca == null)
            {
                return NotFound();
            }

            return proveedorMarca;
        }

        // PUT: api/ProveedoresMarcas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedorMarca(string id, ProveedorMarca proveedorMarca)
        {
            if (id != proveedorMarca.ID)
            {
                return BadRequest();
            }

            _context.Entry(proveedorMarca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorMarcaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProveedoresMarcas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProveedorMarca>> PostProveedorMarca(ProveedorMarca proveedorMarca)
        {
            _context.ProveedoresMarcas.Add(proveedorMarca);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProveedorMarcaExists(proveedorMarca.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProveedorMarca", new { id = proveedorMarca.ID }, proveedorMarca);
        }

        // DELETE: api/ProveedoresMarcas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedorMarca(string id)
        {
            var proveedorMarca = await _context.ProveedoresMarcas.FindAsync(id);
            if (proveedorMarca == null)
            {
                return NotFound();
            }

            _context.ProveedoresMarcas.Remove(proveedorMarca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProveedorMarcaExists(string id)
        {
            return _context.ProveedoresMarcas.Any(e => e.ID == id);
        }
    }
}
