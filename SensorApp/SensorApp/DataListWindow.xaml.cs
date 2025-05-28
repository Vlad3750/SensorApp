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

        private void TextBoxSearchBar_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxSearchBar.Text = "";
            TextBoxSearchBar.Foreground = Brushes.Black;
        }

        private void TextBoxSearchBar_LostFocus(object sender, RoutedEventArgs e)
        {
            if(TextBoxSearchBar.Text == "")
            {
                TextBoxSearchBar.Text = "Search here ...";
                TextBoxSearchBar.Foreground = Brushes.LightGray;
            }
        }
    }
}
