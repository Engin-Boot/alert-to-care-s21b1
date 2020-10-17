using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCareAPI.Models
{
    public class BedModel
    {
        [Key]
        public string BedId { get; set; }
        public string BedOccupancyStatus { get; set; }
        
    }
}
