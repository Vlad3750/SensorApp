using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SensorLib;

namespace SensorApp
{
    /// <summary>
    /// Interaction logic for DataListWindow.xaml
    /// </summary>
    public partial class DataListWindow : Window
    {
        public DataListWindow()
        {
            InitializeComponent();

            SensorData sensorData = new SensorData();

            sensorData.ListViewItemShow(DataListView);
        }
        
    }
}
