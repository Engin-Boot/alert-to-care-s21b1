using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Utility
{
    public class VitalsDataHandler
    {
        private readonly CsvHandler _csvHandler;
        public VitalsDataHandler()
        {
            _csvHandler = new CsvHandler();
        }
        public List<Models.PatientVitalsModel> ReadVitals(string filepath)
        {
            List<string> csvData = _csvHandler.ReadDetailsFromFile(filepath);
            var vitals = new List<PatientVitalsModel>();
            foreach(var line in csvData)
            {
                vitals.Add(FormatStringtoPatientVitalsModel(line.Split(',')));
            }
            return vitals;
        }
        private PatientVitalsModel FormatStringtoPatientVitalsModel(string[] values)
        {
            var vitalsList = new List<VitalsModel>();
            for(int i= 1; i < values.Length; i++)
            {
                string[] vital = values[i].Split(" ");
                var tempVital = new VitalsModel()
                {
                    VitalName = vital[0],
                    Value = float.Parse(vital[1]),
                    Lower = float.Parse(vital[2]),
                    Upper = float.Parse(vital[3])
                };
                vitalsList.Add(tempVital);
            }
            var _patientVitals = new PatientVitalsModel()
            {
                PatientId = values[0],
                Vitals = vitalsList
            };
            return _patientVitals;
        }

        public bool WriteVitals(PatientVitalsModel patientVitals, string filepath)
        {
            return _csvHandler.WriteToFile(FormatPatientVitalsModelToString(patientVitals), filepath);
        }
        private string FormatPatientVitalsModelToString(PatientVitalsModel patientVitals)
        {

            string vitalString = "";
            foreach(var vital in patientVitals.Vitals)
            {
                vitalString += vital.VitalName + " ";
                vitalString += vital.Value.ToString() + " ";
                vitalString += vital.Lower.ToString() + " ";
                vitalString += vital.Upper.ToString() + ",";
            }
            vitalString = vitalString[0..^1];

            var csvData = patientVitals.PatientId + ",";
            csvData += vitalString;
            return csvData;
        }
        public bool DeletePatientVitals(string patientId, string filepath)
        {
            return _csvHandler.DeleteFromFile(patientId, filepath);
        }
    }
}
