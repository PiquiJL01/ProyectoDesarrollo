using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RegistroDeIncidentesPeritos.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidenteController : ControllerBase
    {
        // GET: api/<IncidenteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<IncidenteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /*// POST api/<IncidenteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }*/

        // PUT api/<IncidenteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /*// DELETE api/<IncidenteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
