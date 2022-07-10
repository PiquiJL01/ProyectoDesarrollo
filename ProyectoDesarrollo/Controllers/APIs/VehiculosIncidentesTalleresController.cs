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
    public class VehiculosIncidentesTalleresController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public VehiculosIncidentesTalleresController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/VehiculosIncidentesTalleres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehiculoIncidenteTaller>>> GetVehiculosIncidentesTalleres()
        {
            return await _context.VehiculosIncidentesTalleres.ToListAsync();
        }

        // GET: api/VehiculosIncidentesTalleres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehiculoIncidenteTaller>> GetVehiculoIncidenteTaller(int id)
        {
            var vehiculoIncidenteTaller = await _context.VehiculosIncidentesTalleres.FindAsync(id);

            if (vehiculoIncidenteTaller == null)
            {
                return NotFound();
            }

            return vehiculoIncidenteTaller;
        }

        // PUT: api/VehiculosIncidentesTalleres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculoIncidenteTaller(int id, VehiculoIncidenteTaller vehiculoIncidenteTaller)
        {
            if (id != vehiculoIncidenteTaller.ID)
            {
                return BadRequest();
            }

            _context.Entry(vehiculoIncidenteTaller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoIncidenteTallerExists(id))
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

        // POST: api/VehiculosIncidentesTalleres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VehiculoIncidenteTaller>> PostVehiculoIncidenteTaller(VehiculoIncidenteTaller vehiculoIncidenteTaller)
        {
            _context.VehiculosIncidentesTalleres.Add(vehiculoIncidenteTaller);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehiculoIncidenteTaller", new { id = vehiculoIncidenteTaller.ID }, vehiculoIncidenteTaller);
        }

        // DELETE: api/VehiculosIncidentesTalleres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculoIncidenteTaller(int id)
        {
            var vehiculoIncidenteTaller = await _context.VehiculosIncidentesTalleres.FindAsync(id);
            if (vehiculoIncidenteTaller == null)
            {
                return NotFound();
            }

            _context.VehiculosIncidentesTalleres.Remove(vehiculoIncidenteTaller);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehiculoIncidenteTallerExists(int id)
        {
            return _context.VehiculosIncidentesTalleres.Any(e => e.ID == id);
        }
    }
}
