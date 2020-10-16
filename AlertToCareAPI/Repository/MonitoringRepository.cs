using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCareAPI.Repository
{
    public class MonitoringRepository
    {
        readonly Data _db = new Data();
        readonly List<PatientVitals> _patientVitals;
        readonly float[] bpmLimits = { 70, 150 };
        readonly float[] spo2Limits = { 90, 100 };
        readonly float[] respRateLimits = { 30, 95 };

        
        public MonitoringRepository()
        {
            this._patientVitals = _db.GetVitalsList();
        }

        public IEnumerable<PatientVitals> GetPatientVitals()
        {
            return _patientVitals;
        }

    }
}
