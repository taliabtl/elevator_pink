using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace elevator_simulation
{
    internal class ModelReader
    {
        public List<HourlyFloorData> LoadModel(string path)
        {
            if (!File.Exists(path)) return new List<HourlyFloorData>();

            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return new List<HourlyFloorData>(csv.GetRecords<HourlyFloorData>());
        }
    }
}
