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
        private DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromMilliseconds(100);

            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            X_Label.Content = $"X-Achse: {SliderValue.Value:F2}°";
            X_Neigung.Content = $"Neigung X: {SliderValue.Value:F2}°";
        }

        private void ListButton_Click(object sender, RoutedEventArgs e)
        {
            DataListWindow window = new DataListWindow();
            window.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SensorData sensordata = new SensorData();
            sensordata.DrawAxie(X_Rectangle, Y_Rectangle, Z_Rectangle);
        }

        private void SliderValue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LabelValue.Content = $"Value: {SliderValue.Value:F2}";
            X_Rectangle.Height = (SliderValue.Value / 360) * 275;
        }
    }
}