using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SensorLib
{
    internal class DataTimeSeries
    {

        public DataTimeSeries() 
        {
            
        }

        public void SaveToJSON(string filePath, SensorData sensorData)
        {
            using (StreamWriter stream = new StreamWriter(filePath))
            {
                stream.WriteLine(sensorData.Serialize());
            }
        }

        public SensorData LoadFromJSON(string filePath)
        {
            SensorData sensorData = new SensorData();
            using (StreamReader stream = new StreamReader(filePath))
            {
                while (!stream.EndOfStream)
                {
                    string? sensorData_string = stream.ReadLine();
                    if (sensorData_string != null)
                    {
                        // TODO: Ändern
                    }
                }
            }

            return sensorData;
        }
    }
}
