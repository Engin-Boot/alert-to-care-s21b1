using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCareAPI.Models;

namespace AlertToCareAPI.Utility
{
    public class IcuValidator
    {
        public void ValidateIcu(IcuModel icu)
        {
            var b1 = BasicValidator.basicValid.Invoke(icu.IcuId);
            var b2 = BasicValidator.basicValid.Invoke(icu.Layout);
            bool b3 = BasicValidator.basicValid.Invoke(icu.NoOfBeds.ToString());
            var b4 = BasicValidator.basicValid(icu.MaxBeds.ToString());

            int val = Convert.ToInt32(b1) + Convert.ToInt32(b2) + Convert.ToInt32(b3) + Convert.ToInt32(b4);
            if (val == 4)
                return;
            else
                throw new Exception("INVALID ICU DATA");
        }





        //validator if new patient add then see whether old patient or not
        public bool ValidateWhetherIcuIDPresent(string icuId, List<IcuModel> icuList)
        {
            foreach (var pat in icuList)
            {
                if (pat.IcuId == icuId)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
