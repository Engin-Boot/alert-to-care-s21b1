using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCareAPI.Models
{
    public class PatientModel
    {
        [Key]
        public string PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string IcuId { get; set; }
        public string BedId { get; set; }
        public IEnumerable<VitalsModel> Vitals { get; set; }
        public string Address { get; set; }
    }
}
