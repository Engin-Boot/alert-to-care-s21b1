using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCareAPI.Models
{
    public class AddressModel
    {
        public string HouseNo { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PinCode { get; set; }

    }
}
