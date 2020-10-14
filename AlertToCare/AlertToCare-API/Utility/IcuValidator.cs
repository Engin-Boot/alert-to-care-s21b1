using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using AlertToCare_API.Models;

namespace AlertToCare_API.Utility
{
    public class IcuValidator
    {
        readonly PatientValidator _PatientValidator = new PatientValidator();
        public void ValidateIcu(Icu icu)
        {
            BasicValidator.basicValid.Invoke(icu.IcuId);
            BasicValidator.basicValid.Invoke(icu.LayoutID);
            BasicValidator.ValidInt.Invoke(icu.BedsCount.ToString());
            ValidatePatientsList(icu.Patients);    
        }


        public void ValidatePatientsList(List<Patients> patients)
        {
            foreach(var pat in patients)
            {
                _PatientValidator.ValidatPatient(pat);
            }
        }

        //validator if new patient add then see whether old patient or not
        public bool ValidateWhetherIcuIDPresent(string icuId,List<Icu> icuList)
        {
            foreach(var pat in icuList)
            {
                if(pat.IcuId==icuId)
                {
                    return true;
                }
            }
            return false;
            
        }

        
    }
}
