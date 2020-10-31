using System.Collections.Generic;


namespace Backend.Models
{
    public class PatientVitalsModel
    {
        public string PatientId { get; set; }
        public List<VitalsModel> Vitals {get;set;}
    }
}
