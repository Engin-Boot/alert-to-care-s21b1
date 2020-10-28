using System;
using System.Collections.Generic;

namespace Backend.Repository
{
    public class PatientRepository : IPatientRepository
    {
        public readonly string _csvFilePath;
        private readonly Utility.PatientDataHandler _patientDataHandler = new Utility.PatientDataHandler();
        private readonly Utility.Helpers _helpers = new Utility.Helpers();
        public PatientRepository()
        {
            this._csvFilePath = @"D:\a\alert-to-care-s21b1\alert-to-care-s21b1\Backend\Patients.csv";
        }
        public IEnumerable<Models.PatientModel> GetAllPatients()
        {
            return _patientDataHandler.ReadPatients(_csvFilePath);
        }

        public bool AddPatient(Models.PatientModel newPatient)
        {
            bool isAdded = false;
            string message = "";
            try
            {
                if (_helpers.CanPatientBeAdded(newPatient, out message))
                {
                    isAdded = _patientDataHandler.WritePatient(newPatient, _csvFilePath);
                    _helpers.ChangeBedStatusToOccupied(newPatient.BedId);
                }

            }
            catch (Exception e)
            {
                isAdded = false;
                Console.WriteLine(message);
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return isAdded;
        }

        public bool DischargePatient(string patientId)
        {
            bool isDischarged;
            try
            {
                //validation
              
                    _helpers.ChangeBedStatusFree(GetPatient(patientId).IcuId, GetPatient(patientId).BedId);
                    isDischarged = _patientDataHandler.DeletePatient(patientId, _csvFilePath);
            }
            catch (Exception e)
            {
                isDischarged = false;
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return isDischarged;
        }

        public Models.PatientModel GetPatient(string patientId)
        {
            return _patientDataHandler.ReadPatients(_csvFilePath).Find(patient => patient.PatientId == patientId);
        }

    }
}
