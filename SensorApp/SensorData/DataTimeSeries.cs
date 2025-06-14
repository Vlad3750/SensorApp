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

        public ObservableCollection<SensorData> sensorList = new ObservableCollection<SensorData>();

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

        public static ObservableCollection<SensorData> LoadFromCsv(string filePath, ObservableCollection<SensorData> listView)
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
                        listView.Add(sensorData);
                    }
                }
            }

            return listView;
        }
    }
}
