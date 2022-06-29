using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Persistence.DAO.Implementations;
using ProyectoDesarrollo.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RegistroDeIncidentesPeritos.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidenteController : ControllerBase
    {
        private readonly IncidenteDAO _incidenteDao;

        public IncidenteController(IncidenteDAO incidenteDao)
        {
            _incidenteDao = incidenteDao;
        }

        // GET: api/<IncidenteController>
        [HttpGet]
        public ApplicationResponse<IEnumerable<IncidenteDTO>> Get()
        {
            var response = new ApplicationResponse<IEnumerable<IncidenteDTO>>();
            try
            {
                response.Data = _incidenteDao.Select();
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        // GET api/<IncidenteController>/5
        [HttpGet("{id}")]
        public ApplicationResponse<IncidenteDTO> Get(string id)
        {
            var response = new ApplicationResponse<IncidenteDTO>();
            try
            {
                response.Data = _incidenteDao.Select(id);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        /*// POST api/<IncidenteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }*/

        // PUT api/<IncidenteController>/5
        [HttpPut("{id}")]
        public ApplicationResponse<string> Put(int id, [FromBody] IncidenteDTO value)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _incidenteDao.Update(value);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        /*// DELETE api/<IncidenteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
