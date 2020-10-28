﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/icus")]
    [ApiController]
    public class IcuController : Controller
    {
        private readonly IIcuRepository _icuRepository;

        public IcuController(IIcuRepository icuRepository)
        {
            this._icuRepository = icuRepository;
        }
        // GET: api/<IcuController>
        [HttpGet]
        public IEnumerable<Models.IcuModel> Get()
        {
            return _icuRepository.GetAllIcu();
        }

        // GET api/<IcuController>/5
        [HttpGet("{id}")]
        public Models.IcuModel Get(string id)
        {
           return  _icuRepository.GetIcu(id);
        }

        // POST api/<IcuController>
        [HttpPost]
        public IActionResult Post([FromBody] Models.IcuModel icu)
        {
            try
            {
                bool isAdded = _icuRepository.AddIcu(icu);
                if (isAdded)
                    return Json("ICU added successfully");
                else
                    return Json("ICU could not be added");
            }
            catch (Exception)
            {
                return Json("Internal server error");
            }
            
        }

        // PUT api/<IcuController>/5
        [HttpPut("{id}")]
        public void Put(int id)
        {
        }

        // DELETE api/<IcuController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                bool isDeleted = _icuRepository.RemoveIcu(id);
                if (isDeleted)
                    return Json("ICU deleted successfully");
                else
                    return Json("ICU could not be deleted: Has occupied beds");
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to remove ICU");
            }

        }

    }
}
