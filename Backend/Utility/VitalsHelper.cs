using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Utility
{
    public class VitalsHelper
    {
        private readonly string _csvFilePath = @"D:\a\alert-to-care-s21b1\alert-to-care-s21b1\Backend\Vitals.csv";
        private readonly VitalsDataHandler _vitalsDataHandler = new VitalsDataHandler();
        public static readonly List<VitalsModel> _vitalNames = new List<VitalsModel>()
        {
            new VitalsModel()
            {
                VitalName="BPSys",
                Lower=80,
                Upper=90,
                Value=85
            },
            new VitalsModel()
            {
                VitalName="BPDias",
                Lower=120,
                Upper=130,
                Value=121
            },
            new VitalsModel()
            {
                VitalName="SPO2",
                Lower=90,
                Upper=100,
                Value=95
            },
            new VitalsModel()
            {
                VitalName="HeartRate",
                Lower=70,
                Upper=150,
                Value=85
            }
        };
        private float GenerateRandomNumber(float lower, float upper)
        {
            Random rand = new Random();
            return rand.Next(Convert.ToInt32(lower)-10,Convert.ToInt32(upper)+10);
        }
        private bool UpdatePatientVitals(PatientVitalsModel patientVitals)
        {
            var isUpdated = _vitalsDataHandler.DeletePatientVitals(patientVitals.PatientId, _csvFilePath);
            isUpdated &= _vitalsDataHandler.WriteVitals(patientVitals, _csvFilePath);
            return isUpdated;
        }
        public void UpdateVitalsRegularly()
        {
            var allVitals = _vitalsDataHandler.ReadVitals(_csvFilePath);
            foreach(var patientVitals in allVitals)
            {
                foreach(var vital in patientVitals.Vitals)
                {
                    vital.Value = GenerateRandomNumber(vital.Lower, vital.Upper);
                    Console.WriteLine(vital.Value);
                }
                UpdatePatientVitals(patientVitals);
            }
        }
    }
}
