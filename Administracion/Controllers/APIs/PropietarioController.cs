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
    public class PropietarioController : ControllerBase
    {
        private readonly PropietarioDAO _propietarioDao;

        public PropietarioController(PropietarioDAO propietarioDao)
        {
            _propietarioDao = propietarioDao;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public IEnumerable<PropietarioDTO> Get()
        {
            return _propietarioDao.Select();
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return _propietarioDao.Select();
        }

        // POST api/<ClienteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
