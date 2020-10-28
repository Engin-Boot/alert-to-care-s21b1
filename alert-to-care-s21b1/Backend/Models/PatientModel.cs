using System.Collections.Generic;

namespace Backend.Models
{
    public class PatientModel
    {
        public string PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string IcuId { get; set; }
        public string BedId { get; set; }
        public string Address { get; set; }

        public string Gender { get; set; }

        public string ContactNo { get; set; }
    }
}
