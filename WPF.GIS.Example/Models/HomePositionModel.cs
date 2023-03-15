using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.GIS.Example.Models
{
    public class HomePositionModel
    {
        #region - Ctors -
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        public override string ToString()
        {
            return $"Latitude : {Position.Lat}, Longitude : {Position.Lng}";
        }
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        public PointLatLng Position { get; set; }
        public double Zoom { get; set; }
        public bool IsAvailable { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
