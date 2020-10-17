using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCareAPI.Models;

namespace AlertToCareAPI.Repository.Occupancy
{
    public interface IOccupancyServices
    {
        string AddIcu(IcuModel newIcu);
        string AddBed(string icuId, BedModel newBed);
        string AddPatient(PatientModel newPatient);
        string DischargePatient(string patientId);
        string RemoveIcu(string icuId);
        string RemoveBed(string icuId, string bedId);
        IEnumerable<BedModel> AvailableBeds();
        IEnumerable<PatientModel> GetAllPatients();
    }
}
