using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlertToCare.AutomationTesting.Models
{
    class VitalModel
    {
        [Key]
        public string IcuId { get; set; }
        public string Layout { get; set; }
        public List<BedsDataModel> Beds { get; set; }
        public int NoOfBeds { get; set; }
        public int MaxBeds { get; set; }
    }
}