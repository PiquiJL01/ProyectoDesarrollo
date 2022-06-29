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
    public class PeritosController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public PeritosController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Peritos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perito>>> GetPeritos()
        {
            return await _context.Peritos.ToListAsync();
        }

        // GET: api/Peritos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Perito>> GetPerito(string id)
        {
            var perito = await _context.Peritos.FindAsync(id);

            if (perito == null)
            {
                return NotFound();
            }

            return perito;
        }

        // PUT: api/Peritos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerito(string id, Perito perito)
        {
            if (id != perito.Id)
            {
                return BadRequest();
            }

            _context.Entry(perito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeritoExists(id))
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

        // POST: api/Peritos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Perito>> PostPerito(Perito perito)
        {
            _context.Peritos.Add(perito);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PeritoExists(perito.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPerito", new { id = perito.Id }, perito);
        }

        // DELETE: api/Peritos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerito(string id)
        {
            var perito = await _context.Peritos.FindAsync(id);
            if (perito == null)
            {
                return NotFound();
            }

            _context.Peritos.Remove(perito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PeritoExists(string id)
        {
            return _context.Peritos.Any(e => e.Id == id);
        }
    }
}
