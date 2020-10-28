using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Utility
{
    public class VitalsDataHandler
    {
        private readonly CsvHandler _csvHandler;
        public VitalsDataHandler()
        {
            _csvHandler = new CsvHandler();
        }
        public List<Models. VitalsModel> ReadVitals(string filepath)
        {
            List<string> details = _csvHandler.ReadDetailsFromFile(filepath);
            List<Models. VitalsModel> allVitals = new List<Models.VitalsModel>();
            foreach (var line in details)
            {
                allVitals.Add(FormatStringToVitalsObject(line.Split(',')));
            }
            return allVitals;
        }

        public Models. VitalsModel FormatStringToVitalsObject(string[] vitalsDetails)
        {

            Models.VitalsModel vitals = new Models.VitalsModel()
            {
                PatientId = vitalsDetails[0],
                VitalId = vitalsDetails[1],
                Name = vitalsDetails[2],
                Value = float.Parse(vitalsDetails[3]),
                LowerLimit = float.Parse(vitalsDetails[4]),
                UpperLimit = float.Parse(vitalsDetails[5])
            };
            return vitals;
        }

        public bool Writevitals(Models. VitalsModel vitals, string filepath)
        {
            string vitalsDetails = FormatVitalsObjectToString(vitals);
            return _csvHandler.WriteToFile(vitalsDetails, filepath);
        }
        private string FormatVitalsObjectToString(Models. VitalsModel vitals)
        {
            var csvFormatData = "";
            if (vitals.VitalId != null)
            {
                csvFormatData = string.Join(',', new object[]{
                    vitals.PatientId,
                    vitals.VitalId,
                    vitals.Name,
                    vitals.Value.ToString(),
                    vitals.LowerLimit.ToString(),
                    vitals.UpperLimit.ToString()
                    });
            }
            return csvFormatData;
        }

        public bool DeleteVitals(string id, string filepath)
        {
            return _csvHandler.DeleteFromFile(id, filepath);
        }
    }
}
