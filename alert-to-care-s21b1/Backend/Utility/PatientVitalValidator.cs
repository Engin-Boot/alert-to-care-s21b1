using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Utility
{
    public class PatientVitalValidator
    {

        public  void VitalValidator(VitalsModel vitals)
        {
            bool b1 = BasicValidator.ValidFloat.Invoke(vitals.Value.ToString());
            bool b2 = BasicValidator.ValidFloat.Invoke(vitals.UpperLimit.ToString());
            bool b3 = BasicValidator.basicValid.Invoke(vitals.Name);
           

            int val = Convert.ToInt32(b1) + Convert.ToInt32(b2) + Convert.ToInt32(b3);
            if (val == 3)
                return;
            else
                throw new Exception("INVALID VITAL DATA");

        }

        //public static bool ValidateDevice(VitalsModel vital)
        //{
        //    if (BasicValidator.IsValueNull(vital.Name) == false && vital.UpperLimit > vital.LowerLimit)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
