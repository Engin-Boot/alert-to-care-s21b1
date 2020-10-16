using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCareAPI.Models
{
    public class PatientModel
    {
        public string Name { get; set; }
        public string PatientId { get; set; }
        public int Age { get; set; }
        public string IcuId { get; set; }
        public string BedId { get; set; }
        public VitalsModel Vitals { get; set; }
        public AddressModel Address { get; set; }
    }
}
