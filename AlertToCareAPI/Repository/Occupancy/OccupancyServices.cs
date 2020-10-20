using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AlertToCareAPI.Models;
using Microsoft.VisualBasic;

namespace AlertToCareAPI.Repository.Occupancy
{
    public class OccupancyServices:IOccupancyServices
    {
        private readonly AppDbContext _context;

        public OccupancyServices(AppDbContext context)
        {
            _context = context;
        }


        // Add update vitals in maintanance. 
        public string AddIcu(IcuModel newIcu)
        {
            try
            {
                //Validation
                string message;
                if (IsIcuEligibleToBeAdded(newIcu,out message))
                {
                    _context.Icu.Add(newIcu);
                    _context.SaveChanges();
                    return "ICU Added";
                }
                return message;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                //return e.StackTrace;
                return "Failed to add";
            }
            
        }

        public string RemoveIcu(string icuId)
        {
            try
            {
                // validation
                string message;
                if (CanIcuBeRemoved(icuId, out message))    // Check for patients if no patirnts then remove
                {
                    _context.Icu.Remove(_context.Icu.Find(icuId));
                    _context.SaveChanges();
                    return "Removed";
                }
                return message;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return "Failed to Remove";
            }
        }

        public IEnumerable<IcuModel> GetAllIcu()
        {
            return _context.Icu.ToList();
        }

        public IcuModel GetIcu(string id)
        {
            return _context.Icu.Find(id);
        }

        public string AddBed(string icuId, string locationOfBed= "not specified")
        {
            try
            {
                string message;
                // validation.
                if (IsEmptySlotAvailableToAddBed(icuId , out message))
                {
                    var icu = _context.Icu.Find(icuId);
                    var bedId = GenetateBedId(icu);
                    icu.Beds.Add(new BedModel()
                    {
                        BedId = bedId,
                        BedOccupancyStatus = "Free",
                        Location = locationOfBed
                    });
                    icu.NoOfBeds += 1;
                    _context.SaveChanges();
                    return "New Bed Added..! BedId: " + bedId;
                }
                return message;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return "Failed to add";
            }
        }

        private string GenetateBedId(IcuModel icu)
        {
            string id = icu.IcuId;
            id += icu.Layout + (icu.NoOfBeds + 1).ToString();
            return id;
        }

        public string RemoveBed(string icuId, string bedId)
        {
            try
            {
                string message;
                // validation
                if (IsBedAvailable(icuId, bedId, out message))
                {
                    var requiredIcu = GetIcu(icuId);
                    var beds = requiredIcu.Beds;
                    var bed = GetBed(icuId, bedId);
                    beds.Remove(bed);
                    _context.SaveChanges();
                    return "Removed";
                }
                return message;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return "Failed to Remove";
            }
        }

        public IEnumerable<BedModel> AvailableBeds()
        {
            List<BedModel> freeBeds = new List<BedModel>();
            var allIcus = _context.Icu;
            foreach (var icu in allIcus)
            {
                freeBeds.AddRange(AvailableBeds(icu.IcuId).ToList());
            }
            return freeBeds;
        }

        public IEnumerable<BedModel> AvailableBeds(string icuId)
        {
            List<BedModel> freeBeds = new List<BedModel>();
            var icu = GetIcu(icuId);
            if (icu == null)
            {
                return freeBeds;
            }
            var beds = icu.Beds;
            foreach (var bed in beds)
            {
                if (bed.BedOccupancyStatus == "Free")
                {
                    freeBeds.Add(bed);
                }
            }
            
            return freeBeds;
        }

        public IEnumerable<PatientModel> GetAllPatients()
        {
            return _context.Patients.ToList();
        }

        public string AddPatient(PatientModel newPatient)
        {
            try
            {
                // validation
                string mesage;
                if (CanPatientBeAdded(newPatient, out mesage))
                {
                    _context.Patients.Add(newPatient);
                    ChangeBedIdToOccupied(newPatient.IcuId, newPatient.BedId);
                    _context.SaveChanges();
                    return "Patient Added Successfully";
                }
                return mesage;
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return "Failed to add";
            }
            
        }

