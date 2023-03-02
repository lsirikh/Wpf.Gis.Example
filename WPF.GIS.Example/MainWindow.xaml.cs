using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.GIS.Example.CustomMarkers;
using WPF.GIS.Example.UI.Units;

namespace WPF.GIS.Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PointLatLng start;
        PointLatLng end;

        // marker
        GMapMarker currentMarker;

        // zones list
        List<GMapMarker> Circles = new List<GMapMarker>();


        public MainWindow()
        {
            InitializeComponent();

            GoogleMapProvider.Instance.ApiKey = "AIzaSyCXJrDpszuNQfMEXKIifx5zYzhSq3Irpyg";

            // config map
            MainMap.MapProvider = GMapProviders.GoogleHybridMap;
            MainMap.Position = new PointLatLng(37.648425, 126.904284);
            MainMap.MinZoom = 1;
            MainMap.MaxZoom = 17;
            MainMap.Zoom = 11;
            MainMap.ShowCenter = false;
            MainMap.DragButton = MouseButton.Left;


            //MainMap.TouchEnabled = false;
            MainMap.MultiTouchEnabled = true;
            MainMap.MouseLeftButtonDown += new MouseButtonEventHandler(mapControl_MouseLeftButtonDown);


            MainMap.OnPositionChanged += MainMap_OnCurrentPositionChanged;
            MainMap.OnTileLoadComplete += MainMap_OnTileLoadComplete;
            MainMap.OnTileLoadStart += MainMap_OnTileLoadStart;
            MainMap.OnMapTypeChanged += MainMap_OnMapTypeChanged;
            MainMap.MouseMove += MainMap_MouseMove;
            MainMap.MouseLeftButtonDown += MainMap_MouseLeftButtonDown;
            MainMap.MouseEnter += MainMap_MouseEnter;
        }

        private void MainMap_OnCurrentPositionChanged(PointLatLng point)
        {
            throw new NotImplementedException();
        }

        private void MainMap_OnTileLoadComplete(long elapsedMilliseconds)
        {
            throw new NotImplementedException();
        }

        private void MainMap_OnTileLoadStart()
        {
            throw new NotImplementedException();
        }

        private void MainMap_OnMapTypeChanged(GMapProvider type)
        {
            throw new NotImplementedException();
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MainMap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MainMap_MouseEnter(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        ~MainWindow()
        {
            
        }

        void mapControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point clickPoint = e.GetPosition(MainMap);
            Random random = new Random();
            var angle = random.NextDouble() * 360;
            var num = random.Next(1, 100);
            var title = $"{num}부대";
            var isAnimated = random.NextDouble() * 10 > 5 ? true : false;
            var symbole = new SymbolTest() { WholeAngle = angle, SymbolTitle = title, IsAnimated = isAnimated };
            PointLatLng point = MainMap.FromLocalToLatLng((int)(clickPoint.X - (symbole.WholeSize / 2)), (int)(clickPoint.Y - (symbole.WholeSize / 2)));
            GMapMarker marker = new GMapMarker(point);
            
            marker.Shape = symbole;

            MainMap.Markers.Add(marker);
        }

        // zoom changed
        private void sliderZoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // updates circles on map
            foreach (var c in Circles)
            {
                UpdateCircle(c.Shape as Circle);
            }
        }

        // zoom up
        private void czuZoomUp_Click(object sender, RoutedEventArgs e)
        {
            MainMap.Zoom = (int)MainMap.Zoom + 1;
        }

        // zoom down
        private void czuZoomDown_Click(object sender, RoutedEventArgs e)
        {
            MainMap.Zoom = (int)(MainMap.Zoom + 0.99) - 1;
        }

        // calculates circle radius
        void UpdateCircle(Circle c)
        {
            var pxCenter = MainMap.FromLatLngToLocal(c.Center);
            var pxBounds = MainMap.FromLatLngToLocal(c.Bound);

            double a = pxBounds.X - pxCenter.X;
            double b = pxBounds.Y - pxCenter.Y;
            double pxCircleRadius = Math.Sqrt(a * a + b * b);

            c.Width = 55 + pxCircleRadius * 2;
            c.Height = 55 + pxCircleRadius * 2;
            (c.Tag as GMapMarker).Offset = new Point(-c.Width / 2, -c.Height / 2);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainMap.Dispose();
        }
    }
}
