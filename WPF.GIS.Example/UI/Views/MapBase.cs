using GMap.NET.MapProviders;
using GMap.NET;
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
using WPF.GIS.Example.Controls;

namespace WPF.GIS.Example.UI.Views
{
    
    public class MapBase : GMapControl
    {
        #region - Ctors -
        static MapBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MapBase), new FrameworkPropertyMetadata(typeof(MapBase)));
        }

        public MapBase()
        {
            GoogleMapProvider.Instance.ApiKey = "AIzaSyCXJrDpszuNQfMEXKIifx5zYzhSq3Irpyg";

            // config map
            MapProvider = GMapProviders.GoogleHybridMap;
            Position = new PointLatLng(37.648425, 126.904284);
            MinZoom = 2;
            MaxZoom = 17;
            Zoom = 13;
            ShowCenter = false;
            DragButton = MouseButton.Left;

            OnPositionChanged += MainMap_OnCurrentPositionChanged;
            OnTileLoadComplete += MainMap_OnTileLoadComplete;
            OnTileLoadStart += MainMap_OnTileLoadStart;
            OnMapTypeChanged += MainMap_OnMapTypeChanged;
            MouseMove += MainMap_MouseMove;
            MouseLeftButtonDown += MainMap_MouseLeftButtonDown;
            MouseEnter += MainMap_MouseEnter;
            
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        public override void OnApplyTemplate()
        {
            //coordinateLatLon = Template.FindName("PART_coordinateLatLon", this) as TextBlock;
            gMapControl = Template.FindName("PART_mainMap", this) as GMapControl;
            gMapControl.DataContext = this;

            //Binding coordinateLatLonBinding = new Binding
            //{
            //    Path = new PropertyPath(nameof(CoordinateLatLon)),
            //    Source = this,
            //};

            //coordinateLatLon.SetBinding(TextBlock.TextProperty, coordinateLatLonBinding);
        }
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        private void MainMap_OnCurrentPositionChanged(PointLatLng point)
        {
        }

        private void MainMap_OnTileLoadComplete(long elapsedMilliseconds)
        {
        }

        private void MainMap_OnTileLoadStart()
        {
        }

        private void MainMap_OnMapTypeChanged(GMapProvider type)
        {
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void MainMap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void MainMap_MouseEnter(object sender, MouseEventArgs e)
        {
        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -


        public string CoordinateLatLon
        {
            get { return (string)GetValue(CoordinateLatLonProperty); }
            set { SetValue(CoordinateLatLonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CoordinateLatLon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CoordinateLatLonProperty =
            DependencyProperty.Register("CoordinateLatLon", typeof(string), typeof(MapBase), new PropertyMetadata(""));


        #endregion
        #region - Attributes -
        private TextBlock coordinateLatLon;
        private GMapControl gMapControl;


        PointLatLng start;
        PointLatLng end;

        // marker
        GMapMarker currentMarker;

        // zones list
        List<GMapMarker> Circles = new List<GMapMarker>();
        #endregion




    }
}
