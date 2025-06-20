﻿using System.Collections.ObjectModel;
using System.Diagnostics;
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
using Serilog;

namespace SensorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IpAdressWindow ipAdressWindow;

        DataListWindow dataListWindow;

        ObservableCollection<SensorData> oCollection = new ObservableCollection<SensorData>();

        private DispatcherTimer timer = new DispatcherTimer();

        public SensorData sensorData = new SensorData();

        // Ticks and frames
        private int tick;
        private const int tickDelay = 3;

        // Sizes
        public double desired_X;
        public double desired_Y;
        public double desired_Z;

        private const double changeFactor = 0.1;

        public MainWindow()
        {
            InitializeComponent();

            oCollection = DataTimeSeries.LoadFromCsv("data.txt");

            CompositionTarget.Rendering += Loop;

            this.Closing += MainWindow_Closing;

            ipAdressWindow = new IpAdressWindow();
            ipAdressWindow.ShowDialog();
        }

        private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            DataTimeSeries.SaveToCsv("data.txt", oCollection);
            Application.Current.Shutdown();
            Log.Logger.Information("Application closed.");
        }

        private void ListButton_Click(object sender, RoutedEventArgs e)
        {
            DataListWindow listWindow = new DataListWindow(oCollection);
            listWindow.Show();
            Log.Logger.Information("Saved Datalist is showing.");
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            NamingWindow windowName = new NamingWindow(this, oCollection);
            windowName.Show();
            Log.Logger.Information("Naming Data recieved.");
        }

        private void Loop(object sender, EventArgs e)
        {
            tick++;
            if (tick % tickDelay != 0) return;

            UpdateGUI();
        }

        private async void UpdateGUI()
        {
            if (ipAdressWindow.ipAddress == null)
                return;
            sensorData = await ConnectionManager.Main(ipAdressWindow.ipAddress);

            // X
            sensorData.Draw_Acc_X = sensorData.Acc_X;
            desired_X = LerpValue(desired_X, sensorData.Draw_Acc_X, changeFactor);

            X_Rectangle.Margin = new Thickness(0, -desired_X, 0, 0);
            X_Rectangle.Height = Math.Abs(-desired_X);
            AccX.Content = Math.Round(desired_X);

            if (desired_X < 0)
            {
                X_Rectangle.Fill = Brushes.Firebrick;
            }
            else
            {
                X_Rectangle.Fill = Brushes.Red;
            }



            // Y
            sensorData.Draw_Acc_Y = sensorData.Acc_Y;
            desired_Y = LerpValue(desired_Y, sensorData.Draw_Acc_Y, changeFactor);

            Y_Rectangle.Margin = new Thickness(0, -desired_Y, 0, 0);
            Y_Rectangle.Height = Math.Abs(-desired_Y);
            AccY.Content = Math.Round(desired_Y);

            if (desired_Y < 0)
            {
                Y_Rectangle.Fill = Brushes.Green;
            }
            else
            {
                Y_Rectangle.Fill = Brushes.LimeGreen;
            }

            // Z
            sensorData.Draw_Acc_Z = sensorData.Acc_Z;
            desired_Z = LerpValue(desired_Z, sensorData.Draw_Acc_Z, changeFactor);

            Z_Rectangle.Margin = new Thickness(0, -desired_Z, 0, 0);
            Z_Rectangle.Height = Math.Abs(-desired_Z);
            AccZ.Content = Math.Round(desired_Z);

            if (desired_Z < 0)
            {
                Z_Rectangle.Fill = Brushes.MidnightBlue;
            }
            else
            {
                Z_Rectangle.Fill = Brushes.Blue;
            }


            // Temperature
            Temp.Content = sensorData.Temp;
        }


        private double LerpValue(double value, double target, double factor)
        {
            double result = (target - value) * factor + value;
            return result;
        }
    }
}