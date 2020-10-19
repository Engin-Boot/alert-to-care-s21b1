using AlertToCareAPI.Models;
using AlertToCareAPI.Repository.Occupancy;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlertToCareAPI.Repository.Occupancy.Tests
{
    public class OccupancyServicesTests
    {
        OccupancyServices occupancyServices = new OccupancyServices();
        [Fact]
        public void AddIcuTest()
        {
            string actual = occupancyServices.AddIcu(new Models.IcuModel()
            {
                IcuId = "ICU05",
                Layout = "L00",
                Beds = null,
                MaxBeds = 15,
                NoOfBeds = 0
            });
            string expected = "ICU Added";
            Console.WriteLine(actual);
            Assert.Equal(expected, actual);
        }
    }
}