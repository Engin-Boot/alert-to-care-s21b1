using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare_API.Models
{
   
    public class Beds
    {
        public string BedID { get; set; }
        public string IcuID { get; set; }
        public bool BedOccupancyStatus { get; set; }
    }
}
