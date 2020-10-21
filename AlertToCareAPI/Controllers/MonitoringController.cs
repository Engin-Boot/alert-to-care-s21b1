using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCareAPI.Models;
using AlertToCareAPI.Repository.Monitoring;
using AlertToCareAPI.Utility;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlertToCareAPI.Controllers
{
    [Route("api/monitoring/[controller]")]
    [ApiController]
    public class MonitoringController : ControllerBase
    {
        readonly IMonitoringRepository _monitoringRepository;

        public MonitoringController(IMonitoringRepository repository)
        {
            this._monitoringRepository = repository;
        }

        //GET:

        [HttpGet]
        public IEnumerable<PatientModel> Get()
        {
            return _monitoringRepository.AllPatientVitalWithDetails();
        }


        [HttpGet("Patientid")]
        public List<VitalsModel> Get(string Patientid)
        {

            return _monitoringRepository.PatientVital(Patientid);
        }

        //[HttpGet("Alert")]
        //public Dictionary<string, string> Alert()
        //{
        //    return _monitoringRepository.TurnOnAlert();
        //}

        [HttpGet("Alert")]
        public IActionResult Alert()
        {
            return Ok(_monitoringRepository.TurnOnAlert());
        }



        [HttpDelete("Alert/{bedId}")]
        public IActionResult AlertOff(string bedId)
        {
            if (bedId == null)
            {
                return BadRequest("INVALID BED ID");
            }
            try
            {
                _monitoringRepository.TurnOffAlert(bedId);
            }
            catch
            {
                return StatusCode(500);
            }
            return Ok();
        }


        [HttpPut("UpdateVital/{patientId}/{bpmvalue}/{spo2value}/{respRatevalue}")]
        public ActionResult<IEnumerable<dynamic>> Put(string patientId, float bpmvalue, float spo2value, float respRatevalue)
        {
            if (patientId == null)
            {
                return BadRequest("INVALID INPUT OF ID");

            }
            try
            {
                return Ok(_monitoringRepository.UpdateVital(patientId, bpmvalue, spo2value, respRatevalue));
            }
            catch
            {
                return StatusCode(500, "unable to insert patient information");

            }
        }

        // GET: api/<MonitoringController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<MonitoringController>/5
        //[HttpGet("vitalName")]
        //public VitalsModel Get(string vitalName)
        //{
        //    try
        //    {
        //        return _monitoringRepository.FetchVital(vitalName);
        //    }
        //    catch
        //    {
        //        throw  new Exception("no found");
        //    }
        //}

        //// POST api/<MonitoringController>
        //[HttpPost("VitalName")]
        //public IActionResult AddNewVital([FromBody] VitalsModel vital)
        //{

        //    try
        //    {
        //        _monitoringRepository.AddNewVital(vital);
        //    }
        //    catch(Exception)
        //    {
        //        return StatusCode(500, "unable to insert new vital");
        //    }

        //    return Ok("Insert successful");
        //}

        //// PUT api/<MonitoringController>/5
        //[HttpGet("Alert")]
        //public string Alerting([FromBody] string vitalName)
        //{
        //    try
        //    {
        //       return _monitoringRepository.Alarm(vitalName);
        //    }
        //    catch(Exception)
        //    {
        //        return "unable to find it";

        //    }
        //}




        //// DELETE api/<MonitoringController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
