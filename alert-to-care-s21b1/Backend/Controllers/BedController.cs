using System;
using System.Collections.Generic;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/beds")]
    [ApiController]
    public class BedController : Controller
    {
        private readonly IBedRepository _bedRepository;
        public BedController(IBedRepository bedRepository)
        {
            this._bedRepository = bedRepository;
        }
        
        [HttpGet("{id}")]
        public List<Models.BedModel> GetAllBedsInIcu(string id)
        {
            return (List<Models.BedModel>)_bedRepository.GetAllBedsFromAnIcu(id);
        }
        
        [HttpGet]
        public List<Models.BedModel> GetAllBeds()
        {
            return (List<Models.BedModel>)_bedRepository.GetAllBeds();
        }
        
        /*[HttpGet("{id}")]
        public List<Models.BedModel> GetBeds(string id)
        {
            List<Models.BedModel> allBeds = (List<Models.BedModel>)_bedRepository.AvailableBeds();
            return allBeds.FindAll(bed => bed.IcuId == id);
        }
        */
        [HttpPost("{icuId}")]
        public IActionResult AddBed(string icuId)
        {
            try
            {
               bool isAdded = _bedRepository.AddBed(icuId);
                if (isAdded)
                    return Json("Bed added to ICU");
                else
                    return Json("Could not add bed: ICU has reached max capacity");
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to add Bed");
            }

        }

        [HttpPost("{icuId}/{location}")]
        public IActionResult AddBedWithLocation(string icuId, string location)
        {
            try
            {
                bool msg = _bedRepository.AddBed(icuId, location);
                return Ok(msg);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to add Bed");
            }

        }

        [HttpDelete("{icuId}/{bedId}")]
        public IActionResult RemoveBed(string icuId, string bedId)
        {
            try
            {
                bool isDeleted = _bedRepository.RemoveBed(icuId, bedId);
                if (isDeleted)
                    return Json("Bed Removed from ICU");
                else
                    return Json("Bed could not be deleted: Bed is not free");
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to remove Bed");
            }

        }
    }
}
