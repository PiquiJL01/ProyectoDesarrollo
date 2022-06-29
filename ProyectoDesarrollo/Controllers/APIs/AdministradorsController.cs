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
    public class AdministradorsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public AdministradorsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Administradors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAdministradores()
        {
            return await _context.Administradores.ToListAsync();
        }

        // GET: api/Administradors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrador>> GetAdministrador(string id)
        {
            var administrador = await _context.Administradores.FindAsync(id);

            if (administrador == null)
            {
                return NotFound();
            }

            return administrador;
        }

        // PUT: api/Administradors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrador(string id, Administrador administrador)
        {
            if (id != administrador.Id)
            {
                return BadRequest();
            }

            _context.Entry(administrador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorExists(id))
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

        // POST: api/Administradors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Administrador>> PostAdministrador(Administrador administrador)
        {
            _context.Administradores.Add(administrador);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdministradorExists(administrador.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAdministrador", new { id = administrador.Id }, administrador);
        }

        // DELETE: api/Administradors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrador(string id)
        {
            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }

            _context.Administradores.Remove(administrador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministradorExists(string id)
        {
            return _context.Administradores.Any(e => e.Id == id);
        }
    }
}
