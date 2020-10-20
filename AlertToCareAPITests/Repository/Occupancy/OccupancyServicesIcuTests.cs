using AlertToCareAPI.Models;
using AlertToCareAPI.Repository.Occupancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AlertToCareAPI.Repository.Occupancy.Tests
{
    public class OccupancyServicesIcuTests : AlertToCareAPITests.Repository.InMemoryContext
    {
        [Fact]
        public void TestForAdditionOfValidIcu()
        {
            var occupancyServices = new OccupancyServices(Context);
            string actual = occupancyServices.AddIcu(new IcuModel()
            {
                IcuId = "ICU05",
                Layout = "L00",
                Beds = new List<BedModel>(),
                MaxBeds = 15,
                NoOfBeds = 0
            });
            string expected = "ICU Added";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestForAdditionOfExistingIcu()
        {
            var occupancyServices = new OccupancyServices(Context);
            string actual = occupancyServices.AddIcu(new IcuModel()
            {
                IcuId = "ICU01",
                Layout = "L00",
                Beds = new List<BedModel>(),
                MaxBeds = 15,
                NoOfBeds = 0
            });
            string expected = "Icu with same id exists";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestForAdditionOfIcuWithMAxBedsEqualstoZero()
        {
            var occupancyServices = new OccupancyServices(Context);
            string actual = occupancyServices.AddIcu(new IcuModel()
            {
                IcuId = "ICU05",
                Layout = "L00",
                Beds = new List<BedModel>(),
                MaxBeds = 0,
                NoOfBeds = 0
            });
            string expected = "ICU doesn't meet the conditions to be added";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestForAdditionOfIcuWithBedsPointingToNUll()
        {
            var occupancyServices = new OccupancyServices(Context);
            string actual = occupancyServices.AddIcu(new IcuModel()
            {
                IcuId = "ICU05",
                Layout = "L00",
                Beds = null,
                MaxBeds = 5,
                NoOfBeds = 0
            });
            string expected = "ICU doesn't meet the conditions to be added";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestForRemovingIcuWithPatients()
        {
            var occupancyServices = new OccupancyServices(Context);
            string expected = "Icu has patients, Cannot remove icu";
            string actual = occupancyServices.RemoveIcu("ICU01");
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestForRemovingIcuWithNoPatients()
        {
            var occupancyServices = new OccupancyServices(Context);
            string expected = "Removed";
            string actual = occupancyServices.RemoveIcu("ICU02");
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestForAddingBedInNonFullExistingIcu()
        {
            var occupancyServices = new OccupancyServices(Context);
            string expected = "New Bed Added..! BedId: ICU02U004";
            string actual = occupancyServices.AddBed("ICU02");
            var bed = occupancyServices.GetBed("ICU02", "ICU02U004");
            Assert.Equal("Free", bed.BedOccupancyStatus);
            Assert.Equal("not specified", bed.Location);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestForAddingBedInExistingIcuWithNoAvailableSpace()
        {
            var occupancyServices = new OccupancyServices(Context);
            string expected = "Icu is Full";
            string actual = occupancyServices.AddBed("ICU01");
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestForAddingBedInNonExistingIcu()
        {
            var occupancyServices = new OccupancyServices(Context);
            string expected = "Icu not found";
            string actual = occupancyServices.AddBed("ICU04");
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestForRemovingBedInNonExistingIcu()
        {
            var occupancyServices = new OccupancyServices(Context);
            string expected = "Bed Doesn't Exist";
            string actual = occupancyServices.RemoveBed("ICU04","asdfg");
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestForRemovingExistingFreeBedInExistingIcu()
        {
            var occupancyServices = new OccupancyServices(Context);
            string expected = "Removed";
            string actual = occupancyServices.RemoveBed("ICU01", "ICU01L002");
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestForRemovingExistingOccupiedBedInExistingIcu()
        {
            var occupancyServices = new OccupancyServices(Context);
            string expected = "Bed is occupied";
            string actual = occupancyServices.RemoveBed("ICU01", "ICU01L001");
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestForRemovingNonExistingBedInExistingIcu()
        {
            var occupancyServices = new OccupancyServices(Context);
            var expected = "Bed Doesn't Exist";
            var actual = occupancyServices.RemoveBed("ICU01", "asdfg");
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestForGettingAllIcu()
        {
            var occupancyServices = new OccupancyServices(Context);
            var actualAllIcus = occupancyServices.GetAllIcu();
            var originalAllIcus = Context.Icu.ToList();
            foreach(var actualIcu in actualAllIcus)
            {
                var originalIcu = originalAllIcus.Find(icu => icu.IcuId == actualIcu.IcuId);
                Assert.NotNull(originalIcu);
            }

        }
        [Fact]
        public void TestForGettingAvailableBedsFromNonExistingIcu()
        {
            var occupancyServices = new OccupancyServices(Context);
            var freeBeds = occupancyServices.AvailableBeds("ICU04");
            Assert.Equal(0, freeBeds.LongCount());
        }
        [Fact]
        public void TestForGettingAvailableBedsFromExistingIcu()
        {
            var occupancyServices = new OccupancyServices(Context);
            var freeBeds = occupancyServices.AvailableBeds("ICU02");
            Assert.Equal(3, freeBeds.LongCount());
        }
        [Fact]
        public void TestForGettingAvailableBedsFromAllExistingIcus()
        {
            var occupancyServices = new OccupancyServices(Context);
            var freeBeds = occupancyServices.AvailableBeds();
            Assert.Equal(4, freeBeds.LongCount());
        }
    }
}