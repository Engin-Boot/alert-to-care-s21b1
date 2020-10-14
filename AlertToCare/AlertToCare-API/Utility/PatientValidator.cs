using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCare_API.Models;

namespace AlertToCare_API.Utility
{
    public class PatientValidator
    {
        readonly PatientDetailValidator _PatientDetailValidator = new PatientDetailValidator();
        readonly PatientVitalValidator _PatientVitalValidator = new PatientVitalValidator();
        public void ValidatPatient(Patients patients)
        {
            BasicValidator.basicValid.Invoke(patients.PatientID);
            BasicValidator.basicValid.Invoke(patients.IcuID);
            BasicValidator.basicValid.Invoke(patients.PatientName);
            BasicValidator.basicValid.Invoke(patients.BedID);

            _PatientDetailValidator.ValidatePatientinformation(patients.PatientDetails);
            _PatientVitalValidator.VitalValidator(patients.PatientVitals);
        }

        //check whether new patient or old
        public bool ValidateNewPatientOrOld(string NewPatientID,List<Patients> patientList)
        {
            foreach(var pat in patientList)
            {
                if(pat.PatientID==NewPatientID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
