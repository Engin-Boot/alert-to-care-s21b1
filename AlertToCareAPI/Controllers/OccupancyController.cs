using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCareAPI.Models;
using AlertToCareAPI.Repository.Occupancy;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlertToCareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupancyController : ControllerBase
    {
        private readonly IOccupancyServices _occupancyServices;

        public OccupancyController(Repository.Occupancy.IOccupancyServices occupancyServices)
        {
            _occupancyServices = occupancyServices;
        }
        // GET: api/<OccupancyController>
        [HttpGet]
        public IEnumerable<PatientModel> Get()
        {
            Console.WriteLine("In Get");
            return _occupancyServices.GetAllPatients();
        }

        // GET api/<OccupancyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OccupancyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OccupancyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OccupancyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
