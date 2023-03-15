using Caliburn.Micro;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.GIS.Example.Views.Maps;

namespace WPF.GIS.Example.CustomMarkers
{
    /// <summary>
    /// Interaction logic for CustomMarkerRed.xaml
    /// </summary>
    public partial class CustomMarkerRed
    {
        public CustomMarkerRed(GMapControl control, GMapMarker marker, string title)
        {
            InitializeComponent();

            Marker = marker;
            GMapControl = control;

            Popup = new Popup();
            Label = new Label();

            Loaded += CustomMarkerRed_Loaded;
            SizeChanged += CustomMarkerRed_SizeChanged;
            MouseMove += CustomMarkerRed_MouseMove;
            MouseEnter += CustomMarkerRed_MouseEnter;
            MouseLeave += CustomMarkerRed_MouseLeave;
            MouseLeftButtonUp += CustomMarkerRed_MouseLeftButtonUp;
            MouseLeftButtonDown += CustomMarkerRed_MouseLeftButtonDown;


            Popup.Placement = PlacementMode.Mouse;
            {
                Label.Background = Brushes.DarkGray;
                Label.Foreground = Brushes.White;
                Label.BorderBrush = Brushes.Black;
                Label.BorderThickness = new Thickness(2);
                Label.Padding = new Thickness(5);
                Label.FontSize = 22;
                Label.Content = title;
            }
            Popup.Child = Label;
        }

        private void CustomMarkerRed_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && IsMouseCaptured)
            {
                var p = e.GetPosition(GMapControl);
                Marker.Position = GMapControl.FromLocalToLatLng((int)p.X, (int)p.Y);
            }
        }

        private void CustomMarkerRed_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsMouseCaptured)
            {
                Mouse.Capture(this);
            }
        }

        private void CustomMarkerRed_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (IsMouseCaptured)
            {
                Mouse.Capture(null);
            }
        }

        private void CustomMarkerRed_MouseLeave(object sender, MouseEventArgs e)
        {
            Marker.ZIndex -= 10000;
            Popup.IsOpen = false;
        }

        private void CustomMarkerRed_MouseEnter(object sender, MouseEventArgs e)
        {
            Marker.ZIndex += 10000;
            Popup.IsOpen = true;
        }

        private void CustomMarkerRed_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Marker.Offset = new Point(-e.NewSize.Width / 2, -e.NewSize.Height);
        }

        private void CustomMarkerRed_Loaded(object sender, RoutedEventArgs e)
        {
            if (Icon.Source.CanFreeze)
            {
                Icon.Source.Freeze();
            }
        }

        GMapMarker Marker;
        GMapControl GMapControl;


        Popup Popup;
        Label Label;
    }
}
