using System.Collections.Generic;


namespace Backend.Utility
{
    public class BedDataHandler
    {
        private readonly CsvHandler _csvHandler;
        public BedDataHandler()
        {
            _csvHandler = new CsvHandler();
        }
        public List<Models.BedModel> Readbeds(string filepath)
        {
            List<string> details = _csvHandler.ReadDetailsFromFile(filepath);
            List<Models.BedModel> allBeds = new List<Models.BedModel>();
            foreach (var line in details)
            {
                allBeds.Add(FormatStringToBedObject(line.Split(',')));
            }
            return allBeds;
        }
        private Models.BedModel FormatStringToBedObject(string[] bedDetails)
        {

            Models.BedModel bed = new Models.BedModel()
            {
                BedId=bedDetails[0],
                IcuId = bedDetails[1],
                BedOccupancyStatus = bedDetails[2],
                Location = bedDetails[3]
            };
            return bed;
        }

        public bool WriteBed(Models.BedModel bed, string filepath)
        {
            string bedDetails = FormatBedObjectToString(bed);
            return _csvHandler.WriteToFile(bedDetails, filepath);
        }
        private string FormatBedObjectToString(Models.BedModel bed)
        {
            var csvFormatData = "";
            if (bed.BedId != null)
            {
                csvFormatData = string.Join(',', new object[]{
                    bed.BedId,
                    bed.IcuId,
                    bed.BedOccupancyStatus,
                    bed.Location
                    });
            }
            return csvFormatData;
        }

        public bool DeleteBed(string id, string filepath)
        {
            return _csvHandler.DeleteFromFile(id, filepath);
        }
    }
}
