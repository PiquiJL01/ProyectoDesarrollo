using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Persistence.DAO.Implementations;
using RCVUcab;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RegistroDeIncidentesPeritos.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropietarioController : ControllerBase
    {
        private readonly PropietarioDAO _propietarioDao;

        public PropietarioController(PropietarioDAO propietarioDao)
        {
            _propietarioDao = propietarioDao;
        }
        
        // GET: api/<PropietarioController>
        [HttpGet]
        public ApplicationResponse<IEnumerable<PropietarioDTO>> Get()
        {
            var response = new ApplicationResponse<IEnumerable<PropietarioDTO>>();
            try
            {
                response.Data = _propietarioDao.Select();
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        // GET api/<PropietarioController>/5
        [HttpGet("{id}")]
        public ApplicationResponse<PropietarioDTO> Get(string id)
        {
            var response = new ApplicationResponse<PropietarioDTO>();
            try
            {
                response.Data = _propietarioDao.Select(id);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        // POST api/<PropietarioController>
        [HttpPost]
        public ApplicationResponse<string> Post([FromBody] PropietarioDTO value)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _propietarioDao.Insert(value);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        /*// PUT api/<PropietarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        /*// DELETE api/<PropietarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
