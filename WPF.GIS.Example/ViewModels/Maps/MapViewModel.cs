using Caliburn.Micro;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using Ironwall.Framework.ViewModels.ConductorViewModels;
using Ironwall.Libraries.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using WPF.GIS.Example.Controls;
using WPF.GIS.Example.CustomMarkers;
using WPF.GIS.Example.Enums;
using WPF.GIS.Example.Models;
using WPF.GIS.Example.UI.Units;
using WPF.GIS.Example.UI.Views;
using WPF.GIS.Example.Views.Maps;

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

            /* Scale
             * Zoom : 17, Scale : 50m, Length : 1.5 cm
             * Zoom : 16, Scale : 100m, Length : 1.5 cm
             * Zoom : 15, Scale : 300m, Length : 2.5 cm
             * Zoom : 14, Scale : 500m, Length : 2 cm 
             * Zoom : 13, Scale : 1000m, Length : 2 cm
             * 
             * Zoom : 12, Scale : 3000m, Length : 2.2 cm
             * Zoom : 11, Scale : 5000m, Length : 2.2 cm
             * Zoom : 10, Scale : 10Km, Length : 2.2 cm
             
             */

            MainMap = new MapControl();
        }
        #endregion
        #region - Implementation of Interface -

        #endregion
        #region - Overrides -
        protected override async  Task OnActivateAsync(CancellationToken cancellationToken)
        {
            
            GoogleMapProvider.Instance.ApiKey = "AIzaSyCXJrDpszuNQfMEXKIifx5zYzhSq3Irpyg";

            //Get Locally Saved gmdb file
           

            //MainMap.Manager.Mode = AccessMode.CacheOnly;
            MainMap.Manager.Mode = AccessMode.ServerOnly;

            // config map
            MapConfigure();
            
            if(MainMap.Manager.Mode == AccessMode.CacheOnly)
                await GetMapData(MainMap);


                



            currentMarker = new GMapMarker(MainMap.Position);
            {
                currentMarker.Shape = new CustomMarkerRed(MainMap, currentMarker, "custom position marker");
                currentMarker.Offset = new Point(-15, -15);
                currentMarker.ZIndex = int.MaxValue;
                MainMap.Markers.Add(currentMarker);
            }
           


            //if(false)
            //{
            //    // add my city location for demo
            //    GeoCoderStatusCode status;

            //    var city = GMapProviders.GoogleMap.GetPoint("Lithuania, Vilnius", out status);
            //    if (city != null && status == GeoCoderStatusCode.OK)
            //    {
            //        var it = new GMapMarker(city.Value);
            //        {
            //            it.ZIndex = 55;
            //            it.Shape = new CustomMarkerDemo(this, it, "Welcome to Lithuania! ;}");
            //        }
            //        MainMap.Markers.Add(it);

            //        #region -- add some markers and zone around them --

            //        //if(false)
            //        {
            //            var objects = new List<PointAndInfo>();
            //            {
            //                string area = "Antakalnis";
            //                var pos = GMapProviders.GoogleMap.GetPoint("Lithuania, Vilnius, " + area, out status);
            //                if (pos != null && status == GeoCoderStatusCode.OK)
            //                {
            //                    objects.Add(new PointAndInfo(pos.Value, area));
            //                }
            //            }
            //            {
            //                string area = "Senamiestis";
            //                var pos = GMapProviders.GoogleMap.GetPoint("Lithuania, Vilnius, " + area, out status);
            //                if (pos != null && status == GeoCoderStatusCode.OK)
            //                {
            //                    objects.Add(new PointAndInfo(pos.Value, area));
            //                }
            //            }
            //            {
            //                string area = "Pilaite";
            //                var pos = GMapProviders.GoogleMap.GetPoint("Lithuania, Vilnius, " + area, out status);
            //                if (pos != null && status == GeoCoderStatusCode.OK)
            //                {
            //                    objects.Add(new PointAndInfo(pos.Value, area));
            //                }
            //            }
            //            AddDemoZone(8.8, city.Value, objects);
            //        }

            //        #endregion
            //    }
            await base.OnActivateAsync(cancellationToken);
        }

        public void MapConfigure()
        {
            try
            {
                MainMap.MapProvider = GMapProviders.GoogleHybridMap;
                MainMap.Position = new PointLatLng(37.648425, 126.904284);
                MainMap.MinZoom = ZOOM_MIN;
                MainMap.MaxZoom = ZOOM_MAX;
                MainMap.Zoom = ZOOM_CURRENT;

                ZoomMax = ZOOM_MAX;
                ZoomMin = ZOOM_MIN;

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
                MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;

                MainMap.ShowCenter = true;
                MainMap_OnMapZoomChanged();

                _homePosition = new HomePositionModel();

                Symbols = new ObservableCollection<SymbolTest>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> GetMapData(GMapControl mainMap)
        {
            return Task.Run(() =>
            {

                try
                {

                    Thread.Sleep(5000);
                    DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
                    var dirs = di.GetDirectories();
                    foreach (var folder in dirs)
                    {
                        var folderName = "gmdb";
                        if (folder.Name.ToLower() == folderName)
                        {
                            Debug.WriteLine($"Find the folder({folderName}) successfully!");
                            var fileName = "Map.gmdb";
                            var file = folder.GetFiles().Where(t => t.Name == fileName).FirstOrDefault();
                            bool ret = false;
                            if(file != null)
                            {
                                Debug.WriteLine($"Find the file({fileName}) successfully!");
                                ret = GMaps.Instance.ImportFromGMDB(file.FullName);
                            }

                            if (ret)
                            {
                                Debug.WriteLine($"Reload Map from cashed data : {file.Name}");
                                MainMap.ReloadMap();
                            }
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Rasied Exception in {nameof(GetMapData)} :  {ex.Message}");
                    return false;
                }
            });
        }

        //protected override void OnViewAttached(object view, object context)
        //{
        //    UserControl map =(view as MapView).FindName("MainMap") as UserControl;

        //    base.OnViewAttached(view, context);
        //}


        #endregion
        #region - Binding Methods -
        public void OnClickZoomUp(object sender, EventArgs args)
        {
            Zoom = (int)MainMap.Zoom + 1;
        }
        public void OnClickZoomDown(object sender, EventArgs args)
        {
            Zoom = (int)(MainMap.Zoom + 0.99) - 1;
        }
        #endregion
        #region - Processes -
        private void MainMap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Released)
            {
                Point clickPoint = e.GetPosition(MainMap);
                Random random = new Random();
                var angle = random.NextDouble() * 360;
                var num = random.Next(1, 100);
                var title = $"{num}부대";
                var isAnimated = random.NextDouble() * 10 > 5 ? true : false;
                var symbole = new SymbolTest(angle, title, MainMap.Zoom, isAnimated);
                Symbols.Add(symbole);
                PointLatLng point = MainMap.FromLocalToLatLng((int)(clickPoint.X - (symbole.WholeSize / 2)), (int)(clickPoint.Y - (symbole.WholeSize / 2)));
                symbole.Center = point;
                
                GMapMarker marker = new GMapMarker(point);
                marker.Shape = symbole;

                MainMap.Markers.Add(marker);
            }
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
            var p = e.GetPosition(MainMap);
            
            CurrentPosition = MainMap.FromLocalToLatLng((int)p.X, (int)p.Y);
        }

        private void MainMap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var p = e.GetPosition(MainMap);
            currentMarker.Position = MainMap.FromLocalToLatLng((int)p.X, (int)p.Y);
            //MainMap.Bearing
            // Keyboard.Modifiers == ModifierKeys.Shift
            //if(MainMap.IsDragging &&
            //    (Keyboard.Modifiers == ModifierKeys.Shift))
            //{
            //    MainMap.Bearing = 10.1f;
            //}
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
        public void OnClickCountClockWise(object sender, EventArgs e)
        {
            float angle = 10;
            UpdateAngle(angle);
            
        }

        public void OnClickClockWise(object sender, EventArgs e)
        {
            float angle = -10;
            UpdateAngle(angle);
        }

        private void UpdateAngle(float angle)
        {
            try
            {
                MainMap.Bearing += angle;

                foreach (var item in MainMap.Markers)
                {
                    if (item.Shape is SymbolTest symbol)
                        symbol.WholeAngle += (-angle);
                }
            }
            catch (Exception)
            {

                throw;
            }
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

        private void MainMap_OnMapZoomChanged()
        {
            Debug.WriteLine($"Zoom : {MainMap.Zoom}");
            //UpdateSymbol();
            Zoom = MainMap.Zoom;

            var area = MainMap.ViewArea;
            Debug.WriteLine($"Area : { area}");

            double scaleX = 0.0;
            var scale = "";
            
            

            switch (Zoom)
            {
                case 10:
                    scaleX = 83.1;
                    scale = "10Km";
                    break;
                case 11:
                    scaleX = 83.1;
                    scale = "5Km";
                    break;
                case 12:
                    scaleX = 83.1;
                    scale = "3Km";
                    break;
                case 13:
                    scaleX = 75.59;
                    scale = "1Km";
                    break;
                case 14:
                    scaleX = 75.59;
                    scale = "500m";
                    break;
                case 15:
                    scaleX = 94.5;
                    scale = "300m";
                    break;
                case 16:
                    scaleX = 56.7;
                    scale = "100m";
                    break;
                case 17:
                    scaleX = 56.7;
                    scale = "50m";
                    break;
                case 18:
                    scaleX = 56.7;
                    scale = "30m";
                    break;

                default:
                    break;
            }

            Scale = scale;
            ScalePoints = new PointCollection()
            {
                new Point(0.0, 0.0),
                new Point(0.0, 5.0),
                new Point(scaleX, 5.0),
                new Point(scaleX, 0.0),

            };
            NotifyOfPropertyChange(() => ScalePoints);
        }

        public void SetBoundary()
        {
            MainMap.BoundsOfMap = MainMap.ViewArea;
            MainMap.MinZoom = (int)(MainMap.Zoom + 0.99);
            ZoomMin = MainMap.MinZoom;
        }
        public void ClearBoundary()
        {
            MainMap.BoundsOfMap = null;
            MainMap.MinZoom = ZOOM_MIN;
            ZoomMin = MainMap.MinZoom;
            MainMap.InvalidateVisual(true);
        }

        public void SetHomePosition()
        {
            if (HomePosition.IsAvailable)
                return;

            HomePosition.Position = MainMap.Position;
            HomePosition.Zoom = Zoom;
            HomePosition.IsAvailable = true;
        }

        public void ClearHomePosition()
        {
            HomePosition.Position = new PointLatLng(); ;
            HomePosition.Zoom = 0.0;
            HomePosition.IsAvailable = false;
        }

        public void GoToHomePosition()
        {
            MainMap.Position = HomePosition.Position;
            MainMap.Zoom = HomePosition.Zoom;
        }
        public void AddTank()
        {
            MarkerMode = MarkerIconEnum.TANK;

        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        public MapControl MainMap { get; set; }

        public double Zoom
        {
            get { return MainMap.Zoom; }
            set
            {
                MainMap.Zoom = value;
                NotifyOfPropertyChange(nameof(Zoom));
            }
        }


        public double ZoomMax
        {
            get { return _zoomMax; }
            set 
            { 
                _zoomMax = value;
                NotifyOfPropertyChange(nameof(ZoomMax));
            }
        }

        public double ZoomMin
        {
            get { return _zoomMin; }
            set 
            { 
                _zoomMin = value;
                NotifyOfPropertyChange(nameof(ZoomMin));
            }
        }

        public ObservableCollection<SymbolTest> Symbols { get; set; }

        public PointLatLng CurrentPosition
        {
            get { return _currentPosition; }
            set 
            { 
                _currentPosition = value;
                NotifyOfPropertyChange(nameof(CurrentPosition));
            }
        }


        public HomePositionModel HomePosition
        {
            get { return _homePosition; }
            set 
            { 
                _homePosition = value;
                NotifyOfPropertyChange(nameof(HomePosition));
            }
        }

        private string _scale;

        public string Scale
        {
            get { return _scale; }
            set 
            { 
                _scale = value;
                NotifyOfPropertyChange(nameof(Scale));
            }
        }


        public PointCollection ScalePoints { get; set; }


        public MarkerIconEnum MarkerMode { get; set; }
        #endregion
        #region - Attributes -
        private double _zoomMax;
        private double _zoomMin;

        private HomePositionModel _homePosition;
        private PointLatLng _currentPosition;

        private PointLatLng start;
        private PointLatLng end;

        // marker
        GMapMarker currentMarker;

        // zones list
        List<GMapMarker> Circles = new List<GMapMarker>();
        public const int ZOOM_MAX = 20;
        public const int ZOOM_MIN = 10;
        public const double ZOOM_CURRENT = 16;
        #endregion
    }
}
