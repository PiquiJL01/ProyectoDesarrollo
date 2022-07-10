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
    public class TallersController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public TallersController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Tallers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taller>>> GetTalleres()
        {
            return await _context.Talleres.ToListAsync();
        }

        // GET: api/Tallers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Taller>> GetTaller(string id)
        {
            var taller = await _context.Talleres.FindAsync(id);

            if (taller == null)
            {
                return NotFound();
            }

            return taller;
        }

        // PUT: api/Tallers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaller(string id, Taller taller)
        {
            if (id != taller.Id)
            {
                return BadRequest();
            }

            _context.Entry(taller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TallerExists(id))
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

        // POST: api/Tallers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Taller>> PostTaller(Taller taller)
        {
            _context.Talleres.Add(taller);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TallerExists(taller.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTaller", new { id = taller.Id }, taller);
        }

        // DELETE: api/Tallers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaller(string id)
        {
            var taller = await _context.Talleres.FindAsync(id);
            if (taller == null)
            {
                return NotFound();
            }

            _context.Talleres.Remove(taller);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TallerExists(string id)
        {
            return _context.Talleres.Any(e => e.Id == id);
        }
    }
}
