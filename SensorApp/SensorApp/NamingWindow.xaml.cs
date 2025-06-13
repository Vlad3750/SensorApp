using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for NamingWindow.xaml
    /// </summary>
    public partial class NamingWindow : Window
    {
        SensorData sensorData = new SensorData();
        ListView dataListView;

        public NamingWindow(SensorData sensorData, DataListWindow dataListWindow)
        {
            this.sensorData = sensorData;
            this.dataListView = dataListWindow.DataListView;
            InitializeComponent();
            LabelTemp.Content = sensorData.Temp;
            LabelX.Content = sensorData.Acc_X;
            LabelY.Content = sensorData.Acc_Y;
            LabelZ.Content = sensorData.Acc_Z;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            sensorData.Name = TextBoxName.Text;
            sensorData.TimeStamp = DateTime.Now;

            dataListView.Items.Add(sensorData);

            DataTimeSeries.SaveToJSON(sensorData);

            MessageBox.Show("Daten wurden gespeichert.");
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
