using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
using Serilog;

namespace SensorApp
{
    /// <summary>
    /// Interaction logic for NamingWindow.xaml
    /// </summary>
    public partial class NamingWindow : Window
    {
        SensorData sensorData;
        ObservableCollection<SensorData> oCollection;

        public NamingWindow(MainWindow window, ObservableCollection<SensorData> dataCollection)
        {
            InitializeComponent();
            sensorData = window.sensorData;
            LabelTemp.Content = sensorData.Temp; 
            LabelX.Content = sensorData.Acc_X;
            LabelY.Content = sensorData.Acc_Y;
            LabelZ.Content = sensorData.Acc_Z;
            oCollection = dataCollection;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            sensorData.Name = TextBoxName.Text;
            sensorData.TimeStamp = DateTime.Now;

            oCollection.Add(sensorData);

            MessageBox.Show("Daten wurden gespeichert.");
            Log.Logger.Information($"{sensorData.Name} is saved in data.txt");
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Log.Logger.Information($"User decided not to save recieved data.");
        }
    }
}
 