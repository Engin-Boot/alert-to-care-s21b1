using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCare_API.Utility;
using AlertToCareAPI.Models;

namespace AlertToCareAPI.Utility
{
    public class PatientDetailValidator
    {

        public void ValidatePatientinformation(AddressModel address)
        {
            var b1 = BasicValidator.basicValid.Invoke(address.HouseNo);
            var b2 = BasicValidator.basicValid.Invoke(address.State);
            var b3 = BasicValidator.basicValid.Invoke(address.Town);
            var b4 = BasicValidator.ValidInt.Invoke(address.PinCode.ToString());

            int val = Convert.ToInt32(b1) + Convert.ToInt32(b2) + Convert.ToInt32(b3) + Convert.ToInt32(b4);
            if (val == 4)
                return;
            else
                throw new Exception("INVALID Patient ADDRESS DATA");
        }
    }
}
