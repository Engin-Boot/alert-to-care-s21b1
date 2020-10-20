using AlertToCareAPI.Models;
using AlertToCareAPI.Repository.Occupancy;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlertToCareAPI.Repository.Occupancy.Tests
{
    public class OccupancyServicesTests : AlertToCareAPITests.Repository.InMemoryContext
    {
        //readonly OccupancyServices occupancyServices = new 
        [Fact]
        public void AddIcuTest()
        {
            var occupancyServices = new OccupancyServices(Context);
            string actual = occupancyServices.AddIcu(new IcuModel()
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