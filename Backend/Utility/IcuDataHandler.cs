using System;
using System.Collections.Generic;


namespace Backend.Utility
{
    public class IcuDataHandler
    {
        private readonly CsvHandler _csvHandler;
        public IcuDataHandler()
        {
            _csvHandler = new CsvHandler();
        }
        public List<Models.PatientVitalsModels> ReadIcus(string filepath)
        {
            List<string> details = _csvHandler.ReadDetailsFromFile(filepath);
            List<Models.PatientVitalsModels> allIcus = new List<Models.PatientVitalsModels>();
            foreach (var line in details)
            {
                allIcus.Add(FormatStringToIcuObject(line.Split(',')));
            }
            return allIcus;
        }
        private Models.PatientVitalsModels FormatStringToIcuObject(string[] icuDetails)
        {

            Models.PatientVitalsModels icu = new Models.PatientVitalsModels()
            {
                IcuId = icuDetails[0],
                Layout = icuDetails[1],
                NoOfBeds = Int32.Parse(icuDetails[2]),
                MaxBeds = Int32.Parse(icuDetails[3]),
                BedsCounter = Int32.Parse(icuDetails[4])
            };
            return icu;
        }

        public bool WriteIcu(Models.PatientVitalsModels icu, string filepath)
        {
            string icuDetails = FormatIcuObjectToString(icu);
            return _csvHandler.WriteToFile(icuDetails, filepath);
        }
        private string FormatIcuObjectToString(Models.PatientVitalsModels icu)
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
