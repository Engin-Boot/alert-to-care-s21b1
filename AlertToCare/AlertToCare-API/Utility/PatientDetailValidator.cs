using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCare_API.Models;

namespace AlertToCare_API.Utility
{
    public class PatientDetailValidator
    {

        
        public void ValidatePatientinformation(PatientDetails address)
        {
            BasicValidator.basicValid.Invoke(address.Address);
            BasicValidator.basicValid.Invoke(address.ContactNo);
            BasicValidator.basicValid.Invoke(address.Email);
            BasicValidator.ValidInt.Invoke(address.Age.ToString());

        }
    }
}
