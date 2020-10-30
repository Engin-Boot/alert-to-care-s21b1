using System;
using System.Collections.Generic;

namespace Backend.Repository
{
    public class IcuRepository : IIcuRepository
    {
        private readonly string _csvFilePath;
        private readonly Utility.IcuDataHandler _icuDataHandler = new Utility.IcuDataHandler();
        private readonly Utility.Helpers _helpers = new Utility.Helpers();
        public IcuRepository()
        {
            _csvFilePath = @"C:\a\alert-to-care-s21b1\alert-to-care-s21b1\Backend\Icus.csv";
        }

        // Add update vitals in maintanance. 
        public bool AddIcu(Models.PatientVitalsModels newIcu)
        {
            bool isAdded = false;
            try
            {
                //Validation
                if (_helpers.IsIcuEligibleToBeAdded(newIcu))
                {
                    isAdded = _icuDataHandler.WriteIcu(newIcu, _csvFilePath);
                }
            }
            catch (Exception e)
            {
                isAdded = false;
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return isAdded;
        }

        public bool RemoveIcu(string icuId)
        {
            bool isDeleted = false;
            try
            {
                // validation
                if (_helpers.CanIcuBeRemoved(icuId))    // Check for patients if no patirnts then remove
                {
                    isDeleted = _icuDataHandler.DeleteIcu(icuId, _csvFilePath);
                    _helpers.DeleteAllBedsInIcu(icuId);

                }
            }
            catch (Exception e)
            {
                isDeleted = false;
                Console.WriteLine(e.StackTrace);
            }
            return isDeleted;
        }

        public List<Models.PatientVitalsModels> GetAllIcu()
        {
            return _icuDataHandler.ReadIcus(_csvFilePath);
        }

        public Models.PatientVitalsModels GetIcu(string id)
        {
            var icu = _icuDataHandler.ReadIcus(_csvFilePath).Find(tempicu => tempicu.IcuId == id);
            return icu;
        }

    }
}
