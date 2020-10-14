using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCare_API.DataBase;
using AlertToCare_API.Models;
using AlertToCare_API.Utility;

namespace AlertToCare_API.Repositories
{
    //patient details can be updated ,bed update
    public class PatientOccupancyRepository : IPatientOccupancyRepository
    {
        readonly Data _db = new Data();
        readonly List<Patients> _Patients;
        readonly List<Beds> _Beds;
        readonly PatientValidator _PatientValidator;

        public PatientOccupancyRepository()
        {
            this._Patients = _db.GetPatientsList();
            this._Beds = _db.GetBedList();
            this._PatientValidator = new PatientValidator();
        }


        public IEnumerable<Patients> GetAllPatients()
        {
            return _Patients;
        }
        public void AddPatient(Patients NewPatient)
        {
            var checker = _PatientValidator.ValidateNewPatientOrOld(NewPatient.PatientID, _Patients); //if present return true;
            if (!checker)
            {
                //validate the record
                _PatientValidator.ValidatPatient(NewPatient);

                _Patients.Add(NewPatient);
                //update the db
                _db.UpdatePatientList(_Patients);

                //change bedstatus
                ChangeBedStatus(NewPatient.BedID, true);
            }
            else
                throw new Exception("INVALID PATIENT DETAILS");
        }

        public void RemovePatient(string patientID)
        {
            //validate id 
            BasicValidator.basicValid.Invoke(patientID);
            //checker the id
            for (int i = 0; i < _Patients.Count; i++)
            {
                if (_Patients[i].PatientID == patientID)
                {
                    _Patients.Remove(_Patients[i]);
                    //update db
                    _db.UpdatePatientList(_Patients);
                    //change bed status
                    ChangeBedStatus(_Patients[i].BedID, false);

                }
            }
        }

        public void UpdatePatient(string patientID, Patients UpdateDetails)
        {
            //validate details
            _PatientValidator.ValidatPatient(UpdateDetails);

            for (int i = 0; i < _Patients.Count; i++)
            {
                if (_Patients[i].PatientID == patientID)
                {
                    //we found the record
                    _Patients.Insert(i, _Patients[i]);
                    //update
                    _db.UpdatePatientList(_Patients);
                    return;
                }
            }

            throw new Exception("INVALID ID");
        }

       

        public void ChangeBedStatus(string bedID, bool status)
        {
            for (int i = 0; i < _Beds.Count; i++)
            {
                if (_Beds[i].BedID == bedID)
                {
                    //take status
                    _Beds[i].BedOccupancyStatus = status;
                    return;
                }
            }
            throw new Exception("INVALID BEDID");
        }
    }
}
