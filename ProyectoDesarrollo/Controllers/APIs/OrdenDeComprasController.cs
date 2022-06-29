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
    public class OrdenDeComprasController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public OrdenDeComprasController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/OrdenDeCompras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenDeCompra>>> GetOrdenesDeCompra()
        {
            return await _context.OrdenesDeCompra.ToListAsync();
        }

        // GET: api/OrdenDeCompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenDeCompra>> GetOrdenDeCompra(string id)
        {
            var ordenDeCompra = await _context.OrdenesDeCompra.FindAsync(id);

            if (ordenDeCompra == null)
            {
                return NotFound();
            }

            return ordenDeCompra;
        }

        // PUT: api/OrdenDeCompras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenDeCompra(string id, OrdenDeCompra ordenDeCompra)
        {
            if (id != ordenDeCompra.ID)
            {
                return BadRequest();
            }

            _context.Entry(ordenDeCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenDeCompraExists(id))
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

        // POST: api/OrdenDeCompras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenDeCompra>> PostOrdenDeCompra(OrdenDeCompra ordenDeCompra)
        {
            _context.OrdenesDeCompra.Add(ordenDeCompra);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrdenDeCompraExists(ordenDeCompra.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrdenDeCompra", new { id = ordenDeCompra.ID }, ordenDeCompra);
        }

        // DELETE: api/OrdenDeCompras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenDeCompra(string id)
        {
            var ordenDeCompra = await _context.OrdenesDeCompra.FindAsync(id);
            if (ordenDeCompra == null)
            {
                return NotFound();
            }

            _context.OrdenesDeCompra.Remove(ordenDeCompra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenDeCompraExists(string id)
        {
            return _context.OrdenesDeCompra.Any(e => e.ID == id);
        }
    }
}
