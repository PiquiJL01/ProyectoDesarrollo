using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Persistence.DAO;
using ProyectoDesarrollo.Persistence.DAO.Implementations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Administracion.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolizasController : ControllerBase
    {
        private readonly PolizaDAO _polizaDao;

        public PolizasController(PolizaDAO polizaDao)
        {
            _polizaDao = polizaDao;
        }

        // GET: api/<PolizasController>
        [HttpGet]
        public IEnumerable<PolizaDTO> Get()
        {
            return _polizaDao.Select();
        }

        // GET api/<PolizasController>/5
        [HttpGet("{id}")]
        public PolizaDTO Get(string id)
        {
            return _polizaDao.Select(id);
        }

        // POST api/<PolizasController>
        [HttpPost]
        public void Post([FromBody] PolizaDTO polizaDto)
        {
            _polizaDao.Insert(polizaDto);
        }

        // PUT api/<PolizasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PolizaDTO polizaDto)
        {
            _polizaDao.Update(polizaDto);
        }

        // DELETE api/<PolizasController>/5
        [HttpDelete("{id}")]
        public void Delete(PolizaDTO polizaDto)
        {
            _polizaDao.Delete(polizaDto);
        }
    }
}
