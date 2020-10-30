using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/vitals")]
    [ApiController]
    public class VitalsController : Controller
    {
        private readonly IPatientVitalRepository _patientVitalRepository;
        public VitalsController(IPatientVitalRepository patientVitalRepository)
        {
            this._patientVitalRepository = patientVitalRepository;
        }
        [HttpGet]
        public List<PatientVitalsModel> Get()
        {
            return _patientVitalRepository.ReadVitals();
        }
        [HttpGet("{patientId}")]
        public List<VitalsModel> Get(string patientId)
        {
            return _patientVitalRepository.ReadPatientVitals(patientId);
        }
        [HttpPost]
        public ActionResult Post([FromBody] PatientVitalsModel patientVitals)
        {
            return Json(_patientVitalRepository.WriteVitals(patientVitals));
        }
        [HttpDelete("{patientId}")]
        public ActionResult Delete(string patientId)
        {
            return Json(_patientVitalRepository.DeletePatientVitals(patientId));
        }
        [HttpPut]
        public void Update()
        {
            Console.WriteLine("Update Called");
            _patientVitalRepository.StartUpdate();
        }
    }
}
