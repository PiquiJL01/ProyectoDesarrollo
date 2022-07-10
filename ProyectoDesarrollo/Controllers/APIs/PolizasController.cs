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
    public class PolizasController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public PolizasController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Polizas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poliza>>> GetPolizas()
        {
            return await _context.Polizas.ToListAsync();
        }

        // GET: api/Polizas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Poliza>> GetPoliza(string id)
        {
            var poliza = await _context.Polizas.FindAsync(id);

            if (poliza == null)
            {
                return NotFound();
            }

            return poliza;
        }

        // PUT: api/Polizas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoliza(string id, Poliza poliza)
        {
            if (id != poliza.ID)
            {
                return BadRequest();
            }

            _context.Entry(poliza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolizaExists(id))
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

        // POST: api/Polizas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Poliza>> PostPoliza(Poliza poliza)
        {
            _context.Polizas.Add(poliza);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PolizaExists(poliza.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPoliza", new { id = poliza.ID }, poliza);
        }

        // DELETE: api/Polizas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoliza(string id)
        {
            var poliza = await _context.Polizas.FindAsync(id);
            if (poliza == null)
            {
                return NotFound();
            }

            _context.Polizas.Remove(poliza);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PolizaExists(string id)
        {
            return _context.Polizas.Any(e => e.ID == id);
        }
    }
}
