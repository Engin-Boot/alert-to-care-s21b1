using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class IcuModel
    {
        public string IcuId { get; set; }
        public string Layout { get; set; }
        //public List<BedModel> Beds { get; set; }
        public int NoOfBeds { get; set; }
        public int MaxBeds { get; set; }

        public int BedsCounter { get; set; }
    }
}
