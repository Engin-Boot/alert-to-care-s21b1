using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository
{
    public class BedRepository : IBedRepository
    {
        private readonly Utility.BedDataHandler _bedDataHandler = new Utility.BedDataHandler();
        private readonly Utility.IcuDataHandler _icuDataHandler = new Utility.IcuDataHandler();
        private readonly Utility.Helpers _helpers = new Utility.Helpers();
        public readonly string _csvFilePath;
        public BedRepository()
        {
            this._csvFilePath = @"D:\a\alert-to-care-s21b1\alert-to-care-s21b1\Backend\Beds.csv";
        
        }
        public bool AddBed(string icuId, string locationOfBed = "not specified")
        {
            string message = "";
            bool isAdded = false;
            try
            {
                // validation.
                if (_helpers.IsEmptySlotAvailableToAddBed(icuId, out message))
                {
                    //var icu = new Occupancy.OccupancyServices().GetIcu(icuId));
                    var bedId = _helpers.GenerateBedId(icuId);
                    var bed = new Models.BedModel()
                    {
                        BedId = bedId,
                        IcuId = icuId,
                        BedOccupancyStatus = "Free",
                        Location = locationOfBed
                    };
                    isAdded = _bedDataHandler.WriteBed(bed, _csvFilePath);
                    if (isAdded)
                    {
                        _helpers.IncrementNoOfBedsOfIcu(icuId);
                        _helpers.IncrementBedCounterInIcu(icuId);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(message);
                Console.WriteLine(e.StackTrace);
                isAdded = false;
            }
            return isAdded;
        }


        public bool RemoveBed(string icuId, string bedId)
        {
            bool isDeleted = false;
            string message = "";
            try
            {
                // validation
                if (_helpers.IsBedAvailable(icuId, bedId, out message))
                {
                    isDeleted = _bedDataHandler.DeleteBed(bedId, _csvFilePath);
                    _helpers.DecrementNoOfBedsOfIcu(icuId);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(message);
                Console.WriteLine(e.StackTrace);
                isDeleted = false;
            }
            return isDeleted;
        }

        public IEnumerable<Models.BedModel> GetAllBedsFromAnIcu(string icuId)
        {
            List<Models.BedModel> beds = _bedDataHandler.Readbeds(_csvFilePath);
            return beds.FindAll(bed =>bed.IcuId == icuId);
        }

        public IEnumerable<Models.BedModel> GetAllBeds()
        {
            List<Models.BedModel> beds = _bedDataHandler.Readbeds(_csvFilePath);
            return beds;
        }

    }
}
