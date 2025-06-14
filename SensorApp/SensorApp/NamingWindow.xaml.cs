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
        ObservableCollection<SensorData> oCollection;
        ICollectionView cView;
        ListView dataListView;
        DataTimeSeries timeSeries = new DataTimeSeries();

        public NamingWindow(SensorData sensorData, DataListWindow dataListWindow, DataTimeSeries timeSeries)
        {
            InitializeComponent();
            this.sensorData = sensorData;
            oCollection = dataListWindow.oCollection;
            this.cView = dataListWindow.collectionView;
            dataListView = dataListWindow.DataListView;
            LabelTemp.Content = sensorData.Temp;
            LabelX.Content = sensorData.Acc_X;
            LabelY.Content = sensorData.Acc_Y;
            LabelZ.Content = sensorData.Acc_Z;
            this.timeSeries = timeSeries;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            sensorData.Name = TextBoxName.Text;
            sensorData.TimeStamp = DateTime.Now;

            oCollection.Add(sensorData);
            cView = CollectionViewSource.GetDefaultView(oCollection);
            dataListView.ItemsSource = cView;


            timeSeries.sensorList.Add(sensorData);

            MessageBox.Show("Daten wurden gespeichert.");
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
