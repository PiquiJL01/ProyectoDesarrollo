using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;

namespace ProyectoDesarrollo.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiezasMarcasController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public PiezasMarcasController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/PiezasMarcas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PiezaMarca>>> GetPiezasMarcas()
        {
            return await _context.PiezasMarcas.ToListAsync();
        }

        // GET: api/PiezasMarcas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PiezaMarca>> GetPiezaMarca(string id)
        {
            var piezaMarca = await _context.PiezasMarcas.FindAsync(id);

            if (piezaMarca == null)
            {
                return NotFound();
            }

            return piezaMarca;
        }

        // PUT: api/PiezasMarcas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiezaMarca(string id, PiezaMarca piezaMarca)
        {
            if (id != piezaMarca.ID)
            {
                return BadRequest();
            }

            _context.Entry(piezaMarca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiezaMarcaExists(id))
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

        // POST: api/PiezasMarcas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PiezaMarca>> PostPiezaMarca(PiezaMarca piezaMarca)
        {
            _context.PiezasMarcas.Add(piezaMarca);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PiezaMarcaExists(piezaMarca.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPiezaMarca", new { id = piezaMarca.ID }, piezaMarca);
        }

        // DELETE: api/PiezasMarcas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePiezaMarca(string id)
        {
            var piezaMarca = await _context.PiezasMarcas.FindAsync(id);
            if (piezaMarca == null)
            {
                return NotFound();
            }

            _context.PiezasMarcas.Remove(piezaMarca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PiezaMarcaExists(string id)
        {
            return _context.PiezasMarcas.Any(e => e.ID == id);
        }
    }
}
