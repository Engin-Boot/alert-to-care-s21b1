using System;
using System.Collections.Generic;
using System.Linq;
using AlertToCareAPI.Models;
using AlertToCareAPI.Utility;

namespace AlertToCareAPI.Repository.Monitoring
{
    public class MonitoringRepository : IMonitoringRepository
    {

        //readonly PatientVitalValidator _patientVitalValidator;
        ////readonly Data _db = new Data();
        //readonly List<VitalsModel> _patientVitals;
        //readonly float[] bpmLimits = { 70, 150 };
        //readonly float[] spo2Limits = { 90, 100 };
        //readonly float[] respRateLimits = { 30, 95 };


        //public MonitoringRepository()
        //{
        //    // this._patientVitals = _db.GetVitalsList();
        //}

        //public IEnumerable<VitalsModel> GetPatientVitals()
        //{
        //    return _patientVitals;
        //}

        ////check the vitals
        //public static Func<string, float, float[], string> VitalChecker = (VitalName,vitalValue, VitalArray )=>
        //    {

        //        if (vitalValue<VitalArray[0])
        //        {
        //            return (VitalName + " IS LOW");
        //        }
        //        if(vitalValue>VitalArray[1])
        //        {
        //            return (VitalName + " IS HIGH");
        //        }

        //        return (VitalName + " IS OKAY");
        //    };

        //public string CheckVital(VitalsModel vital)
        //{

        //    _patientVitalValidator.VitalValidator(vital);
        //    var bpm_vital = VitalChecker.Invoke("bpm", vital.Bpm, bpmLimits);
        //    var spo2_vital = VitalChecker.Invoke("spo2", vital.Spo2, spo2Limits);
        //    var respRate_vital = VitalChecker.Invoke("respRate", vital.RespRate, respRateLimits);

        //    var result = bpm_vital + " " + spo2_vital + " " + respRate_vital;

        //    return result;
        //}

        private readonly AppDbContext _context;
        readonly PatientVitalValidator _patientVitalValidator = new PatientVitalValidator();
        public MonitoringRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddNewVital(VitalsModel vital)
        {
            //_patientVitalValidator.VitalValidator(vital);--------------validatation
            _context.Vitals.Add(vital);
            _context.SaveChanges(); //save in db
        }

        public VitalsModel FetchVital(string vitalName)
        {
            //BasicValidator.basicValid.Invoke(vitalName);---cehck vital name
            var name = _context.Vitals.FirstOrDefault(vit => vit.Name == vitalName);
            return name;
        }

        public string Alarm(string vitalName)
        {
            //BasicValidator.basicValid.Invoke(vitalName);---cehck vital name
            string msg = "";
            var name = _context.Vitals.FirstOrDefault(vit => vit.Name == vitalName);
            if (name.Value < name.LowerLimit)
            {
                return msg = vitalName + "--" + " Alerting IS LOW";
            }
            else
            {
                if (name.Value > name.UpperLimit)
                {
                    return msg = vitalName + "--" + "Alerting IS HIGH";
                }
                else
                {
                    return msg = vitalName + "--" + "ALL OKAY";
                }
            }
         
        }
    }
}
