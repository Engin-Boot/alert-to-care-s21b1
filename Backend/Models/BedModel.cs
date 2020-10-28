using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class BedModel
    {
        public string BedId { get; set; }
        public string IcuId { get; set; }
        public string BedOccupancyStatus { get; set; }
        public string Location { get; set; }
    }
}
