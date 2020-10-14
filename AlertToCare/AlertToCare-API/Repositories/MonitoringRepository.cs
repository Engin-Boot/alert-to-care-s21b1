using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCare_API.DataBase;
using AlertToCare_API.Models;

namespace AlertToCare_API.Repositories
{
    //we alert the subscriber
    public class MonitoringRepository
    {
        readonly Data _db = new Data();
        readonly List<PatientVitals> _patientVitals;

        public MonitoringRepository()
        {
            this._patientVitals = _db.GetVitalsList();
        }

        public IEnumerable<PatientVitals> GetPatientVitals()
        {
            return _patientVitals;
        }

        //check vital and send mail,sms--interface
    }
}
