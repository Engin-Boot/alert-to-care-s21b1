
namespace Backend.Utility
{
    public class Helpers
    {
        private readonly IcuDataHandler _icuDataHandler = new IcuDataHandler();
        private readonly PatientDataHandler _patientDataHandler = new PatientDataHandler();
        private readonly BedDataHandler _bedDataHandler = new BedDataHandler();
        private readonly string _icuDataCsvPath = @"D:\a\alert-to-care-s21b1\alert-to-care-s21b1\Backend\Icus.csv";
        private readonly string _patientDataCsvPath = @"D:\a\alert-to-care-s21b1\alert-to-care-s21b1\Backend\Patients.csv";
        private readonly string _bedDataCsvPath = @"D:\a\alert-to-care-s21b1\alert-to-care-s21b1\Backend\Beds.csv";

        public void ChangeBedStatusToOccupied(string bedId)
        {
            var bed = _bedDataHandler.Readbeds(_bedDataCsvPath).Find(tempbed => tempbed.BedId == bedId);
            if (bed != null)
            {
                bed.BedOccupancyStatus = "Occupied";
                _bedDataHandler.DeleteBed(bed.BedId, _bedDataCsvPath);
                _bedDataHandler.WriteBed(bed, _bedDataCsvPath);
                
            }
 
        }


        public bool CanPatientBeAdded(Models.PatientModel newPatient, out string msg)
        {
            if (_patientDataHandler.ReadPatients(_patientDataCsvPath).Find(patient => patient.PatientId == newPatient.PatientId)!=null)
            {
                msg = "Patient Already Exists";
                return false;
            }
            if (IsBedAvailable( newPatient.BedId, out string message))    // add vitals validation
            {
                msg = "Patient can be Added";
                return true;
            }
            msg = message;
            return false;
        }

        public bool IsBedAvailable( string bedId, out string msg)
        {
            var bed = _bedDataHandler.Readbeds(_bedDataCsvPath).Find(tempbed => tempbed.BedId == bedId);
            if (bed !=null)
            {
                if (IsBedOccupied(bed))
                {
                    msg = "Bed is occupied";
                    return false;
                }
                msg = "Bed is free";
                return true;
            }
            msg = "Bed Doesn't Exist";
            return false;

        }

        internal void IncrementNoOfBedsOfIcu(string icuId)
        {
            var icu = _icuDataHandler.ReadIcus(_icuDataCsvPath).Find(tempicu => tempicu.IcuId ==icuId);
            if (icu != null)
            {
                icu.NoOfBeds += 1;
                _icuDataHandler.DeleteIcu(icuId, _icuDataCsvPath);
                _icuDataHandler.WriteIcu(icu, _icuDataCsvPath);
            }
        }
        internal void DecrementNoOfBedsOfIcu(string icuId)
        {
            var icu = _icuDataHandler.ReadIcus(_icuDataCsvPath).Find(tempicu => tempicu.IcuId == icuId);
            if (icu != null)
            {
                icu.NoOfBeds -= 1;
                _icuDataHandler.DeleteIcu(icuId, _icuDataCsvPath);
                _icuDataHandler.WriteIcu(icu, _icuDataCsvPath);
            }
            
        }

        public bool IsIcuEligibleToBeAdded(Models.IcuModel icu)
        {

            if (_icuDataHandler.ReadIcus(_icuDataCsvPath).Find(tempIcu => tempIcu.IcuId == icu.IcuId)!=null) 
            {
                return false;
            }
            else if(ValidateBeds(icu))  // check layout with BedId
            {
                return true;
            }
            return false;
        }

        public bool CanIcuBeRemoved(string icuId)
        {
            if (_icuDataHandler.ReadIcus(_icuDataCsvPath).Find(tempicu => tempicu.IcuId == icuId)==null)
            {
                return false;
            }
            else if (CheckIfPatientsExistsInIcu(icuId))  
            {
                return false;
            }
            return true;
        }

        private bool CheckIfPatientsExistsInIcu(string icuId)
        {
            var patients = _patientDataHandler.ReadPatients(_patientDataCsvPath);
            foreach (var patient in patients)
            {
                if (patient.IcuId == icuId)
                {
                    return true;
                }
            }
            return false;
        }

        private bool ValidateBeds(Models.IcuModel icu)
        {
            if (icu.MaxBeds != 0 && CheckBedsCriteria(icu))  // check layout with BedId
            {
                return true;
            }
            return false;
        }

        private bool CheckBedsCriteria(Models.IcuModel icu)
        {
            if (icu.NoOfBeds>=0 && icu.NoOfBeds <= icu.MaxBeds)  // check layout with BedId
            {
                return true;
            }
            return false;
        }

      
        private bool IsBedOccupied(Models.BedModel bed)
        {
            return bed.BedOccupancyStatus != "Free";
        }


        public  string GenerateBedId(string id)
        {
            Models.IcuModel icu = _icuDataHandler.ReadIcus(_icuDataCsvPath).Find(tempicu => tempicu.IcuId == id);
            if (icu != null)
            {
                string temp;
                if (icu.BedsCounter < 9)
                    temp = "0" + (icu.BedsCounter + 1);
                else
                    temp = (icu.BedsCounter + 1).ToString();
                id += icu.Layout + temp;
            }
            return id;
        }

        public bool IsEmptySlotAvailableToAddBed(string icuId, out string msg)
        {
            var icu = _icuDataHandler.ReadIcus(_icuDataCsvPath).Find(tempicu => tempicu.IcuId == icuId);
            if (icu == null)
            {
                msg = "Icu not found";
                return false;
            }
            if (icu.NoOfBeds < icu.MaxBeds)
            {
                msg = "Can Add Bed";
                return true;
            }
            msg = "Icu is Full";
            return false;
        }

       
        public void ChangeBedStatusFree(string bedId)
        {
            var bed = _bedDataHandler.Readbeds(_bedDataCsvPath).Find(tempbed => tempbed.BedId == bedId);
            if (bed != null)
            {
                bed.BedOccupancyStatus = "Free";
                _bedDataHandler.DeleteBed(bedId, _bedDataCsvPath);
                _bedDataHandler.WriteBed(bed, _bedDataCsvPath);
            }
         
        }

        public void DeleteAllBedsInIcu(string icuId)
        {
            var beds = _bedDataHandler.Readbeds(_bedDataCsvPath);
            foreach(var bed in beds)
            {
                if(bed.IcuId == icuId)
                {
                    _bedDataHandler.DeleteBed(bed.BedId, _bedDataCsvPath);
                }
            }
        }

        public void IncrementBedCounterInIcu(string icuId)
        {
            var icu = _icuDataHandler.ReadIcus(_icuDataCsvPath).Find(tempicu => tempicu.IcuId == icuId);
            if (icu != null)
            {
                icu.BedsCounter += 1;
                _icuDataHandler.DeleteIcu(icuId, _icuDataCsvPath);
                _icuDataHandler.WriteIcu(icu, _icuDataCsvPath);
            }
        }
    }
}
