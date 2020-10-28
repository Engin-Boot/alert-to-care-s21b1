using System;
using System.Collections.Generic;


namespace Backend.Utility
{
    public class PatientDataHandler
    {
        private readonly CsvHandler _csvHandler;
        public PatientDataHandler()
        {
            _csvHandler = new CsvHandler();
        }
        //public List<Models.PatientModel> patients = new List<Models.PatientModel>();
        public List<Models.PatientModel> ReadPatients(string filepath)
        {
            List<string> details =_csvHandler.ReadDetailsFromFile(filepath);
            List<Models.PatientModel> allPatients = new List<Models.PatientModel>();
            foreach(var line in details)
            {
                allPatients.Add(FormatStringToPatientObject(line.Split(',')));
            }
            return allPatients;
        }
        private Models.PatientModel FormatStringToPatientObject(string[] patientDetails)
        {

            Models.PatientModel patient = new Models.PatientModel()
            {
                PatientId = patientDetails[0],
                Name = patientDetails[1],
                Age = Int32.Parse(patientDetails[2]),
                IcuId = patientDetails[3],
                BedId = patientDetails[4],
                Address = patientDetails[5],
                Gender = patientDetails[6],
                ContactNo = patientDetails[7]
            };
            return patient;
        }
        public bool WritePatient(Models.PatientModel patient,string filepath)
        {
            string patientDetails = FormatPatientObjectToString(patient);
            return _csvHandler.WriteToFile(patientDetails, filepath);
        }
        private string FormatPatientObjectToString(Models.PatientModel patient)
        {
            var csvFormatData = "";
            if (patient.PatientId != null)
            {
                csvFormatData = string.Join(',', new object[]{
                    patient.PatientId,
                    patient.Name,
                    patient.Age.ToString(),
                    patient.IcuId,
                    patient.BedId,
                    patient.Address,
                    patient.Gender,
                    patient.ContactNo
                });
            }
            return csvFormatData;
        }

        public bool DeletePatient(string id,string filepath)
        {
            return _csvHandler.DeleteFromFile(id, filepath);
        }
    }
}
