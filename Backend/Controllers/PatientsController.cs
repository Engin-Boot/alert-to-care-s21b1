using System;
using System.Collections.Generic;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : Controller
    {
        private readonly IPatientRepository _patientRepository;

        public PatientsController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        // GET: api/<PatientsController>
        [HttpGet]
        public IEnumerable<Models.PatientModel> Get()
        {
            return _patientRepository.GetAllPatients();
        }

        // GET api/<PatientsController>/5
        [HttpGet("{id}")]
        public Models.PatientModel Get(string id)
        {
            return _patientRepository.GetPatient(id);
        }

        // POST api/<PatientsController>
        [HttpPost]
        public IActionResult Post([FromBody] Models.PatientModel newPatient)
        {
            try
            {
              
                var msg = _patientRepository.AddPatient(newPatient);
                if (msg)
                    return Json("Patient added to the bed");
                else
                    return Json("Patient couldnot be added");
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to insert new Patient");
            }
        }

       

        // DELETE api/<PatientsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var msg = _patientRepository.DischargePatient(id);
                if (msg)
                    return Json("Patient Discharged!");
                else
                    return Json("Patient could not be discharged");
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to discharge Patient");
            }
        }
    }
}
