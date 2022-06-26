using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proveedores.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotizacionController : ControllerBase
    {
        // GET: api/<CotizacionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CotizacionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /*// POST api/<CotizacionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }*/

        // PUT api/<CotizacionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CotizacionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
