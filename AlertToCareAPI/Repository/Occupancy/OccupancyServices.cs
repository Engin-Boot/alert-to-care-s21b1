using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCareAPI.Models;

namespace AlertToCareAPI.Repository.Occupancy
{
    public class OccupancyServices:IOccupancyServices
    {

        public string AddIcu(IcuModel newIcu)
        {
            throw new NotImplementedException();
        }

        public string AddBed(BedModel newBed)
        {
            throw new NotImplementedException();
        }

        public string AddPatient(PatientModel newPatient)
        {
            throw new NotImplementedException();
        }

        public string DischargePatient(string patientId)
        {
            throw new NotImplementedException();
        }

        public string RemoveIcu(string icuId)
        {
            throw new NotImplementedException();
        }

        public string RemoveBed(string icuId, string bedId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> AvailableBeds()
        {
            throw new NotImplementedException();
        }
    }
}
