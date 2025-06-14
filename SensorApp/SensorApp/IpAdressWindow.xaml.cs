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
            //this.Closing += IpAdressWindow_Closing;
        }

        //private void IpAdressWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    Application.Current.Shutdown();
        //}

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void IpAddressTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ipAddress = IpAddressTextBox.Text;
        }

        private async void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckConnection(await ConnectionManager.Main(ipAddress)))
                this.Close();
        }

        private bool CheckConnection(SensorData data)
        {
            if (data == null) return false;
            else return true;
        }
    }
}
