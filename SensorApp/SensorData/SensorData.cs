
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
        public double Acc_X { get; set; } = 0;
        public double Acc_Y { get; set; } = 0;
        public double Acc_Z { get; set; } = 0;
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
            Acc_X = xAxis;
            Acc_Y = yAxis;
            Acc_Z = zAxis;
            TimeStamp = timeStamp;
        }

        public string Serialize()
        {
            return $"{Name};{Temp};{Acc_X};{Acc_Y};{Acc_Z};{TimeStamp}";
        }

        public static void Deserialize()
        {
           // TODO: Klasse machen
        }

        public void ListViewItemShow(ListView list)
        {
            list.Items.Add($"Name: {Name} | Data: {Temp} , {Acc_X} , {Acc_Y} , {Acc_Z} , {TimeStamp}");
        }

        public void DrawAxie(Rectangle x_Rectangle, Rectangle y_Rectangle, Rectangle z_Rectangle)
        {
            x_Rectangle.Height += Acc_X;
            y_Rectangle.Height += Acc_Y;
            z_Rectangle.Height += Acc_Z;
        }
    }

}
