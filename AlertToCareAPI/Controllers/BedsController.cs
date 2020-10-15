using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCareAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlertToCareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedsController : ControllerBase
    {
        private readonly Repository.ITest _test;

        public BedsController(Repository.ITest test)
        {
            this._test = test;
        }

        // GET: api/<BedsController>
        [HttpGet]
        public IEnumerable<Bed> Get()
        {
            return _test.GetAllBeds();
        }

        // GET api/<BedsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BedsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BedsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BedsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
