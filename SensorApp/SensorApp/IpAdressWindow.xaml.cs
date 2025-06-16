using SensorLib;
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
using Serilog;

namespace SensorApp
{
    /// <summary>
    /// Interaction logic for IpAdressWindow.xaml
    /// </summary>
    public partial class IpAdressWindow : Window
    {
        public string ipAddress { get; set; }
        public IpAdressWindow()
        {
            InitializeComponent();
            this.Closing += IpAdressWindow_Closing;
        }

        private void IpAdressWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ipAddress == null)
            {
                Application.Current.Shutdown();
            }
            Log.Logger.Information("Ip-Adress not provided. Application closed.");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            Log.Logger.Information("Ip-Adress not provided. Application closed.");
        }

        private async void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ipAddress = IpAddressTextBox.Text;
            Log.Logger.Information("Ip-Adress provided. Application started. Sensor is measuring.");
            if (CheckConnection(await ConnectionManager.Main(ipAddress)))
            {
                this.Close();
            }
        }

        private bool CheckConnection(SensorData data)
        {
            if (data == null) return false;
            else return true;
        }
    }
}
