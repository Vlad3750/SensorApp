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
        }

        public static ObservableCollection<SensorData> LoadFromCsv(string filePath)
        {
            var oCollection = new ObservableCollection<SensorData>();

            using (StreamReader stream = new StreamReader(filePath))
            {
                while (!stream.EndOfStream)
                {
                    string? dataString = stream.ReadLine();
                    if (dataString != null)
                    {
                        oCollection.Add(SensorData.Deserialize(dataString));
                    }
                }
            }

            return oCollection;
        }
    }
}
