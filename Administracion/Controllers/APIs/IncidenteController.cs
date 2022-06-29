
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Exceptions;
using ProyectoDesarrollo.Persistence.DAO.Implementations;
using ProyectoDesarrollo.Persistence.DAO.Interfaces;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Administracion.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidenteController : ControllerBase
    {
        private readonly IIncidenteDAO _incidenteDAO;

        public IncidenteController(IIncidenteDAO incidenteDao)
        {
            _incidenteDAO = incidenteDao;
        }

        // GET: api/<IncidenteController>
        /*[HttpGet]
        public IEnumerable<IncidenteDTO> Get()
        {
            return _incidenteDAO.Select();
        }*/

        // GET api/<IncidenteController>/5
        [HttpGet("incidentes/{id}")]
        public ApplicationResponse<List<IncidenteDTO>> GetIncidentesByID([Required][FromRoute] string id)
        {
            var response = new ApplicationResponse<List<IncidenteDTO>>();
            try
            {
                response.Data = _incidenteDAO.GetIncidentesByID(id);
            }
            catch (ProyectoException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

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
