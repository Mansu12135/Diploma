using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GMap.NET;
using GMap.NET.MapProviders;
using CalculationModule;
using GMap.NET.WindowsPresentation;
using Package;
using System.Windows.Media.Animation;

namespace Demostration
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Module Calculation;
        private Informator InformWindow;
        public MainWindow()
        {
            InitializeComponent();
            InformWindow = new Informator();
            InformWindow.Show();
            Map.MapProvider = GMapProviders.GoogleSatelliteMap;
            Map.DragButton = MouseButton.Left;
            Map.Manager.BoostCacheEngine = true;
            Map.ShowCenter = false;
            Map.Manager.Mode = AccessMode.ServerOnly;
            GMapProvider.WebProxy = null;
            Map.Position = new PointLatLng(48.913119, 38.4667836);
            Map.MinZoom = 1;
            Map.MaxZoom = 20;
            Map.Zoom = 50;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Calculation = new Module();
            Calculation.Researcher.ProcessedData += Researcher_ProcessedData;
        }

        private void Researcher_ProcessedData(Dictionary<string, ResearchFieldResult> processeDictionary)
        {
            Dispatcher.Invoke(() =>
            {
                int id = (int)processeDictionary["DateID"].FieldValue;
                decimal solderID = (decimal) processeDictionary["SolderID"].FieldValue;
                InformWindow.Items.Add(new DataGridCollectionItem{ValueName = "Pulse" , Value = processeDictionary["Pulse"].FieldValue.ToString(), Rezult = processeDictionary["Pulse"].Level.ToString(), DataID = id, SolderID = solderID });
                var position = DbGeography.FromText(processeDictionary["Location"].FieldValue.ToString());
                Map.Markers.Clear();
                Border container = new Border() { BorderBrush = new SolidColorBrush(Colors.Red), BorderThickness = new Thickness(1) };
                container.Child = new Image { Source = new BitmapImage(new Uri("Resources/soldier.png", UriKind.Relative)), Width = 25, Height = 30, RenderSize = new Size(25, 30), Stretch = Stretch.Fill };
                Map.Markers.Add(new GMapMarker(new PointLatLng(position.Latitude.Value, position.Longitude.Value)) { Shape = container });
            });
        }

        private void Blinking()
        {
          //  while (true)
           // {
                Animate();
           // }
        }
        private void Animate()
        {
            DoubleAnimation colorChangeAnimation = new DoubleAnimation();
            colorChangeAnimation.From = 1;
            colorChangeAnimation.To = 0;
            colorChangeAnimation.Duration = new Duration(new TimeSpan(4));
            GradientStop1.BeginAnimation(GradientStop.OffsetProperty, colorChangeAnimation);
            DoubleAnimation colorChangeAnimation1 = new DoubleAnimation();
            colorChangeAnimation1.From = 0;
            colorChangeAnimation1.To = 1;
            colorChangeAnimation1.Duration = new Duration(new TimeSpan(4));
            GradientStop1.BeginAnimation(GradientStop.OffsetProperty, colorChangeAnimation1);

        }

        private void Border2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Blinking();
        }
    }
}
