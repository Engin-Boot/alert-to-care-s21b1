using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Utility
{
    public class IcuDataHandler
    {
        private readonly CsvHandler _csvHandler;
        public IcuDataHandler()
        {
            _csvHandler = new CsvHandler();
        }
        public List<Models.IcuModel> ReadIcus(string filepath)
        {
            List<string> details = _csvHandler.ReadDetailsFromFile(filepath);
            List<Models.IcuModel> allIcus = new List<Models.IcuModel>();
            foreach (var line in details)
            {
                allIcus.Add(FormatStringToIcuObject(line.Split(',')));
            }
            return allIcus;
        }
        public Models.IcuModel FormatStringToIcuObject(string[] icuDetails)
        {

            Models.IcuModel icu = new Models.IcuModel()
            {
                IcuId = icuDetails[0],
                Layout = icuDetails[1],
                NoOfBeds = Int32.Parse(icuDetails[2]),
                MaxBeds = Int32.Parse(icuDetails[3]),
                BedsCounter = Int32.Parse(icuDetails[4])
            };
            return icu;
        }

        public bool WriteIcu(Models.IcuModel icu, string filepath)
        {
            string icuDetails = FormatIcuObjectToString(icu);
            return _csvHandler.WriteToFile(icuDetails, filepath);
        }
        private string FormatIcuObjectToString(Models.IcuModel icu)
        {
            var csvFormatData = "";
            if (icu.IcuId != null)
            {
                csvFormatData = string.Join(',', new object[]{
                    icu.IcuId,
                    icu.Layout,
                    icu.NoOfBeds.ToString(),
                    icu.MaxBeds.ToString(),
                    icu.BedsCounter.ToString()
                    });
            }
            return csvFormatData;
        }

        public bool DeleteIcu(string id, string filepath)
        {
            return _csvHandler.DeleteFromFile(id, filepath);
        }
    }
}
