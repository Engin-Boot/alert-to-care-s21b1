using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare_API.Models
{

    // layout and bedcount and patient
    public class Icu
    {
        public string IcuId { get; set; }
        public string LayoutID { get; set; }
        public int BedsCount { get; set; }

        public List<Patients> Patients { get; set; }
    }
}
