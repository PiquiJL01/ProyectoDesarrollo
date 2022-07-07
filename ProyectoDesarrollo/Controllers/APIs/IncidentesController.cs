using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Exceptions;
using ProyectoDesarrollo.Persistence.DAO.Interfaces;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using ProyectoDesarrollo.Response;

namespace ProyectoDesarrollo.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentesController : ControllerBase
    {
        private readonly IIncidenteDAO _incidenteDAO;
        private readonly ILogger<IncidentesController> _logger;

        public IncidentesController(ILogger<IncidentesController> logger, IIncidenteDAO incidenteDao)
        {
            _incidenteDAO = incidenteDao;
            _logger = logger;

        }

        private readonly DataBaseContext _context;

        public IncidentesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Incidentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incidente>>> GetIncidentes()
        {
            return await _context.Incidentes.ToListAsync();
        }

        // GET: api/Incidentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Incidente>> GetIncidente(string id)
        {
            var incidente = await _context.Incidentes.FindAsync(id);

            if (incidente == null)
            {
                return NotFound();
            }

            return incidente;
        }

        // PUT: api/Incidentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidente(string id, Incidente incidente)
        {
            if (id != incidente.ID)
            {
                return BadRequest();
            }

            _context.Entry(incidente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidenteExists(id))
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

        // POST: api/Incidentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Incidente>> PostIncidente(Incidente incidente)
        {
            _context.Incidentes.Add(incidente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IncidenteExists(incidente.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIncidente", new { id = incidente.ID }, incidente);
        }

        // DELETE: api/Incidentes/5
        [HttpDelete("{id}")]
        public ApplicationResponse<List<IncidenteDTO>> DeleteIncidente(string id)
        {
            var response = new ApplicationResponse<List<IncidenteDTO>>();
            try
            {
                response.Data = _incidenteDAO.DeleteIncidente(id);
            }
            catch (ProyectoException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }

            return response;
        }
        /*public async Task<IActionResult> DeleteIncidente(string id)
        {

            var incidente = await _context.Incidentes.FindAsync(id);
            if (incidente == null)
            {
                return NotFound();
            }

            _context.Incidentes.Remove(incidente);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/

        private bool IncidenteExists(string id)
        {
            return _context.Incidentes.Any(e => e.ID == id);
        }
    }
}
