using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Persistence.DAO.Implementations;
using ProyectoDesarrollo.Responses;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Talleres.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidenteController : ControllerBase
    {
        private readonly IncidenteDAO _IncidenteDao;

        public IncidenteController(IncidenteDAO IncidenteDao)
        {
            _IncidenteDao = IncidenteDao;
        }

        // GET: api/<IncidenteController>
        [HttpGet]
        public ApplicationResponse<IEnumerable<IncidenteDTO>> Get()
        {
            var response = new ApplicationResponse<IEnumerable<IncidenteDTO>>();
            try
            {
                response.Data = _IncidenteDao.Select();
            }
            catch (Exception ex)
            {
                response.Error(ex);
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
                response.Data = _IncidenteDao.Select(id);
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }

        // POST api/<IncidenteController>
        [HttpPost]
        public ApplicationResponse<string> Post([FromBody] IncidenteDTO value)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _IncidenteDao.Insert(value);
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }

        // PUT api/<IncidenteController>/5
        [HttpPut("{id}")]
        public ApplicationResponse<string> Put(int id, [FromBody] IncidenteDTO value)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _IncidenteDao.Update(value);
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }

        // DELETE api/<IncidenteController>/5
        [HttpDelete("{id}")]
        public ApplicationResponse<string> Delete(IncidenteDTO value)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _IncidenteDao.Delete(value);
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }
    }
}