using AlertToCare_API.Models;

namespace AlertToCare_API.Repositories
{
    public interface IPatientOccupancyRepository
    {
        void AddPatient(Patients NewPatient);
        void RemovePatient(string patientID);
        void UpdatePatient(string patientID, Patients UpdateDetails);
    }
}