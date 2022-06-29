using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Persistence.DAO.Implementations;
using ProyectoDesarrollo.Responses;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Administracion.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly ProveedorDAO _proveedorDao;

        public ProveedorController(ProveedorDAO proveedorDao)
        {
            _proveedorDao = proveedorDao;
        }

        // GET: api/<ProveedorController>
        [HttpGet]
        public ApplicationResponse<IEnumerable<ProveedorDTO>> Get()
        {
            var response = new ApplicationResponse<IEnumerable<ProveedorDTO>>();
            try
            {
                response.Data = _proveedorDao.Select();
            }
            catch(Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }

        // GET api/<ProveedorController>/5
        [HttpGet("{id}")]
        public ApplicationResponse<ProveedorDTO> Get(string id)
        {
            var response = new ApplicationResponse<ProveedorDTO>();
            try
            {
                response.Data = _proveedorDao.Select(id);
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }

        // POST api/<ProveedorController>
        [HttpPost]
        public ApplicationResponse<string> Post([FromBody] ProveedorDTO value)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _proveedorDao.Insert(value);
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }

        // PUT api/<ProveedorController>/5
        [HttpPut("{id}")]
        public ApplicationResponse<string> Put(int id, [FromBody] ProveedorDTO value)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _proveedorDao.Update(value);
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }

        // DELETE api/<ProveedorController>/5
        [HttpDelete("{id}")]
        public ApplicationResponse<string> Delete(ProveedorDTO value)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _proveedorDao.Delete(value);
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }
    }
}
