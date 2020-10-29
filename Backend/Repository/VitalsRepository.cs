
/*namespace Backend.Repository
{
    public class VitalsRepository
    {
        private readonly string _csvFilePath;
        private readonly Utility.VitalsDataHandler _vitalsDataHandler = new Utility.VitalsDataHandler();
        private readonly Utility.Helpers _helpers = new Utility.Helpers();
        public VitalsRepository()
        {
            _csvFilePath = "";
        }
        public List<Models.VitalsModel> PatientVital(string patientId)
        {
            if (Utility.BasicValidator.basicValid(patientId))//validate the format
            {
                return _vitalsDataHandler.ReadVitals(_csvFilePath).FindAll(vital => vital.PatientId == patientId);
            }
            return null;
        }
        public List<Models.BedOnAlert> TurnOnAlert()
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

                        Models.BedOnAlert bedOnAlert = new Models.BedOnAlert() { BedId = pat.BedId, Message = messge, Value = vitalList[i].Value };
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


        public List<Models.BedOnAlert> UpdateVital(string patietId, float bpmvalue, float spo2value, float respRatevalue)
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

        public void AssigningVital(Models.VitalsModel vital, float bpmvalue, float spo2value, float respRatevalue)
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
    
        public string GetAddressOfBed(List<Models.BedModel> beds, string bedId)
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

        public List<Models.PatientModel> AllPatientVitalWithDetails()
        {
            return _context.Patients.ToList();
        }

        public void TurnOffAlert(string bedId)
        {
            _context.Beds.RemoveRange(_context.Beds.Where(bed => bed.BedId == bedId));
            _context.SaveChanges();
        }


     

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
}*/
