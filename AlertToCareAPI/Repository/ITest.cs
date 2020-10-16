using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCareAPI.Models;

namespace AlertToCareAPI.Repository
{
    public interface ITest
    {
        IEnumerable<BedModel> GetAllBeds();
    }
}
