
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents.Serialization;
using System.Windows.Shapes;

namespace SensorLib
{
    public class SensorData
    {
        public string Name { get; set; } = "";
        public double Temp { get; set; } = 0;
        public double XAxis { get; set; } = 0;
        public double YAxis { get; set; } = 0;
        public double ZAxis { get; set; } = 0;
        public DateTime TimeStamp { get; set; }

        public SensorData()
        {

        }

        public SensorData(string name,  double temp, double xAxis, double yAxis, double zAxis, DateTime timeStamp)
        {
            Name = Name;
            Temp = temp;
            XAxis = xAxis;
            YAxis = yAxis;
            ZAxis = zAxis;
            TimeStamp = timeStamp;
        }

        public string Serialize()
        {
            return $"{Name};{Temp};{XAxis};{YAxis};{ZAxis};{TimeStamp}";
        }

        public static SensorData Deserialize(string data)
        {
            string[] dataSplit = data.Split(";");

            string name = dataSplit[0];
            double temp = double.Parse(dataSplit[1]);
            double xAxis = double.Parse(dataSplit[2]);
            double yAxis = double.Parse(dataSplit[3]);
            double zAxis = double.Parse(dataSplit[4]);
            DateTime timeStamp = DateTime.Parse(dataSplit[5]);

            SensorData sensorData = new SensorData(name, temp, xAxis, yAxis, zAxis, timeStamp);

            return sensorData;

        }

        public void ListViewItemShow(ListView list)
        {
            list.Items.Add($"Name: {Name} | Data: {Temp}° , {XAxis}° , {YAxis}° , {ZAxis}° , {TimeStamp}°");
        }

        public void DrawAxie(Rectangle x_Rectangle, Rectangle y_Rectangle, Rectangle z_Rectangle)
        {
            x_Rectangle.Height += XAxis;
            y_Rectangle.Height += YAxis;
            z_Rectangle.Height += ZAxis;
        }
    }

}
