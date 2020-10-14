using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AlertToCare_API.DataBase;
using AlertToCare_API.Models;
using AlertToCare_API.Utility;

namespace AlertToCare_API.Repositories
{
    //we can new icu patient ,update his record,change of bed not possible

    public class IcuConfigurationRepository : IIcuConfigurationRepository
    {
        readonly Data _db = new Data();
        readonly List<Icu> _icuList;
        readonly IcuValidator _icuValidator;

        public IcuConfigurationRepository()
        {
            this._icuList = _db.GetIcuList();
            this._icuValidator = new IcuValidator();
        }

        public IEnumerable<Icu> GetAllIcu()
        {
            return _icuList;
        }

        public void AddNewPateintInIcu(Icu newPatient)
        {
            var checker = _icuValidator.ValidateWhetherIcuIDPresent(newPatient.IcuId, _icuList);//if present return true
            if (!checker)
            {
                _icuList.Add(newPatient);
            }
            //update in db
            _db.UpdateIcuList(_icuList);
        }

        public void RemovePatientInIcu(string icuID)
        {
            //validate whether i/p is given correct or not
            BasicValidator.basicValid.Invoke(icuID);
            for (int i = 0; i < _icuList.Count; i++)
            {
                if (_icuList[i].IcuId == icuID)
                {
                    //we found the record
                    _icuList.Remove(_icuList[i]);
                    //update
                    _db.UpdateIcuList(_icuList);
                    return;
                }
            }
        }

        public void UpdatePatientInIcu(string icuID, Icu UpdateDetails)
        {
            //validator updateDetails
            _icuValidator.ValidateIcu(UpdateDetails);

            for (int i = 0; i < _icuList.Count; i++)
            {
                if (_icuList[i].IcuId == icuID)
                {
                    //we found the record
                    _icuList.Insert(i, _icuList[i]);
                    //update
                    _db.UpdateIcuList(_icuList);
                    return;
                }
            }

            throw new Exception("INVALID ID");
        }
    }
}
