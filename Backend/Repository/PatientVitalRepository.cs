using Backend.Models;
using Backend.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository
{
    public class PatientVitalRepository : IPatientVitalRepository
    {
        private readonly string _csvFilePath = @"D:\a\alert-to-care-s21b1\alert-to-care-s21b1\Backend\Vitals.csv";
        private readonly VitalsDataHandler _vitalsDataHandler;
        public PatientVitalRepository()
        {
            _vitalsDataHandler = new VitalsDataHandler();
        }
        public List<PatientVitalsModel> ReadVitals()
        {
           
            return _vitalsDataHandler.ReadVitals(_csvFilePath);
        }
        public List<VitalsModel> ReadPatientVitals(string patientId)
        {
            var list = _vitalsDataHandler.ReadVitals(_csvFilePath);
            var temp = list.FindAll(vitals => vitals.PatientId == patientId);
            if (temp != null && temp.Any())
            {
                return temp[0].Vitals;
            }
            return new List<VitalsModel>();
        }
        public void WriteVitals(PatientVitalsModel patientVitals)
        {
             _vitalsDataHandler.WriteVitals(patientVitals, _csvFilePath);
        }
        public void DeletePatientVitals(string patientId)
        {
            _vitalsDataHandler.DeletePatientVitals(patientId, _csvFilePath);
        }
        public void StartUpdate()
        {
            var timer = new System.Threading.Timer(e => new VitalsHelper().UpdateVitalsRegularly(), null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            timer.Change(0, 10);
        }
    }
}

