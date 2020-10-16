using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCareAPI.Models
{
    public class BedModel
    {
        private readonly string[] _allowedValueForStatus = new string[]{"Occupied", "Free"};
        public BedModel(string id, string status)
        {
            this.BedId = id;
            this.BedOccupancyStatus = status;
        }

        private string _bedOccupancyStatus;
        public string BedId { get; set; }
        public string BedOccupancyStatus {
            get => this._bedOccupancyStatus;
            set
            {
                if (_allowedValueForStatus.All(x => x != value))
                    throw new ArgumentException("Not valid Status for bed occupancy");
                _bedOccupancyStatus = value;
            }
        }
    }
}
