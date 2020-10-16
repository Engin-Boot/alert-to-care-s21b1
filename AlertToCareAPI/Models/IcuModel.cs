using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCareAPI.Models
{
    public class IcuModel
    {
        public string IcuId { get; set; }
        public string Layout { get; set; }
        public int NoOfBeds { get; set; }
        public int MaxBeds { get; set; }
    }
}
