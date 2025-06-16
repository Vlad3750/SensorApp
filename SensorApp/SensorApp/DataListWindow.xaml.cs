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
using Serilog;

namespace SensorApp
{
    /// <summary>
    /// Interaction logic for DataListWindow.xaml
    /// </summary>
    public partial class DataListWindow : Window
    {
        public ICollectionView collectionView;
        private ObservableCollection<SensorData> _dataCollection;
        string searchText;

        public DataListWindow(ObservableCollection<SensorData> oCollection)
        {
            InitializeComponent();

            _dataCollection = oCollection;
            collectionView = CollectionViewSource.GetDefaultView(_dataCollection);
            DataListView.ItemsSource = collectionView;
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

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            searchText = TextBoxSearchBar.Text;
            if(searchText != "Search here ...")
            {
                if (collectionView == null)
                    return;

                // Update filter whenever the search text changes
                collectionView.Filter = searchText =>
                {
                    if (searchText is SensorData sensorData)
                    {
                        return string.IsNullOrEmpty(TextBoxSearchBar.Text) ||
                               sensorData.Name.Contains(TextBoxSearchBar.Text, StringComparison.OrdinalIgnoreCase);
                    }
                    return false;
                };
                Log.Logger.Information($"Searching for {searchText} in listView.");
            }
            else if (string.IsNullOrEmpty(searchText))
            {
                collectionView.Filter = null;
                collectionView = CollectionViewSource.GetDefaultView(_dataCollection);
                DataListView.ItemsSource = collectionView;
            }
            else
            {
                collectionView.Filter = null;
            }
        }
    }
}
