﻿using Backend.Models;
using Backend.Utility;
using System;
using System.Collections.Generic;

namespace Backend.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly string _csvFilePath;
        private readonly PatientDataHandler _patientDataHandler = new PatientDataHandler();
        private readonly Helpers _helpers = new Helpers();
        public PatientRepository()
        {
            this._csvFilePath = @"D:\a\alert-to-care-s21b1\alert-to-care-s21b1\Backend\Patients.csv";
        }
        public IEnumerable<PatientModel> GetAllPatients()
        {
            return _patientDataHandler.ReadPatients(_csvFilePath);
        }

        public bool AddPatient(PatientModel newPatient)
        {
            bool isAdded = false;
            string message = "";
            try
            {
                if (_helpers.CanPatientBeAdded(newPatient, out message))
                {
                    isAdded = _patientDataHandler.WritePatient(newPatient, _csvFilePath);
                    var patientVitals = new PatientVitalsModel()
                    {
                        PatientId = newPatient.PatientId,
                        Vitals = VitalsHelper.VitalNames
                    };
                    new PatientVitalRepository().WriteVitals(patientVitals);
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
                _helpers.ChangeBedStatusFree(GetPatient(patientId).BedId);
                isDischarged = _patientDataHandler.DeletePatient(patientId, _csvFilePath);
                new PatientVitalRepository().DeletePatientVitals(patientId);
            }
            catch (Exception e)
            {
                isDischarged = false;
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return isDischarged;
        }

        public PatientModel GetPatient(string patientId)
        {
            return _patientDataHandler.ReadPatients(_csvFilePath).Find(patient => patient.PatientId == patientId);
        }

    }
}
