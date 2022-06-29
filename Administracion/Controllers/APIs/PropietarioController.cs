using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Persistence.DAO;
using ProyectoDesarrollo.Persistence.DAO.Implementations;
using ProyectoDesarrollo.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Administracion.Controllers.APIs
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

        // GET: api/<ClienteController>
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

        // GET api/<ClienteController>/5
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

        // POST api/<ClienteController>
        [HttpPost]
        public ApplicationResponse<string> Post([FromBody] PropietarioDTO value)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _propietarioDao.Insert(value);
            }
            catch(Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public ApplicationResponse<string> Put(int id, [FromBody] PropietarioDTO value)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _propietarioDao.Update(value);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public ApplicationResponse<string> Delete([FromBody] PropietarioDTO value)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _propietarioDao.Delete(value);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }
    }
}
