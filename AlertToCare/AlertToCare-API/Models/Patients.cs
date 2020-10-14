using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare_API.Models
{
    public class Patients
    {
        public string PatientID { get; set; }
        public string PatientName { get; set; }
        public string BedID { get; set; }
        public string IcuID { get; set; }

        public PatientDetails PatientDetails { get; set; }
        public PatientVitals PatientVitals { get; set; }

    }
}
