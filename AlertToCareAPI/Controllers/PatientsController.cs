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
    [Route("api/occupancy/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IOccupancyServices occupancyServices;

        public PatientsController(IOccupancyServices _occupancyServices)
        {
            occupancyServices = _occupancyServices;
        }
        // GET: api/<PatientsController>
        [HttpGet]
        public IEnumerable<PatientModel> Get()
        {
            return occupancyServices.GetAllPatients();
        }

        // GET api/<PatientsController>/5
        [HttpGet("{id}")]
        public PatientModel Get(string id)
        {
            return occupancyServices.GetPatient(id);
        }

        // POST api/<PatientsController>
        [HttpPost]
        public IActionResult Post([FromBody] PatientModel newPatient)
        {
            try
            {
                var msg = occupancyServices.AddPatient(newPatient);
                return Ok(msg);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to insert new Patient");
            }
        }

        // PUT api/<PatientsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PatientsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var msg = occupancyServices.DischargePatient(id);
                return Ok(msg);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to discharge Patient");
            }
        }
    }
}
