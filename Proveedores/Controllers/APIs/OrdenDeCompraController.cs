using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proveedores.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenDeCompraController : ControllerBase
    {
        // GET: api/<OrdenDeCompraController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrdenDeCompraController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /*// POST api/<OrdenDeCompraController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }*/

        // PUT api/<OrdenDeCompraController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /*// DELETE api/<OrdenDeCompraController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
