using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RegistroDeIncidentesPeritos.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropietarioController : ControllerBase
    {
        // GET: api/<PropietarioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PropietarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PropietarioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
