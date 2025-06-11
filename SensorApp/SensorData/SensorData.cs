
using System.Diagnostics;
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
        private double acc_X;
        public double Draw_Acc_X
        {

            get
            {   
                return acc_X;
            }

            set
            {
                if (Acc_X > 200)
                {
                    acc_X = 200;
                }
                else if (Acc_X < -200)
                {
                    acc_X = -200;
                }
                else
                {
                    acc_X = value;
                }
            }
        }          
            
        public double Acc_Y { get; set; } = 0;
        private double acc_Y;
        public double Draw_Acc_Y
        {

            get
            {
                return acc_Y;
            }

            set
            {
                if (Acc_Y > 200)
                {
                    acc_Y = 200;
                }
                else if (Acc_Y < -200)
                {
                    acc_Y = -200;
                }
                else
                {
                    acc_Y = value;
                }
            }
        }

        public double Acc_Z { get; set; } = 0;

        private double acc_Z;
        public double Draw_Acc_Z
        {

            get
            {
                return acc_Z;
            }

            set
            {
                if (Acc_Z > 200)
                {
                    acc_Z = 200;
                }
                else if (Acc_Z < -200)
                {
                    acc_Z = -200;
                }
                else
                {
                    acc_Z = value;
                }
            }
        }

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

        public override string ToString()
        {
            return $"Name: {Name} | Data: {Temp} , {Acc_X} , {Acc_Y} , {Acc_Z} , {TimeStamp}";
        }
    }

}
