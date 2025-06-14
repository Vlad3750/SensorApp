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

        public static void SaveToCsv(SensorData sensorData, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(sensorData.Serialize());
            }
        }

        public static ListView LoadFromCsv(string filePath, ListView listView)
        {
            SensorData sensorData = new SensorData();

            using (StreamReader stream = new StreamReader(filePath))
            {
                while (!stream.EndOfStream)
                {
                    string? dataString = stream.ReadLine();
                    if (dataString != null)
                    {
                        sensorData = SensorData.Deserialize(dataString);
                        listView.Items.Add(sensorData);
                    }
                }
            }

            return listView;
        }
    }
}
