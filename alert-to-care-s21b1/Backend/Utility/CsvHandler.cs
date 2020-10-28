using System;
using System.Collections.Generic;
using System.IO;


namespace Backend.Utility
{
    public class CsvHandler
    {
        public List<string> ReadDetailsFromFile(string filepath)
        {
            List<string> details = new List<string>();
            try
            {
                details = WriteObjectsToList(details, filepath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return details;
        }
        private List<string> WriteObjectsToList(List<string> details, string filepath)
        {
            using var reader = new StreamReader(filepath);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    details.Add(line);
                }
            }
            return details;
        }
        

        public bool WriteToFile(string data, string filepath)
        {
            if (!File.Exists(filepath))
            {
                return false;
            }
            return AppendTextToFile(data, filepath);
        }
        private bool AppendTextToFile(string  csvData, string filepath)
        {
            bool isWritten = false;
            if (!string.IsNullOrEmpty(csvData))
            {
                File.AppendAllText(filepath, csvData+Environment.NewLine);
                //File.AppendAllText(filepath, Environment.NewLine);
                isWritten = true;
            }
            return isWritten;
        }

        public bool DeleteFromFile(string id, string filepath)
        {
            bool isDeleted = false;

            List<string> devices = new List<string>();
            try
            {
                isDeleted = ReadLinesFromFile(id, devices, filepath);
                WriteLinesToFile(devices, filepath);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return isDeleted;

        }
        private bool ReadLinesFromFile(string id, List<string> lines, string filepath)
        {
            int lineCounter = 0;

            using var reader = new StreamReader(filepath);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lineCounter++;
                var values = line.Split(',');
                if (id != values[0])
                {
                    lines.Add(line);
                }
            }
            bool isDeleted = CompareDataListsAfterDelete(lineCounter, lines);

            return isDeleted;
        }

        private void WriteLinesToFile(List<string> lines, string filepath)
        {
            using var writer = new StreamWriter(filepath);
            foreach (var writeline in lines)
            {
                writer.WriteLine(writeline);

            }
        }
        private bool CompareDataListsAfterDelete(int lineCounter, List<string> lines)
        {

            return lineCounter != lines.Count;
        }
    }
}
