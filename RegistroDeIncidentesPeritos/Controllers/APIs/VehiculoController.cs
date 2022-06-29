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
    public class VehiculoController : ControllerBase
    {
        private readonly VehiculoDAO _vehiculoDao;

        public VehiculoController(VehiculoDAO vehiculoDao)
        {
            _vehiculoDao = vehiculoDao;
        }

        // GET: api/<VehiculoController>
        [HttpGet]
        public ApplicationResponse<IEnumerable<VehiculoDTO>> Get()
        {
            var response = new ApplicationResponse<IEnumerable<VehiculoDTO>>();
            try
            {
                response.Data = _vehiculoDao.Select();
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        // GET api/<VehiculoController>/5
        [HttpGet("{id}")]
        public ApplicationResponse<VehiculoDTO> Get(string id)
        {
            var response = new ApplicationResponse<VehiculoDTO>();
            try
            {
                response.Data = _vehiculoDao.Select(id);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        // POST api/<VehiculoController>
        [HttpPost]
        public ApplicationResponse<string> Post([FromBody] VehiculoDTO value)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _vehiculoDao.Insert(value);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        // PUT api/<VehiculoController>/5
        [HttpPut("{id}")]
        public ApplicationResponse<string> Put(int id, [FromBody] VehiculoDTO value)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _vehiculoDao.Update(value);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        /*// DELETE api/<VehiculoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
