
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
        public double GX { get; set; } = 0;
        public double GY { get; set; } = 0;
        public double GZ { get; set; } = 0;
        public double AccX { get; set; } = 0;
        public double AccY { get; set; } = 0;
        public double AccZ { get; set; } = 0;
        public double MagX { get; set; } = 0;
        public double MagY { get; set; } = 0;
        public double MagZ { get; set; } = 0;
        public DateTime TimeStamp { get; set; }

        public SensorData()
        {

        }

        public SensorData(string name,  double temp, double xAxis, double yAxis, double zAxis, DateTime timeStamp)
        {
            Name = Name;
            Temp = temp;
            GX = xAxis;
            GY = yAxis;
            GZ = zAxis;
            TimeStamp = timeStamp;
        }

        public string Serialize()
        {
            return $"{Name};{Temp};{GX};{GY};{GZ};{TimeStamp}";
        }

        public static void Deserialize()
        {
           // TODO: Klasse machen
        }

        public void ListViewItemShow(ListView list)
        {
            list.Items.Add($"Name: {Name} | Data: {Temp} , {GX} , {GY} , {GZ} , {TimeStamp}");
        }

        public void DrawAxie(Rectangle x_Rectangle, Rectangle y_Rectangle, Rectangle z_Rectangle)
        {
            x_Rectangle.Height += GX;
            y_Rectangle.Height += GY;
            z_Rectangle.Height += GZ;
        }
    }

}
