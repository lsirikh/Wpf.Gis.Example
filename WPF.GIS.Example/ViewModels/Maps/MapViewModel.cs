using Caliburn.Micro;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using Ironwall.Framework.ViewModels.ConductorViewModels;
using Ironwall.Libraries.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.GIS.Example.CustomMarkers;
using WPF.GIS.Example.UI.Views;

namespace WPF.GIS.Example.ViewModels.Maps
{
    public class MapViewModel : BaseViewModel
        //, INotifyPropertyChanged
    {
        #region - Ctors -
        public MapViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            //GoogleMapProvider.Instance.ApiKey = "AIzaSyCXJrDpszuNQfMEXKIifx5zYzhSq3Irpyg";
            //_gMapControl = new MapBase();
            ////MapProvider = GMapProviders.GoogleHybridMap;
            ////Position = new PointLatLng(37.648425, 126.904284);
            ////GMapProviders mapProvider = new GMapProviders();
            //_gMapControl.MapProvider = GMapProviders.GoogleHybridMap;
            //_gMapControl.Position = new PointLatLng(37.648425, 126.904284);

            #region - Settings -
            ClassId = 1;
            ClassContent = "";
            ClassCategory = CategoryEnum.PANEL_SHELL_VM_ITEM;
            #endregion - Settings -

            MainMap = new GMapControl();
        }
        #endregion
        #region - Implementation of Interface -

        #endregion
        #region - Overrides -
        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
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
            MainMap.MouseDoubleClick += new MouseButtonEventHandler(MainMap_MouseDoubleClick);


            MainMap.OnPositionChanged += MainMap_OnCurrentPositionChanged;
            MainMap.OnTileLoadComplete += MainMap_OnTileLoadComplete;
            MainMap.OnTileLoadStart += MainMap_OnTileLoadStart;
            MainMap.OnMapTypeChanged += MainMap_OnMapTypeChanged;
            MainMap.MouseMove += MainMap_MouseMove;
            MainMap.MouseLeftButtonDown += MainMap_MouseLeftButtonDown;
            MainMap.MouseEnter += MainMap_MouseEnter;

            return base.OnActivateAsync(cancellationToken);
        }
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        private void MainMap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
                return;
        }

        private void MainMap_OnCurrentPositionChanged(PointLatLng point)
        {
            //throw new NotImplementedException();
        }

        private void MainMap_OnTileLoadComplete(long elapsedMilliseconds)
        {
            //throw new NotImplementedException();
        }

        private void MainMap_OnTileLoadStart()
        {
            //throw new NotImplementedException();
        }

        private void MainMap_OnMapTypeChanged(GMapProvider type)
        {
            //throw new NotImplementedException();
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void MainMap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void MainMap_MouseEnter(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
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
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        //private MapBase _gMapControl;

        //public MapBase GMapControl
        //{
        //    get => _gMapControl;
        //    set => SetProperty(ref _gMapControl, ref value);
        //}


        public GMapControl MainMap { get; set; }

        PointLatLng start;
        PointLatLng end;

        // marker
        GMapMarker currentMarker;

        // zones list
        List<GMapMarker> Circles = new List<GMapMarker>();


        //protected void SetProperty<T>(ref T oldValue, ref T newValue,
        //[CallerMemberName] string propertyName = null)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        oldValue = newValue;
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
        #endregion
        #region - Attributes -
        //public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
