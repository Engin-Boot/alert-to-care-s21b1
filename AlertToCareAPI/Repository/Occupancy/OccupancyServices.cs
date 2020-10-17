using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCareAPI.Models;

namespace AlertToCareAPI.Repository.Occupancy
{
    public class OccupancyServices:IOccupancyServices
    {
        private readonly AppDbContext _context;

        public OccupancyServices(AppDbContext context)
        {
            _context = context;
            _context.Patients.Add(new PatientModel()
            {
                Name = "jay",
                Age = 22,
                Address = "Chevella",
                BedId = "L013",
                IcuId = "ICU01",
                PatientId = "002",
                Vitals = null
            });
            _context.SaveChanges();
            //foreach (var patient in _context.Patients)
            //{
            //    Console.WriteLine("Patient Name:"+patient.Name);
            //}
        }

        public string AddIcu(IcuModel newIcu)
        {
            _context.Icu.Add(newIcu);
            _context.SaveChanges();
            return "ICU Added";
        }

        public string AddBed(string icuId, BedModel newBed)
        {
            throw new NotImplementedException();
        }

        public string AddPatient(PatientModel newPatient)
        {
            _context.Patients.Add(newPatient);
            return "Implement";
        }

        public string DischargePatient(string patientId)
        {
            throw new NotImplementedException();
        }

        public string RemoveIcu(string icuId)
        {
            throw new NotImplementedException();
        }

        public string RemoveBed(string icuId, string bedId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BedModel> AvailableBeds()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientModel> GetAllPatients()
        {
            //_context.Patients.Add(new PatientModel()
            //{
            //    Name = "Ajay",
            //    Age = 22,
            //    Address = "Chevella",
            //    BedId = "L012",
            //    IcuId = "ICU01",
            //    PatientId = "001",
            //    Vitals = null
            //});
            //if (_context.Patients == null)
            //{
            //    Console.WriteLine("Null");
            //}
            //else
            //{
            //    Console.WriteLine("Not Null"+_context.Patients.Find("001").Name);
            //}
            //foreach (var patient in _context.Patients)
            //{
            //    Console.WriteLine("Patient Name:"+patient.Name);
            //}
            Console.WriteLine("In Fun");
            return _context.Patients.ToList();
        }

        
    }
}
