using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCareAPI.Models;

namespace AlertToCareAPI.Repository
{
    public class Test:ITest
    {
        readonly List<BedModel> _beds = new List<BedModel>();

        public Test()
        {
            _beds.Add(new BedModel("132","Free"));
            _beds.Add(new BedModel("123", "Occupied"));
        }
        public IEnumerable<BedModel> GetAllBeds()
        {
            return _beds;
        }
    }
}
