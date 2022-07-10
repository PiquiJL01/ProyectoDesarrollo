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
    public class PiezasCotizacionesController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public PiezasCotizacionesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/PiezasCotizaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PiezaCotizacion>>> GetPiezasCotizaciones()
        {
            return await _context.PiezasCotizaciones.ToListAsync();
        }

        // GET: api/PiezasCotizaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PiezaCotizacion>> GetPiezaCotizacion(string id)
        {
            var piezaCotizacion = await _context.PiezasCotizaciones.FindAsync(id);

            if (piezaCotizacion == null)
            {
                return NotFound();
            }

            return piezaCotizacion;
        }

        // PUT: api/PiezasCotizaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiezaCotizacion(string id, PiezaCotizacion piezaCotizacion)
        {
            if (id != piezaCotizacion.ID)
            {
                return BadRequest();
            }

            _context.Entry(piezaCotizacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiezaCotizacionExists(id))
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

        // POST: api/PiezasCotizaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PiezaCotizacion>> PostPiezaCotizacion(PiezaCotizacion piezaCotizacion)
        {
            _context.PiezasCotizaciones.Add(piezaCotizacion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PiezaCotizacionExists(piezaCotizacion.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPiezaCotizacion", new { id = piezaCotizacion.ID }, piezaCotizacion);
        }

        // DELETE: api/PiezasCotizaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePiezaCotizacion(string id)
        {
            var piezaCotizacion = await _context.PiezasCotizaciones.FindAsync(id);
            if (piezaCotizacion == null)
            {
                return NotFound();
            }

            _context.PiezasCotizaciones.Remove(piezaCotizacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PiezaCotizacionExists(string id)
        {
            return _context.PiezasCotizaciones.Any(e => e.ID == id);
        }
    }
}
