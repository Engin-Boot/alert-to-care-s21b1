using Backend.Models;
using Backend.Utility;
using System;
using System.Collections.Generic;


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
            var list = new List<VitalsModel>();
            list = _vitalsDataHandler.ReadVitals(_csvFilePath).Find(vitals => vitals.PatientId == patientId).Vitals;
            return list;
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
        }
    }
}
