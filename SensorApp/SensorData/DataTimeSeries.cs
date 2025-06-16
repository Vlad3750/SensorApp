using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using Serilog;

namespace SensorLib
{
    public class DataTimeSeries
    {
        public static void SaveToCsv(string filePath, ObservableCollection<SensorData> sensorList)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach(SensorData sensor in sensorList)
                {
                    sw.WriteLine(sensor.Serialize());
                }
            }
            Log.Logger.Information($"Saving into data.txt ...");
        }

        public static ObservableCollection<SensorData> LoadFromCsv(string filePath)
        {
            var oCollection = new ObservableCollection<SensorData>();

            if (!File.Exists(filePath))
            {
                Log.Logger.Warning($"CSV file not found at path: {filePath}");
                return oCollection;
            }

            using (StreamReader stream = new StreamReader(filePath))
            {
                while (!stream.EndOfStream)
                {
                    string? dataString = stream.ReadLine();
                    if (!string.IsNullOrWhiteSpace(dataString))
                    {
                        oCollection.Add(SensorData.Deserialize(dataString));
                    }
                }
            }

            Log.Logger.Information("Loading collected data into listView ...");
            return oCollection;
        }
    }
}
