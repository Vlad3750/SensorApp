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
    /// Interaction logic for NamingWindow.xaml
    /// </summary>
    public partial class NamingWindow : Window
    {
        MainWindow mainWindow = new MainWindow();
        SensorData sensorData = new SensorData();
        public NamingWindow(MainWindow window)
        {
            MainWindow mainWindow = window;
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            sensorData.Name = TextBoxName.Text;
            sensorData.XAxis = Convert.ToDouble(mainWindow.X_Neigung.Content);
            sensorData.YAxis = Convert.ToDouble(mainWindow.Y_Neigung.Content);
            sensorData.ZAxis = Convert.ToDouble(mainWindow.Z_Neigung.Content);
            sensorData.Temp = Convert.ToDouble(mainWindow.Temperatur.Content);

            MessageBox.Show($"{sensorData.Name}|{sensorData.XAxis}|" +
                $"{sensorData.YAxis}|{sensorData.ZAxis}|{sensorData.Temp}");

            MessageBox.Show("Daten wurden gespeichert.");
        }
    }
}
