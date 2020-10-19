using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using AlertToCareAPI.Models;
using AlertToCareAPI.Utility;

namespace AlertToCareAPI.Repository.Monitoring
{
    public class MonitoringRepository : IMonitoringRepository
    {
        #region Commented
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

        //private readonly AppDbContext _context;
        //readonly PatientVitalValidator _patientVitalValidator = new PatientVitalValidator();
        //public MonitoringRepository(AppDbContext context)
        //{
        //    _context = context;
        //}

        //public void AddNewVital(VitalsModel vital)
        //{
        //    //_patientVitalValidator.VitalValidator(vital);--------------validatation
        //    _context.Vitals.Add(vital);
        //    _context.SaveChanges(); //save in db
        //}

        //public VitalsModel FetchVital(string vitalName)
        //{
        //    //BasicValidator.basicValid.Invoke(vitalName);---cehck vital name
        //    var name = _context.Vitals.FirstOrDefault(vit => vit.Name == vitalName);
        //    return name;
        //}

        //public string Alarm(string vitalName)
        //{
        //    //BasicValidator.basicValid.Invoke(vitalName);---cehck vital name
        //    string msg = "";
        //    var name = _context.Vitals.FirstOrDefault(vit => vit.Name == vitalName);
        //    if (name.Value < name.LowerLimit)
        //    {
        //        return msg = vitalName + "--" + " Alerting IS LOW";
        //    }
        //    else
        //    {
        //        if (name.Value > name.UpperLimit)
        //        {
        //            return msg = vitalName + "--" + "Alerting IS HIGH";
        //        }
        //        else
        //        {
        //            return msg = vitalName + "--" + "ALL OKAY";
        //        }
        //    }

        //}
        #endregion

        private readonly AppDbContext _context;
        // readonly PatientVitalValidator _patientVitalValidator = new PatientVitalValidator();

        //   readonly List<PatientModel> _patientModelsList = new List<PatientModel>();
        //    readonly Dictionary<string, string> AlertLog = new Dictionary<string, string>();

        public MonitoringRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<VitalsModel> PatientVital(string patientId)
        {
            if (BasicValidator.basicValid(patientId))//validate the fromat
            {
                var pat = _context.Patients.Find(patientId);
                if (pat == null)
                {
                    throw new Exception("NO PAITENT FOUND");
                }
                else
                    return pat.Vitals.ToList();
            }
            else
                throw new Exception("PLEASE PROVIDE PATIENTID--string fomrat");
        }


        public List<BedOnAlert> TurnOnAlert()
        {


            foreach (var pat in _context.Patients)       //single patient
            {
                var vitalList = pat.Vitals; //complete list of patient
                for (int i = 0; i < vitalList.Count; i++)
                {
                    //checking
                    var msg = Alarming(vitalList[i].Value, vitalList[i].LowerLimit, vitalList[i].UpperLimit);
                    //notify to bed
                    if (msg != "ALl OKAY")
                    {
                        var PatientIcu = _context.Icu.Find(pat.IcuId); //no validation as we done for icu
                        var bedlist = PatientIcu.Beds;
                        var loc = GetAddressOfBed(bedlist, pat.BedId);
                        var messge = pat.BedId + " " + pat.PatientId + " " + vitalList[i].Name + " " + msg + " " + "PLEASE GO TO" + loc;

                        BedOnAlert bedOnAlert = new BedOnAlert() { BedId = pat.BedId, Message = messge, Value = vitalList[i].Value };
                        _context.Beds.Add(bedOnAlert);
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("VITAL ARE OKAY");
                    }

                }
            }

            return _context.Beds.ToList();
        }


        public List<BedOnAlert> UpdateVital(string patietId, float bpmvalue, float spo2value, float respRatevalue)
        {

            var pat = _context.Patients.Find(patietId);
            var patVitalList = pat.Vitals;

            for (int i = 0; i < patVitalList.Count; i++)
            {
                AssigningVital(patVitalList[i], bpmvalue, spo2value, respRatevalue);
            }
            var vitalList = TurnOnAlert();
            return vitalList;
        }

        public void AssigningVital(VitalsModel vital,float bpmvalue,float spo2value,float respRatevalue)
        {
            if (vital.Name == "Bpm")
            {

                vital.Value = bpmvalue;
                _context.SaveChanges();
            }
            else
                    if (vital.Name == "Spo2")
            {
                vital.Value = spo2value;
                _context.SaveChanges();
            }
            else
                vital.Value = respRatevalue;
            _context.SaveChanges();
        }

        //public Dictionary<string, string> TurnOnAlert()
        //{


        //    foreach (var pat in _context.Patients)       //single patient
        //    {
        //        var vitalList = pat.Vitals; //complete list of patient
        //        for (int i = 0; i < vitalList.Count; i++)
        //        {
        //            //checking
        //            var msg = Alarming(vitalList[i].Value, vitalList[i].LowerLimit, vitalList[i].UpperLimit);
        //            //notify to bed
        //            if (msg != "ALl OKAY")
        //            {
        //                var PatientIcu = _context.Icu.Find(pat.IcuId); //no validation as we done for icu
        //                var bedlist = PatientIcu.Beds;
        //                var loc = GetAddressOfBed(bedlist, pat.BedId);

        //                AlertLog[pat.BedId] = pat.BedId + " " + pat.PatientId + " " + vitalList[i].Name + " " + msg + " " + "PLEASE GO TO" + loc;

        //            }
        //            else
        //            {
        //                throw new Exception("VITAL ARE OKAY");
        //            }

        //        }
        //    }
        //    return AlertLog;

        //}
        public string GetAddressOfBed(List<BedModel> beds, string bedId)
        {
            for (int i = 0; i < beds.Count; i++)
            {
                if (beds[i].BedId == bedId)
                {
                    return beds[i].Location;
                }
            }
            return null;
        }

        public List<PatientModel> AllPatientVitalWithDetails()
        {
            return _context.Patients.ToList();
        }

        //public void TurnOffAlert(string bedId)
        //{
        //    AlertLog.Remove(bedId);
        //}

        public void TurnOffAlert(string bedId)
        {
            _context.Beds.RemoveRange(_context.Beds.Where(bed => bed.BedId == bedId));
            _context.SaveChanges();
        }


        //public bool IsBedExists(string icuId)
        //{
        //    var icu = _context.Icu.Find(icuId);
        //    if (icu == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}


        public string Alarming(float value, float lower, float upper)
        {
            if (value < lower)
            {
                return "---IS LOWER---";
            }
            else
                if (value > upper)
            {
                return "---IS HIGHER---";
            }
            else
            {
                return "ALl OKAY";
            }
        }
    }
}
