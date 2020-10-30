using Backend.Models;
using Backend.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

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
            return _vitalsDataHandler.ReadVitals(_csvFilePath).Find(vitals => vitals.PatientId == patientId).Vitals;
        }
        public bool WriteVitals(PatientVitalsModel patientVitals)
        {
            return _vitalsDataHandler.WriteVitals(patientVitals, _csvFilePath);
        }
        public bool DeletePatientVitals(string patientId)
        {
            return _vitalsDataHandler.DeletePatientVitals(patientId, _csvFilePath);
        }
        public void StartUpdate()
        {
            new System.Threading.Timer(e => new VitalsHelper().UpdateVitalsRegularly(), null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            
        }
    }
}
