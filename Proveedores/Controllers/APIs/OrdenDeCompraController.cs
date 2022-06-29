using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Persistence.DAO.Implementations;
using RCVUcab;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proveedores.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenDeCompraController : ControllerBase
    {
        private readonly OrdenDeCompraDAO _ordenDeCompraDao;

        public OrdenDeCompraController(OrdenDeCompraDAO ordenDeCompraDao)
        {
            _ordenDeCompraDao = ordenDeCompraDao;
        }
        
        // GET: api/<OrdenDeCompraController>
        [HttpGet]
        public ApplicationResponse<IEnumerable<OrdenDeCompraDTO>> Get()
        {
            var response = new ApplicationResponse<IEnumerable<OrdenDeCompraDTO>>();
            try
            {
                response.Data = _ordenDeCompraDao.Select();
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        // GET api/<OrdenDeCompraController>/5
        [HttpGet("{id}")]
        public ApplicationResponse<OrdenDeCompraDTO> Get(string id)
        {
            var response = new ApplicationResponse<OrdenDeCompraDTO>();
            try
            {
                response.Data = _ordenDeCompraDao.Select(id);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        /*// POST api/<OrdenDeCompraController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }*/

        // PUT api/<OrdenDeCompraController>/5
        [HttpPut("{id}")]
        public ApplicationResponse<string> Put(int id, [FromBody] OrdenDeCompraDTO value)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _ordenDeCompraDao.Update(value);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        /*// DELETE api/<OrdenDeCompraController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
