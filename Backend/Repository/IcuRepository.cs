using System;
using System.Collections.Generic;

namespace Backend.Repository
{
    public class IcuRepository : IIcuRepository
    {
        public readonly string _csvFilePath;
        private readonly Utility.IcuDataHandler _icuDataHandler = new Utility.IcuDataHandler();
        private readonly Utility.Helpers _helpers = new Utility.Helpers();
        public IcuRepository()
        {
            _csvFilePath = @"D:\a\alert-to-care-s21b1\alert-to-care-s21b1\Backend\Icus.csv";
        }

        // Add update vitals in maintanance. 
        public bool AddIcu(Models.IcuModel newIcu)
        {
            bool isAdded = false;
            try
            {
                //Validation
                string message;
                if (_helpers.IsIcuEligibleToBeAdded(newIcu, out message))
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
                string message;
                if (_helpers.CanIcuBeRemoved(icuId, out message))    // Check for patients if no patirnts then remove
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

        public List<Models.IcuModel> GetAllIcu()
        {
            return _icuDataHandler.ReadIcus(_csvFilePath);
        }

        public Models.IcuModel GetIcu(string id)
        {
            var icu = _icuDataHandler.ReadIcus(_csvFilePath).Find(icu => icu.IcuId == id);
            return icu;
        }

    }
}
