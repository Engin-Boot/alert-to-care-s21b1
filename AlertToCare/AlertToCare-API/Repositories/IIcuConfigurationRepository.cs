using System.Collections.Generic;
using AlertToCare_API.Models;

namespace AlertToCare_API.Repositories
{
    public interface IIcuConfigurationRepository
    {
        void AddNewPateintInIcu(Icu newPatient);
        IEnumerable<Icu> GetAllIcu();
        void RemovePatientInIcu(string icuID);
        void UpdatePatientInIcu(string icuID, Icu UpdateDetails);
    }
}