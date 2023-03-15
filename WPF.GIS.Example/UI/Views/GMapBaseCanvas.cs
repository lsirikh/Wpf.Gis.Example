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
    
    public class GMapBaseCanvas : Canvas
    {
        #region - Ctors -
        static GMapBaseCanvas()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GMapBaseCanvas), new FrameworkPropertyMetadata(typeof(GMapBaseCanvas)));
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

        #endregion
        #region - Attributes -
        
        #endregion




    }
}
