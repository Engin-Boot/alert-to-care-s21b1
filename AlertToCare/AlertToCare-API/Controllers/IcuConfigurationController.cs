using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCare_API.Models;
using AlertToCare_API.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlertToCare_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IcuConfigurationController : ControllerBase
    {
        readonly IIcuConfigurationRepository _icuConfigurationRepository;

        public IcuConfigurationController(IIcuConfigurationRepository repository)
        {
            this._icuConfigurationRepository = repository;
        }

        // GET: api/<IcuConfigurationController>
        [HttpGet("IcuWards")]
        public IActionResult Get()
        {
            return Ok(_icuConfigurationRepository.GetAllIcu());
        }

        // GET api/<IcuConfigurationController>/5
        [HttpGet("IcuWards/{IcuID")]
        public IActionResult Get(string IcuId)
        {
            var icuList = _icuConfigurationRepository.GetAllIcu();
            foreach(var icu in icuList)
            {
                if(icu.IcuId==IcuId)
                {
                    return Ok(icu);
                }
            }
            return BadRequest();
        }

        // POST api/<IcuConfigurationController>
        [HttpPost("IcuWards")]
        public IActionResult Post([FromBody] Icu icu )
        {
            try
            {
                _icuConfigurationRepository.AddNewPateintInIcu(icu);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<IcuConfigurationController>/5
        [HttpPut("IcuWards/{IcuID}")]
        public IActionResult Put(string IcuID, [FromBody] Icu icu)
        {
            try
            {
                _icuConfigurationRepository.UpdatePatientInIcu(IcuID, icu);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/<IcuConfigurationController>/5
        [HttpDelete("IcuWards/{IcuID}")]
        public IActionResult Delete(string IcuID)
        {
            try
            {
                _icuConfigurationRepository.RemovePatientInIcu(IcuID);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
