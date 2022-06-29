using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<IncidenteController> _logger;

        public IncidenteController(ILogger<IncidenteController> logger, IIncidenteDAO incidenteDao)
        {
            _incidenteDAO = incidenteDao;
            _logger = logger;

        }

        // GET: api/<IncidenteController>
        [HttpGet]
        public ApplicationResponse<IEnumerable<IncidenteDTO>> Get()
        {
            var response = new ApplicationResponse<IEnumerable<IncidenteDTO>>();
            try
            {
                response.Data = _incidenteDAO.Select();
            }
            catch(ProyectoException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }

            return response;
        }

        // GET api/<IncidenteController>/5
        [HttpGet("{id}")]
        public ApplicationResponse<List<IncidenteDTO>> GetIncidenteByID([Required][FromRoute] string id)
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

        // POST api/<IncidenteController>
        [HttpPost]
        public ApplicationResponse<string> Post([FromBody] IncidenteDTO incidenteDto)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _incidenteDAO.Insert(incidenteDto);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        // PUT api/<IncidenteController>/5
        [HttpPut("{id}")]
        public ApplicationResponse<string> Put(int id, [FromBody] IncidenteDTO incidenteDto)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _incidenteDAO.Update(incidenteDto);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        // DELETE api/<IncidenteController>/5
        [HttpDelete("{id}")]
        public ApplicationResponse<string> Delete([FromBody]IncidenteDTO incidenteDto)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _incidenteDAO.Delete(incidenteDto);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }
    }
}
