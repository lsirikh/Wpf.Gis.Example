using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPF.GIS.Example.UI.Views;

namespace WPF.GIS.Example.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region - Ctors -
        public MainWindowViewModel()
        {
            //GoogleMapProvider.Instance.ApiKey = "AIzaSyCXJrDpszuNQfMEXKIifx5zYzhSq3Irpyg";
            //_gMapControl = new MapBase();
            ////MapProvider = GMapProviders.GoogleHybridMap;
            ////Position = new PointLatLng(37.648425, 126.904284);
            ////GMapProviders mapProvider = new GMapProviders();
            //_gMapControl.MapProvider = GMapProviders.GoogleHybridMap;
            //_gMapControl.Position = new PointLatLng(37.648425, 126.904284);
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
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


        protected void SetProperty<T>(ref T oldValue, ref T newValue,
        [CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                oldValue = newValue;
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        #region - Attributes -
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
