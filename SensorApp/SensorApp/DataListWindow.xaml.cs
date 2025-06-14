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
    /// Interaction logic for DataListWindow.xaml
    /// </summary>
    public partial class DataListWindow : Window
    {
        public ObservableCollection<SensorData> oCollection = new ObservableCollection<SensorData>();
        public ICollectionView collectionView;
        string searchText;

        public DataListWindow(ObservableCollection<SensorData> oCollection)
        {
            InitializeComponent();

            collectionView = CollectionViewSource.GetDefaultView(oCollection);
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
            if(searchText != null)
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
            }
            else
            {
                collectionView.Filter = null;
            }
        }
    }
}
