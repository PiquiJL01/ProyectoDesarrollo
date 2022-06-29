using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Persistence.DAO.Implementations;
using ProyectoDesarrollo.Persistence.Entidades;
using ProyectoDesarrollo.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Administracion.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class TallerController : ControllerBase
    {
        private readonly TallerDAO _tallerDao;

        public TallerController(TallerDAO tallerDao)
        {
            _tallerDao = tallerDao;
        }

        // GET: api/<TallerController>
        [HttpGet]
        public ApplicationResponse<IEnumerable<TallerDTO>> Get()
        {
            var response = new ApplicationResponse<IEnumerable<TallerDTO>>();
            try
            {
                response.Data = _tallerDao.Select();
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        // GET api/<TallerController>/5
        [HttpGet("{id}")]
        public ApplicationResponse<TallerDTO> Get(string id)
        {
            var response = new ApplicationResponse<TallerDTO>();
            try
            {
                response.Data = _tallerDao.Select(id);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        // POST api/<TallerController>
        [HttpPost]
        public ApplicationResponse<string> Post([FromBody] TallerDTO value)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _tallerDao.Insert(value);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        // PUT api/<TallerController>/5
        [HttpPut("{id}")]
        public ApplicationResponse<string> Put(int id, [FromBody] TallerDTO value)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _tallerDao.Update(value);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }

        // DELETE api/<TallerController>/5
        [HttpDelete("{id}")]
        public ApplicationResponse<string> Delete([FromBody] TallerDTO value)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _tallerDao.Delete(value);
            }
            catch (Exception e)
            {
                response.Error(e);
            }

            return response;
        }
    }
}