        public string DischargePatient(string patientId)
        {
            try
            {
                //validation
                if (DoesPateintExists(patientId))
                {
                    _context.Patients.Remove(_context.Patients.Find(patientId));
                    _context.SaveChanges();
                    return "Patient " + patientId + " Discharged";
                }
                return "No such patient";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return "Failed to Discharge";
            }
        }

        public PatientModel GetPatient(string patientId)
        {
            try
            {
                //validation
                return _context.Patients.Find(patientId);
            }
            catch(Exception)
            {
                return null;
            }
            
        }


        #region Helper Functions

        public bool DoesBedExists(string icuId, string bedId)
        {
            if (DoesIcuExists(icuId))
            {
                if (GetBed(icuId, bedId) != null)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool IsIcuEligibleToBeAdded(IcuModel icu, out string message)
        {
            if (DoesIcuExists(icu.IcuId))
            {
                message = "Icu with same id exists";
                return false;
            }
            else if(ValidateBeds(icu))  // check layout with BedId
            {
                message = "Icu can be added";
                return true;
            }
            message = "ICU doesn't meet the conditions to be added";
            return false;
        }

        public bool CanIcuBeRemoved(string icuId, out string message)
        {
            if (!DoesIcuExists(icuId))
            {
                message = "Icu with doesn't exists";
                return false;
            }
            else if (CheckIfPatientsExistsInIcu(icuId))  
            {
                message = "Icu has patients, Cannot remove icu";
                return false;
            }
            message = "ICU can be Removed safely";
            return true;
        }

        public bool CheckIfPatientsExistsInIcu(string icuId)
        {
            var patients = GetAllPatients();
            foreach(var patient in patients)
            {
                if(patient.IcuId == icuId)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidateBeds(IcuModel icu)
        {
            if (icu.MaxBeds != 0 && CheckBedsCriteria(icu))  // check layout with BedId
            {
                return true;
            }
            return false;
        }

        public bool CheckBedsCriteria(IcuModel icu)
        {
            if (icu.Beds!=null && icu.NoOfBeds == icu.Beds.Count)  // check layout with BedId
            {
                return true;
            }
            return false;
        }

        public bool DoesIcuExists(string id)
        {
            var icu = _context.Icu.Find(id);
            if (icu == null)
            {
                return false;
            }
            return true;
        }

        public BedModel GetBed(string icuId, string bedId)
        {
            var beds = _context.Icu.Find(icuId).Beds;
            return beds.Find(_bed => _bed.BedId == bedId);
        }

        public bool IsBedOccupied(BedModel bed)
        {
            return (bed.BedOccupancyStatus == "Free") ? false : true;
        }

        public bool IsBedAvailable(string icuId, string bedId, out string msg)
        {
            if (DoesBedExists(icuId, bedId))
            {
                if (IsBedOccupied(GetBed(icuId, bedId)))
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

        public bool IsEmptySlotAvailableToAddBed(string icuId, out string msg)
        {
            var icu = _context.Icu.Find(icuId);
            if (!DoesIcuExists(icuId))
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

        public bool ChangeBedIdToOccupied(string icuId, string bedId)
        {
            var bed = GetBed(icuId, bedId);
            if (bed != null)
            {
                bed.BedOccupancyStatus = "Occupied";
                return true;
            }
            return false;
        }

        public bool ChangeBedIdFree(string icuId, string bedId)
        {
            var bed = GetBed(icuId, bedId);
            if (bed != null)
            {
                bed.BedOccupancyStatus = "Free";
                return true;
            }
            return false;
        }

        public bool DoesPateintExists(string id)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null)
            {
                return false;
            }
            return true;
        }

        public bool CanPatientBeAdded(PatientModel newPatient, out string msg)
        {
            if (DoesPateintExists(newPatient.PatientId))
            {
                msg = "Patient Already Exists";
                return false;
            }
            string message;
            if (IsBedAvailable(newPatient.IcuId, newPatient.BedId, out message))    // add vitals validation
            {
                msg = "Patient can be Added";
            }
            msg = message;
            return false;
        }

        #endregion
    }
}
