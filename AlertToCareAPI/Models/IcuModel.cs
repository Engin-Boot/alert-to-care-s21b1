using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCareAPI.Models
{
    public class IcuModel
    {
        [Key]
        public string IcuId { get; set; }
        public string Layout { get; set; }
        public IEnumerable<BedModel> Beds { get; set; }
        public int NoOfBeds { get; set; }
        public int MaxBeds { get; set; }
    }
}
