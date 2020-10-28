using Backend.Models;
using System.Collections.Generic;

namespace Backend.Repository
{
    public interface IBedRepository
    {
        bool AddBed(string icuId, string locationOfBed = "not specified");
        IEnumerable<BedModel> GetAllBedsFromAnIcu(string icuId);

        IEnumerable<BedModel> GetAllBeds();
        bool RemoveBed(string icuId, string bedId);
    }
}