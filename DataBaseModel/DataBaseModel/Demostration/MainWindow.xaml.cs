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
            Map.MapProvider = GoogleMapProvider.Instance;
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
                Map.Markers.Add(new GMapMarker(new PointLatLng(position.Latitude.Value, position.Longitude.Value)) { Shape = new Image { Source = new BitmapImage(new Uri("Resources/fril(1).jpg", UriKind.Relative)), Width = 25, Height = 25, RenderSize = new Size(25, 25), Stretch = Stretch.Fill } });
            });
        }
    }
}
