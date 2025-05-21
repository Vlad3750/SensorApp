
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents.Serialization;
using System.Windows.Shapes;

namespace SensorLib
{
    public class SensorData
    {
        public double Temp { get; set; } = 0;
        public double XAxis { get; set; } = 0;
        public double YAxis { get; set; } = 0;
        public double ZAxis { get; set; } = 0;
        public DateTime TimeStamp { get; set; }

        public SensorData()
        {

        }

        public SensorData(double temp, double xAxis, double yAxis, double zAxis, DateTime timeStamp)
        {
            Temp = temp;
            XAxis = xAxis;
            YAxis = yAxis;
            ZAxis = zAxis;
            TimeStamp = timeStamp;
        }

        public string SerializeToCsv()
        {
            return $"{Temp};{XAxis};{YAxis};{ZAxis};{TimeStamp}";
        }

        public static SensorData Deserialize(string data)
        {
            string[] dataSplit = data.Split(";");

            double temp = double.Parse(dataSplit[0]);
            double xAxis = double.Parse(dataSplit[1]);
            double yAxis = double.Parse(dataSplit[2]);
            double zAxis = double.Parse(dataSplit[3]);
            DateTime timeStamp = DateTime.Parse(dataSplit[4]);

            SensorData sensorData = new SensorData(temp, xAxis, yAxis, zAxis, timeStamp);

            return sensorData;

        }

        public void ListViewItemShow(ListView list)
        {
            list.Items.Add($"Data: {Temp} | {XAxis} | {YAxis} | {ZAxis} | {TimeStamp}");
        }

        public void DrawAxie(Rectangle x_Rectangle, Rectangle y_Rectangle, Rectangle z_Rectangle)
        {
            x_Rectangle.Height += XAxis;
            y_Rectangle.Height += YAxis;
            z_Rectangle.Height += ZAxis;
        }
    }

}
