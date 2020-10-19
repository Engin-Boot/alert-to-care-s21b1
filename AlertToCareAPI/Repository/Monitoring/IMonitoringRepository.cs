using System.Collections.Generic;
using AlertToCareAPI.Models;

namespace AlertToCareAPI.Repository.Monitoring
{
    public interface IMonitoringRepository
    {

        List<PatientModel> AllPatientVitalWithDetails();
        List<VitalsModel> PatientVital(string patientId);
        void TurnOffAlert(string bedId);
        //Dictionary<string, string> TurnOnAlert();
        List<BedOnAlert> TurnOnAlert();

        List<BedOnAlert> UpdateVital(string patietId, float bpmvalue, float spo2value, float respRatevalue);
    }
}