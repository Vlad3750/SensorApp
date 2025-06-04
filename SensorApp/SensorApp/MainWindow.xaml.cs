using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using SensorLib;

namespace SensorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IpAdressWindow ipAdressWindow = new IpAdressWindow();

        DataListWindow dataListWindow = new DataListWindow();

        private DispatcherTimer timer = new DispatcherTimer();

        SensorData sensordata = new SensorData();



        public MainWindow()
        {
            InitializeComponent();
            ipAdressWindow.ShowDialog();
            timer.Interval = TimeSpan.FromMilliseconds(100);

            timer.Tick += Timer_Tick;
            timer.Start();

            

            getSensorData();

        }

        private async void getSensorData()
        {
            SensorData sensorData = await ConnectionManager.Main(ipAdressWindow.ipAddress);
        }

        private async void Timer_Tick(object? sender, EventArgs e)
        {
            sensordata.DrawAxie(X_Rectangle, Y_Rectangle, Z_Rectangle);

            //ConnectionManager.Main(ipAdressWindow.ipAddress);
        }

        private void ListButton_Click(object sender, RoutedEventArgs e)
        {
            DataListWindow window = new DataListWindow();
            window.Show();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            NamingWindow windowName = new NamingWindow(this, dataListWindow);

            windowName.Show();
        }
    }
}