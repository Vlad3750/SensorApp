using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SensorLib
{
    internal class DataTimeSeries
    {
        public List<SensorData> dataList;

        public DataTimeSeries(SensorData sensorData) 
        {
            dataList.Add(sensorData);
        }

        public void SaveToCsv(string filePath)
        {

        }

        public void LoadFromCsv(string filePath)  // <- ReturnTyp to List<SensorData>
        {

        }

        public void ShowDataList(ListView list)
        {

        }
    }
}
