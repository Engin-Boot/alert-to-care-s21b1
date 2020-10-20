using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlertToCare.AutomationTesting.Models
{
    class PatientModel
    {

        [Key]
        public string PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string IcuId { get; set; }
        public string BedId { get; set; }
        public List<VitalModel> Vitals { get; set; }
        public string Address { get; set; }
    }
}

