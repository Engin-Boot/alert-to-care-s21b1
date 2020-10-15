using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCareAPI.Models;

namespace AlertToCareAPI.Repository
{
    public class Test:ITest
    {
        List<Bed> beds = new List<Bed>();

        public Test()
        {
            beds.Add(new Bed("132","Free"));
            beds.Add(new Bed("123", "Occupied"));
        }
        public IEnumerable<Bed> GetAllBeds()
        {
            return beds;
        }
    }
}
