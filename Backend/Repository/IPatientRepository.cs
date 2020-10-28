using Backend.Models;
using System.Collections.Generic;

namespace Backend.Repository
{
    public interface IPatientRepository
    {
        bool AddPatient(PatientModel newPatient);
        bool DischargePatient(string patientId);
        IEnumerable<PatientModel> GetAllPatients();
        PatientModel GetPatient(string patientId);
    }
}