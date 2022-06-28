using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Persistence.DAO.Implementations;
using ProyectoDesarrollo.Persistence.DataBase;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Administracion.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidenteController : ControllerBase
    {
        private readonly IncidenteDAO _incidenteDAO;

        public IncidenteController(IncidenteDAO incidenteDao)
        {
            _incidenteDAO = incidenteDao;
        }

        // GET: api/<IncidenteController>
        [HttpGet]
        public IEnumerable<IncidenteDTO> Get()
        {
            return _incidenteDAO.Select();
        }

        // GET api/<IncidenteController>/5
        [HttpGet("{id}")]
        public IncidenteDTO Get(string id)
        {
            return _incidenteDAO.Select(id);
        }

        // POST api/<IncidenteController>
        [HttpPost]
        public void Post([FromBody] IncidenteDTO incidenteDto)
        {
            _incidenteDAO.Insert(incidenteDto);
        }

        // PUT api/<IncidenteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] IncidenteDTO incidenteDto)
        {
            _incidenteDAO.Update(incidenteDto);
        }

        // DELETE api/<IncidenteController>/5
        [HttpDelete("{id}")]
        public void Delete([FromBody]IncidenteDTO incidenteDto)
        {
            _incidenteDAO.Delete(incidenteDto);
        }
    }
}
