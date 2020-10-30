using Backend.Models;
using System.Collections.Generic;

namespace Backend.Repository
{
    public interface IPatientVitalRepository
    {
        //bool DeletePatientVitals(string patientId);
        List<VitalsModel> ReadPatientVitals(string patientId);
        List<PatientVitalsModel> ReadVitals();
        void StartUpdate();
        //bool WriteVitals(PatientVitalsModel patientVitals);
    }
}