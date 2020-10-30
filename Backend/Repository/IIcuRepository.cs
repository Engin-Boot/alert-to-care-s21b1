using Backend.Models;
using System.Collections.Generic;

namespace Backend.Repository
{
    public interface IIcuRepository
    {
        bool AddIcu(PatientVitalsModels newIcu);
        List<PatientVitalsModels> GetAllIcu();
        PatientVitalsModels GetIcu(string id);
        bool RemoveIcu(string icuId);
    }
}