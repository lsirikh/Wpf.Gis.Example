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
            mapControl.MapProvider = GMapProviders.GoogleHybridMap;
            mapControl.Position = new PointLatLng(37.648425, 126.904284);
            mapControl.MinZoom = 2;
            mapControl.MaxZoom = 17;
            mapControl.Zoom = 13;
            mapControl.ShowCenter = false;
            mapControl.DragButton = MouseButton.Left;
            mapControl.Position = new PointLatLng(35.696874, 128.457701);

            mapControl.MouseLeftButtonDown += new MouseButtonEventHandler(mapControl_MouseLeftButtonDown);
        }
        ~MainWindow()
        {
            mapControl.Dispose();
        }

        void mapControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point clickPoint = e.GetPosition(mapControl);
            Random random = new Random();
            var angle = random.NextDouble()* 360;
            var num = random.Next(1, 100);
            var title = $"{num}부대";
            var isAnimated = random.NextDouble() * 10 > 5 ? true : false;
            var symbole = new SymbolTest() { WholeAngle = angle, SymbolTitle = title, IsAnimated = isAnimated};
            PointLatLng point = mapControl.FromLocalToLatLng((int)(clickPoint.X - (symbole.WholeSize / 2)), (int)(clickPoint.Y - (symbole.WholeSize / 2)));
            GMapMarker marker = new GMapMarker(point);
            //marker.Shape = new Ellipse
            //{
            //    Width = 10,
            //    Height = 10,
            //    Stroke = Brushes.Black,
            //    StrokeThickness = 1.5
            //};
            marker.Shape = symbole;

            mapControl.Markers.Add(marker);
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
            mapControl.Zoom = (int)mapControl.Zoom + 1;
        }

        // zoom down
        private void czuZoomDown_Click(object sender, RoutedEventArgs e)
        {
            mapControl.Zoom = (int)(mapControl.Zoom + 0.99) - 1;
        }

        // calculates circle radius
        void UpdateCircle(Circle c)
        {
            var pxCenter = mapControl.FromLatLngToLocal(c.Center);
            var pxBounds = mapControl.FromLatLngToLocal(c.Bound);

            double a = pxBounds.X - pxCenter.X;
            double b = pxBounds.Y - pxCenter.Y;
            double pxCircleRadius = Math.Sqrt(a * a + b * b);

            c.Width = 55 + pxCircleRadius * 2;
            c.Height = 55 + pxCircleRadius * 2;
            (c.Tag as GMapMarker).Offset = new Point(-c.Width / 2, -c.Height / 2);
        }
    }
}
