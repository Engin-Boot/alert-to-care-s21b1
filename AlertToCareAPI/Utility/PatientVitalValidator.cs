using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCare_API.Utility;
using AlertToCareAPI.Models;

namespace AlertToCareAPI.Utility
{
    public class PatientVitalValidator
    {

        public void VitalValidator(VitalsModel vitals)
        {
            bool b1 = BasicValidator.ValidFloat.Invoke(vitals.Bpm.ToString());
            bool b2 = BasicValidator.ValidFloat.Invoke(vitals.Spo2.ToString());
            bool b3 = BasicValidator.basicValid.Invoke(vitals.PatientId);
            bool b4 = BasicValidator.ValidFloat.Invoke(vitals.RespRate.ToString());

            int val = Convert.ToInt32(b1) + Convert.ToInt32(b2) + Convert.ToInt32(b3) + Convert.ToInt32(b4);
            if (val == 4)
                return;
            else
                throw new Exception("INVALID VITAL DATA");

        }
    }
}
