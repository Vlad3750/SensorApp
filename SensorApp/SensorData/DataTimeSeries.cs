using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SensorLib
{
    public class DataTimeSeries
    {

        public DataTimeSeries() 
        {
            
        }

        public static string SaveToJSON(SensorData sensorData)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true // für schön formatiertes JSON
            };

            return JsonSerializer.Serialize(sensorData, options);
        }

        public static async void LoadFromJSON(string filePath)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
               SensorData sensorData = await JsonSerializer.DeserializeAsync<SensorData>(stream);
            }
        }
    }
}
