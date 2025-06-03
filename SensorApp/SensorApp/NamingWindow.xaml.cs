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
            sensorData.AccX = Convert.ToDouble(mainWindow.AccX.Content);
            sensorData.AccY = Convert.ToDouble(mainWindow.AccY.Content);
            sensorData.AccZ = Convert.ToDouble(mainWindow.AccZ.Content);
            sensorData.Temp = Convert.ToDouble(mainWindow.Temperatur.Content);

            MessageBox.Show($"{sensorData.Name}|{sensorData.AccX}|" +
                $"{sensorData.AccY}|{sensorData.AccZ}|{sensorData.Temp}");

            MessageBox.Show("Daten wurden gespeichert.");
        }
    }
}
