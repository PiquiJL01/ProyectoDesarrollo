﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Persistence.DAO.Implementations;
using ProyectoDesarrollo.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Talleres.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotizacionController : ControllerBase
    {
        private readonly CotizacionDAO _cotizacionDAO;

        public CotizacionController(CotizacionDAO cotizacionDAO)
        {
            _cotizacionDAO = cotizacionDAO;
        }

        // GET: api/<CotizacionController>
        [HttpGet]
        public ApplicationResponse<IEnumerable<CotizacionDTO>> Get()
        {
            var response = new ApplicationResponse<IEnumerable<CotizacionDTO>>();
            try
            {
                response.Data = _cotizacionDAO.Select();
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        // GET api/<CotizacionController>/5
        [HttpGet("{id}")]
        public ApplicationResponse<CotizacionDTO> Get(string id)
        {
            var response = new ApplicationResponse<CotizacionDTO>();
            try
            {
                response.Data = _cotizacionDAO.Select(id);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        // POST api/<CotizacionController>
        [HttpPost]
        public ApplicationResponse<string> Post([FromBody] CotizacionDTO value)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _cotizacionDAO.Insert(value);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        // PUT api/<CotizacionController>/5
        [HttpPut("{id}")]
        public ApplicationResponse<string> Put(int id, [FromBody] CotizacionDTO value)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _cotizacionDAO.Update(value);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        /*// DELETE api/<CotizacionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
