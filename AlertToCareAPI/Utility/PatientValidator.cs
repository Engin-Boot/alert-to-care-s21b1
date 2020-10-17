﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCareAPI.Models;
using AlertToCareAPI.Utility;

namespace AlertToCare_API.Utility
{

    
        
        public class PatientValidator
    {
        readonly PatientDetailValidator _PatientDetailValidator = new PatientDetailValidator();
        readonly PatientVitalValidator _PatientVitalValidator = new PatientVitalValidator();
        public void ValidatPatient(PatientModel patients)
        {
            var b1 = BasicValidator.basicValid.Invoke(patients.PatientId);
            var b2 = BasicValidator.basicValid.Invoke(patients.Name);
            var b3 = BasicValidator.basicValid.Invoke(patients.IcuId);
            var b4 = BasicValidator.basicValid.Invoke(patients.BedId);
            var b5 = BasicValidator.basicValid.Invoke(patients.Age.ToString());

            _PatientDetailValidator.ValidatePatientinformation(patients.Address);
            _PatientVitalValidator.VitalValidator(patients.Vitals);

            int val = Convert.ToInt32(b1) + Convert.ToInt32(b2) + Convert.ToInt32(b3) + Convert.ToInt32(b4)+Convert.ToInt32(b5);
            if (val == 5)
                return;
            else
                throw new Exception("INVALID Patient DATA");
        }

        //check whether new patient or old
        public bool ValidateNewPatientOrOld(string NewPatientID, List<PatientModel> patientList)
        {
            foreach (var pat in patientList)
            {
                if (pat.PatientId == NewPatientID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
