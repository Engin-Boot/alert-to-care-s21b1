using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCare_API.Models;

namespace AlertToCare_API.Utility
{
    public class PatientVitalValidator
    {
        public void VitalValidator(PatientVitals vitals)
        {
            BasicValidator.ValidFloat.Invoke(vitals.Bpm.ToString());
            BasicValidator.ValidFloat.Invoke(vitals.Spo2.ToString());
            BasicValidator.basicValid.Invoke(vitals.PatientId);
            BasicValidator.ValidFloat.Invoke(vitals.RespRate.ToString());

        }
    }
}
