
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
            Name = name;
            Temp = temp;
            AccX = xAxis;
            AccY = yAxis;
            AccZ = zAxis;
            TimeStamp = timeStamp;
        }

        public string Serialize()
        {
            return $"{Name};{Temp};{AccX};{AccY};{AccZ};{TimeStamp}";
        }

        public static void Deserialize()
        {
           // TODO: Klasse machen
        }

        public void ListViewItemShow(ListView list)
        {
            list.Items.Add($"Name: {Name} | Data: {Temp} , {AccX} , {AccY} , {AccZ} , {TimeStamp}");
        }

        public void DrawAxie(Rectangle x_Rectangle, Rectangle y_Rectangle, Rectangle z_Rectangle)
        {
            x_Rectangle.Height += AccX;
            y_Rectangle.Height += AccY;
            z_Rectangle.Height += AccZ;
        }
    }

}
