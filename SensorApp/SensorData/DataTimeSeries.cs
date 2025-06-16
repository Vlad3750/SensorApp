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

        public DataTimeSeries() 
        {
            
        }

        public List<SensorData> sensorList = new List<SensorData>();

        public void SaveToCsv(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach(SensorData sensor in sensorList)
                {
                    sw.WriteLine(sensor.Serialize());
                }
            }
        }

        public void LoadFromCsv(string filePath, ObservableCollection<SensorData> oCollection)
        {
            using (StreamReader stream = new StreamReader(filePath))
            {
                while (!stream.EndOfStream)
                {
                    string? dataString = stream.ReadLine();
                    if (dataString != null)
                    {
                        sensorList.Add(SensorData.Deserialize(dataString));
                        oCollection.Add(SensorData.Deserialize(dataString));
                    }
                }
            }
        }
    }
}
