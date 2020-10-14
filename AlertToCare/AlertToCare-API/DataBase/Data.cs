using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AlertToCare_API.Models;

namespace AlertToCare_API.DataBase
{
    //this is like db where icu info,bed info and patient info present
    public class Data
    {
        List<Icu> _icuList = new List<Icu>();       //complete list
        readonly List<Beds> _bedList = new List<Beds>();
        List<Patients> _patientsList = new List<Patients>();
        readonly List<PatientVitals> _patientVitals = new List<PatientVitals>();      
        public Data()
        {

            Icu icu = new Icu()
            {
                IcuId = "ICU01",
                LayoutID = "LID01",
                BedsCount = 6,
                Patients = new List<Patients>()
                {

                           new Patients()
                           {
                               PatientID="PID001",PatientName="Kane",
                               PatientDetails =new PatientDetails()
                               {
                                   Age=31,ContactNo="9440476954",Address="hyd",Email="kane@email.com"
                               },
                               PatientVitals=new PatientVitals()
                               {
                                   PatientId="PID001",Spo2=96,Bpm=80,RespRate=121
                               }

                           },

                           new Patients()
                           {
                                PatientID="PID002",PatientName="Undertaker",
                               PatientDetails =new PatientDetails()
                               {
                                   Age=25,ContactNo="9440476955",Address="hyd",Email="undertaker@email.com"
                               },
                               PatientVitals=new PatientVitals()
                               {
                                   PatientId="PID00",Spo2=98,Bpm=100,RespRate=141
                               }
                           },

                           new Patients()
                           {
                                PatientID="PID003",PatientName="rey",
                               PatientDetails =new PatientDetails()
                               {
                                   Age=26,ContactNo="9440476956",Address="hyd",Email="rey@email.com"
                               },
                               PatientVitals=new PatientVitals()
                               {
                                   PatientId="PID003",Spo2=94,Bpm=120,RespRate=161
                               }
                           }






                }
            };

            _icuList.Add(icu);

            //beds

            _bedList = new List<Beds>()
            {
                new Beds()
                {
                    BedID="BID01",IcuID="ICU01",BedOccupancyStatus=true
                },

                new Beds()
                {
                    BedID="BID02",IcuID="ICU01",BedOccupancyStatus=true
                },
                new Beds()
                {
                    BedID="BID03",IcuID="ICU01",BedOccupancyStatus=true
                },
                new Beds()
                {
                    BedID="BID04",IcuID="ICU01",BedOccupancyStatus=false
                },
                new Beds()
                {
                    BedID="BID05",IcuID="ICU01",BedOccupancyStatus=false
                },
                new Beds()
                {
                    BedID="BID06",IcuID="ICU01",BedOccupancyStatus=false
                },
            };


        }


        //bed and icu is added



        public List<Icu> GetIcuList()
        {
            return _icuList;
        }

        public List<PatientVitals> GetVitalsList()
        {
            foreach(var patient in _patientsList)
            {
                _patientVitals.Add(patient.PatientVitals);
            }
            return _patientVitals;
        }
        public List<Patients> GetPatientsList()
        {
            foreach(var icu in _icuList)
            {
                foreach(var patient in icu.Patients)
                {
                    _patientsList.Add(patient);
                }
            }

            return _patientsList;
        }

        public List<Beds> GetBedList()
        {
            return _bedList;
        }
        

        //Updates
        public void UpdateIcuList(List<Icu> icu)
        {
            _icuList = icu;
        }

        public void UpdatePatientList(List<Patients> patients)
        {
            _patientsList = patients;
        }
    }
    
}