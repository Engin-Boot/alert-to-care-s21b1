using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCareAPI.Models;
using AlertToCareAPI.Utility;

namespace AlertToCareAPI.Repository
{
    public class MonitoringRepository
    {

        readonly PatientVitalValidator _patientVitalValidator;
        //readonly Data _db = new Data();
        readonly List<VitalsModel> _patientVitals;
        readonly float[] bpmLimits = { 70, 150 };
        readonly float[] spo2Limits = { 90, 100 };
        readonly float[] respRateLimits = { 30, 95 };


        public MonitoringRepository()
        {
            // this._patientVitals = _db.GetVitalsList();
        }

        public IEnumerable<VitalsModel> GetPatientVitals()
        {
            return _patientVitals;
        }

        //check the vitals
        public static Func<string, float, float[], string> VitalChecker = (VitalName,vitalValue, VitalArray )=>
            {

                if (vitalValue<VitalArray[0])
                {
                    return (VitalName + " IS LOW");
                }
                if(vitalValue>VitalArray[1])
                {
                    return (VitalName + " IS HIGH");
                }

                return (VitalName + " IS OKAY");
            };

        public string CheckVital(VitalsModel vital)
        {

            _patientVitalValidator.VitalValidator(vital);
            var bpm_vital = VitalChecker.Invoke("bpm", vital.Bpm, bpmLimits);
            var spo2_vital = VitalChecker.Invoke("spo2", vital.Spo2, spo2Limits);
            var respRate_vital = VitalChecker.Invoke("respRate", vital.RespRate, respRateLimits);

            var result = bpm_vital + " " + spo2_vital + " " + respRate_vital;

            return result;
        }



    }
}
