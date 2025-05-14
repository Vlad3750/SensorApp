
using System.Windows.Controls;
using System.Windows.Documents.Serialization;

namespace SensorLib
{
    public class SensorData
    {
        public double temp { get; set; }

        public double xAxis { get; set; }

        public double yAxis { get; set; }

        public double zAxis { get; set; }

        public DateTime TimeStamp { get; set; }

        public SensorData()
        {

        }

        public void SerializeToCsv()
        {

        }

        public void Deserialize()   // <- ReturnTyp to SensorData
        {

        }

        public void DrawCanvas(Canvas canvas)
        {

        }
    }

}
