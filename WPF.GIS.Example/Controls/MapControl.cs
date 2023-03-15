using GMap.NET;
using GMap.NET.WindowsPresentation;
using Ironwall.Framework.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using WPF.GIS.Example.UI.Units;

namespace WPF.GIS.Example.Controls 
{
    public class MapControl : GMapControl
    {

        #region - Ctors -
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            

            CheckBoundZoom(e.Delta);

            base.OnMouseWheel(e);

            if (MouseWheelZoomEnabled 
                && (IsMouseDirectlyOver || IgnoreMarkerOnMouseWheel) 
                && !IsDragging)
            {
                UpdateSymboles(e.Delta);

            }
        }

        private void CheckBoundZoom(int delta)
        {
            try
            {
                if (delta > 0)
                {
                    Debug.WriteLine($"Zoom Up");
                }
                else
                {
                    Debug.WriteLine($"Zoom Down");
                    if (MinZoom == Zoom)
                        return;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        private void UpdateSymboles(int delta)
        {
            
            foreach (var item in Markers.ToList())
            {
                if (!(item.Shape is SymbolTest symbole))
                    continue;

                ///value > 0, 기준 사이즈보다 작다
                ///즉, WholeSize가 커져야 한다.
                int value = (int)(symbole.SymbolZoom - Zoom);
                switch (value)
                {
                    case -2:
                        symbole.WholeSize = symbole.originBody * 3;
                        break;

                    case -1:
                        symbole.WholeSize = symbole.originBody * 2;
                        break;
                    case 0:
                        symbole.WholeSize = symbole.originBody;
                        break;

                    case 1:
                        symbole.WholeSize = symbole.originBody / 2;
                        break;

                    case 2:
                        symbole.WholeSize = symbole.originBody / 3;
                        break;
                    default:
                        break;
                    
                           
                }

                //var clickPoint = FromLatLngToLocal(item.Position);
                //PointLatLng point = FromLocalToLatLng((int)(clickPoint.X - (symbole.WholeSize / 2)), (int)(clickPoint.Y - (symbole.WholeSize / 2)));
                //item.Position = point;

            }
            
        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        #endregion
    }
}
