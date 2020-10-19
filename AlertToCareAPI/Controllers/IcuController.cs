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
    public class IcuController : ControllerBase
    {
        private readonly IOccupancyServices occupancyServices;

        public IcuController(IOccupancyServices _occupancyServices)
        {
            this.occupancyServices = _occupancyServices;
        }
        // GET: api/<IcuController>
        [HttpGet]
        public IEnumerable<IcuModel> Get()
        {
            return occupancyServices.GetAllIcu();
        }

        // GET api/<IcuController>/5
        [HttpGet("{id}")]
        public IcuModel Get(string id) => occupancyServices.GetIcu(id);

        // POST api/<IcuController>
        [HttpPost]
        public IActionResult Post([FromBody] IcuModel icu)
        {
            try
            {
                string msg = occupancyServices.AddIcu(icu);
                return Ok(msg);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to add ICU");
            }
            
        }

        // PUT api/<IcuController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IcuController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                string msg = occupancyServices.RemoveIcu(id);
                return Ok(msg);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to remove ICU");
            }

        }

        [HttpGet("beds/availableBeds")]
        public IEnumerable<BedModel> GetAllAvailableBeds()
        {
            return occupancyServices.AvailableBeds();
        }

        [HttpGet("beds/availableBeds/{id}")]
        public IEnumerable<BedModel> GetAvailableBedsInIcu(string icuId)
        {
            return occupancyServices.AvailableBeds(icuId);
        }

        [HttpPost("beds/addBed/{icuId}")]
        public IActionResult AddBed(string icuId)
        {
            try
            {
                string msg = occupancyServices.AddBed(icuId);
                return Ok(msg);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to add Bed");
            }

        }

        [HttpPost("beds/addBed/{icuId}/{location}")]
        public IActionResult AddBedWithLocation(string icuId, string location)
        {
            try
            {
                string msg = occupancyServices.AddBed(icuId,location);
                return Ok(msg);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to add Bed");
            }

        }

        [HttpDelete("beds/remove/{icuId}/{bedId}")]
        public IActionResult RemoveBed(string icuId, string bedId)
        {
            try
            {
                string msg = occupancyServices.RemoveBed(icuId, bedId);
                return Ok(msg);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to remove Bed");
            }

        }

    }
}
