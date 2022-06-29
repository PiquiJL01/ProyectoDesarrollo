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
    public class CotizacionesController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public CotizacionesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Cotizaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cotizacion>>> GetCotizaciones()
        {
            return await _context.Cotizaciones.ToListAsync();
        }

        // GET: api/Cotizaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cotizacion>> GetCotizacion(string id)
        {
            var cotizacion = await _context.Cotizaciones.FindAsync(id);

            if (cotizacion == null)
            {
                return NotFound();
            }

            return cotizacion;
        }

        // PUT: api/Cotizaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCotizacion(string id, Cotizacion cotizacion)
        {
            if (id != cotizacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(cotizacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CotizacionExists(id))
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

        // POST: api/Cotizaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cotizacion>> PostCotizacion(Cotizacion cotizacion)
        {
            _context.Cotizaciones.Add(cotizacion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CotizacionExists(cotizacion.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCotizacion", new { id = cotizacion.Id }, cotizacion);
        }

        // DELETE: api/Cotizaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCotizacion(string id)
        {
            var cotizacion = await _context.Cotizaciones.FindAsync(id);
            if (cotizacion == null)
            {
                return NotFound();
            }

            _context.Cotizaciones.Remove(cotizacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CotizacionExists(string id)
        {
            return _context.Cotizaciones.Any(e => e.Id == id);
        }
    }
}
