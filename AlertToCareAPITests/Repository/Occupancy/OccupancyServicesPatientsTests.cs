using AlertToCareAPI.Models;
using AlertToCareAPI.Repository.Occupancy;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AlertToCareAPITests.Repository.Occupancy
{
    public class OccupancyServicesPatientsTests : InMemoryContext
    {
        [Fact]
        public void TestForGettingPatientGivenExistingPatientId()
        {
            var patient1Vitals = new List<VitalsModel>() {
                new VitalsModel(){ Name = "Resp", Value = 80, LowerLimit = 70, UpperLimit = 150 },
                new VitalsModel(){ Name = "Bp", Value = 80, LowerLimit = 80, UpperLimit = 150 },
                new VitalsModel(){ Name = "Spo2", Value = 80, LowerLimit = 90, UpperLimit = 100 },
            };
            var patient1 = new PatientModel()
            {
                PatientId = "P001",
                Name = "Suresh",
                Age = 25,
                Address = "Hyderabad",
                IcuId = "ICU01",
                BedId = "ICU01L001",
                Vitals = patient1Vitals
            };

            var occupancyServices = new OccupancyServices(Context);
            var patient = occupancyServices.GetPatient("P001");
            ArePatientsSame(patient, patient1);


        }
        [Fact]
        public void TestForGettingAllpatients()
        {
            var occupancyServices = new OccupancyServices(Context);
            var patients = occupancyServices.GetAllPatients();
            Assert.Equal(2, patients.LongCount());
        }
        [Fact]
        public void TestForAddingNonExistingPatientIntoExistingIcuWithEmptyBed()
        {
            var occupancyServices = new OccupancyServices(Context);
            var patientVitals = new List<VitalsModel>() {
                new VitalsModel(){ Name = "Resp", Value = 80, LowerLimit = 70, UpperLimit = 150 },
                new VitalsModel(){ Name = "Bp", Value = 80, LowerLimit = 80, UpperLimit = 150 },
                new VitalsModel(){ Name = "Spo2", Value = 80, LowerLimit = 90, UpperLimit = 100 },
            };
            var patient = new PatientModel()
            {
                PatientId = "P003",
                Name = "Mahesh",
                Age = 25,
                Address = "Hyderabad",
                IcuId = "ICU02",
                BedId = "ICU02U001",
                Vitals = patientVitals
            };
            var expected = "Patient Added Successfully";
            var actual = occupancyServices.AddPatient(patient);
            Assert.Equal(expected, actual);
            ArePatientsSame(patient, occupancyServices.GetPatient("P003"));
            Assert.Equal("Occupied", occupancyServices.GetBed("ICU02", "ICU02U001").BedOccupancyStatus);
        }
        [Fact]
        public void TestForAddingExistingPatient()
        {
            var occupancyServices = new OccupancyServices(Context);
            var patientVitals = new List<VitalsModel>() {
                new VitalsModel(){ Name = "Resp", Value = 80, LowerLimit = 70, UpperLimit = 150 },
                new VitalsModel(){ Name = "Bp", Value = 80, LowerLimit = 80, UpperLimit = 150 },
                new VitalsModel(){ Name = "Spo2", Value = 80, LowerLimit = 90, UpperLimit = 100 },
            };
            var patient = new PatientModel()
            {
                PatientId = "P001",
                Name = "Mahesh",
                Age = 25,
                Address = "Hyderabad",
                IcuId = "ICU01",
                BedId = "ICU01L001",
                Vitals = patientVitals
            };
            var expected = "Patient Already Exists";
            var actual = occupancyServices.AddPatient(patient);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestForAddingNonExistingPatientToOccupiedBed()
        {
            var occupancyServices = new OccupancyServices(Context);
            var patientVitals = new List<VitalsModel>() {
                new VitalsModel(){ Name = "Resp", Value = 85, LowerLimit = 70, UpperLimit = 150 },
                new VitalsModel(){ Name = "Bp", Value = 89, LowerLimit = 80, UpperLimit = 150 },
                new VitalsModel(){ Name = "Spo2", Value = 95, LowerLimit = 90, UpperLimit = 100 },
            };
            var patient = new PatientModel()
            {
                PatientId = "P003",
                Name = "Mahesh",
                Age = 25,
                Address = "Hyderabad",
                IcuId = "ICU01",
                BedId = "ICU01L001",
                Vitals = patientVitals
            };
            var expected = "Bed is occupied";
            var actual = occupancyServices.AddPatient(patient);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestForAddingNonExistingPatientToNonExistingIcu()
        {
            var occupancyServices = new OccupancyServices(Context);
            var patientVitals = new List<VitalsModel>() {
                new VitalsModel(){ Name = "Resp", Value = 85, LowerLimit = 70, UpperLimit = 150 },
                new VitalsModel(){ Name = "Bp", Value = 89, LowerLimit = 80, UpperLimit = 150 },
                new VitalsModel(){ Name = "Spo2", Value = 95, LowerLimit = 90, UpperLimit = 100 },
            };
            var patient = new PatientModel()
            {
                PatientId = "P003",
                Name = "Mahesh",
                Age = 25,
                Address = "Hyderabad",
                IcuId = "ICU04",
                BedId = "ICU01L001",
                Vitals = patientVitals
            };
            var expected = "Bed Doesn't Exist";
            var actual = occupancyServices.AddPatient(patient);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestForAddingNonExistingPatientToExistingIcuWithNonExistingBed()
        {
            var occupancyServices = new OccupancyServices(Context);
            var patientVitals = new List<VitalsModel>() {
                new VitalsModel(){ Name = "Resp", Value = 85, LowerLimit = 70, UpperLimit = 150 },
                new VitalsModel(){ Name = "Bp", Value = 89, LowerLimit = 80, UpperLimit = 150 },
                new VitalsModel(){ Name = "Spo2", Value = 95, LowerLimit = 90, UpperLimit = 100 },
            };
            var patient = new PatientModel()
            {
                PatientId = "P003",
                Name = "Mahesh",
                Age = 25,
                Address = "Hyderabad",
                IcuId = "ICU04",
                BedId = "ICU01L005",
                Vitals = patientVitals
            };
            var expected = "Bed Doesn't Exist";
            var actual = occupancyServices.AddPatient(patient);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestForRemovingExistingPatient()
        {
            var occupancyServices = new OccupancyServices(Context);
            var expected = "Patient " + "P001" + " Discharged";
            var actual = occupancyServices.DischargePatient("P001");
            Assert.Equal(expected, actual);
            Assert.Null(occupancyServices.GetPatient("P001"));
            Assert.Equal("Free", occupancyServices.GetBed("ICU01","ICU01L001").BedOccupancyStatus);

        }
        [Fact]
        public void TestForRemovingNonExistingPatient()
        {
            var occupancyServices = new OccupancyServices(Context);
            var expected = "No such patient";
            var actual = occupancyServices.DischargePatient("P006");
            Assert.Equal(expected, actual);
            
        }

        #region Helper Methods

        internal void ArePatientsSame(PatientModel p1, PatientModel p2)
        {
            Assert.True(p1.PatientId == p2.PatientId);
            Assert.True(p1.Name == p2.Name);
            Assert.True(p1.Address == p2.Address);
            Assert.True(p1.Age == p2.Age);
            Assert.True(p1.BedId == p2.BedId);
            Assert.True(p1.IcuId == p2.IcuId);
            AreVitalsEqual(p1.Vitals, p2.Vitals);
        }

        internal void AreVitalsEqual(List<VitalsModel> v1, List<VitalsModel> v2)
        {
            foreach(var vital in v1)
            {
                var vitalInAnotherList = v2.Find(_vital => _vital.Name == vital.Name);
                Assert.NotNull(vitalInAnotherList);
                Assert.Equal(vital.Value, vitalInAnotherList.Value);
                Assert.Equal(vital.UpperLimit, vitalInAnotherList.UpperLimit);
                Assert.Equal(vital.LowerLimit, vitalInAnotherList.LowerLimit);
            }
        }

        #endregion
    }

}
