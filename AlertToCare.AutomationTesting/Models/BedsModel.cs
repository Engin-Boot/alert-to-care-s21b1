using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlertToCare.AutomationTesting.Models
{
    class BedsDataModel
    {
        [Key]
        public string BedId { get; set; }
        public string BedOccupancyStatus { get; set; }
        public string Location { get; set; }
    }
}
