using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCareAPI.Models
{
    public class VitalsModel
    {
        public string PatientId { get; set; }
        public float Bpm { get; set; }
        public float Spo2 { get; set; }
        public float RespRate { get; set; }

       

    }
}
