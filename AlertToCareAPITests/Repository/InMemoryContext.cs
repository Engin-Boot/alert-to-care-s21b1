using AlertToCareAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DbContext = AlertToCareAPI.Models.AppDbContext;

namespace AlertToCareAPITests.Repository
{
    public class InMemoryContext : IDisposable
    {
        protected readonly DbContext Context;

        protected InMemoryContext()
        {
            var option = new DbContextOptionsBuilder<DbContext>().UseInMemoryDatabase(
                databaseName: Guid.NewGuid().ToString()).Options;
            Context = new DbContext(option);
            Context.Database.EnsureCreated();
            InitializeDatabase(Context);

        }

        private void InitializeDatabase(DbContext context)
        {
            #region Beds
            var icu1Beds = new List<BedModel>() { 
                new BedModel() { BedId = "ICU01L001",BedOccupancyStatus="Occupied",Location="First bed" },
                new BedModel() { BedId = "ICU01L002",BedOccupancyStatus="Free",Location="Second bed" },
                new BedModel() { BedId = "ICU01L003",BedOccupancyStatus="Occupied",Location="Third bed" }
            };
            var icu2Beds = new List<BedModel>() {
                new BedModel() { BedId = "ICU02U001",BedOccupancyStatus="Free",Location="First bed" },
                new BedModel() { BedId = "ICU02U002",BedOccupancyStatus="Free",Location="Second bed" },
                new BedModel() { BedId = "ICU02U003",BedOccupancyStatus="Free",Location="Third bed" }
            };
            #endregion

            #region Vitals

            var patient1Vitals = new List<VitalsModel>() {
                new VitalsModel(){ Name = "Resp", Value = 80, LowerLimit = 70, UpperLimit = 150 },
                new VitalsModel(){ Name = "Bp", Value = 80, LowerLimit = 80, UpperLimit = 150 },
                new VitalsModel(){ Name = "Spo2", Value = 80, LowerLimit = 90, UpperLimit = 100 },
            };
            var patient2Vitals = new List<VitalsModel>() {
                new VitalsModel(){ Name = "Resp", Value = 80, LowerLimit = 70, UpperLimit = 150 },
                new VitalsModel(){ Name = "Bp", Value = 80, LowerLimit = 80, UpperLimit = 150 },
                new VitalsModel(){ Name = "Spo2", Value = 80, LowerLimit = 90, UpperLimit = 100 },
            };

            #endregion

            #region ICU's
            var icu1 = new IcuModel()
            {
                IcuId = "ICU01",
                Layout = "L00",
                Beds = icu1Beds,
                MaxBeds = 3,
                NoOfBeds = 3
            };
            var icu2 = new IcuModel()
            {
                IcuId = "ICU02",
                Layout = "U00",
                Beds = icu2Beds,
                MaxBeds = 15,
                NoOfBeds = 3
            };
            #endregion

            #region Patients

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

            var patient2 = new PatientModel()
            {
                PatientId = "P002",
                Name = "Naresh",
                Age = 25,
                Address = "Hyderabad",
                IcuId = "ICU01",
                BedId = "ICU01L003",
                Vitals = patient2Vitals
            };
            #endregion

            
            context.Icu.Add(icu1);
            context.Icu.Add(icu2);
            context.Patients.Add(patient1);
            context.Patients.Add(patient2);

            context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
