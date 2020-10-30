using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class PatientVitalsModel
    {
        public string PatientId { get; set; }
        public List<VitalsModel> Vitals {get;set;}
    }
}
