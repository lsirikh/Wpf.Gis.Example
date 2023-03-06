using GMap.NET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WPF.GIS.Example.UI.Units
{
    
    public class SymbolTest : Control
    {

        private Rectangle innerRect;
        private Border whole;
        private TextBlock title;
        private RotateTransform rotateBody;


        public double BodySize
        {
            get { return (double)GetValue(BodySizeProperty); }
            set { SetValue(BodySizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RectWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BodySizeProperty =
            DependencyProperty.Register("BodySize", typeof(double), typeof(SymbolTest), new PropertyMetadata((double)20), RectWidthCallback);



        public double WholeSize
        {
            get { return (double)GetValue(WholeSizeProperty); }
            set { SetValue(WholeSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WholeSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WholeSizeProperty =
            DependencyProperty.Register("WholeSize", typeof(double), typeof(SymbolTest), new PropertyMetadata((double)60));




        public double WholeAngle
        {
            get { return (double)GetValue(WholeAngleProperty); }
            set { SetValue(WholeAngleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WholeAngle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WholeAngleProperty =
            DependencyProperty.Register("WholeAngle", typeof(double), typeof(SymbolTest), new PropertyMetadata((double)0));


        public string SymbolTitle
        {
            get { return (string)GetValue(SymbolTitleProperty); }
            set { SetValue(SymbolTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SymbolTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SymbolTitleProperty =
            DependencyProperty.Register("SymbolTitle", typeof(string), typeof(SymbolTest), new PropertyMetadata("N/A"));



        public bool IsAnimated
        {
            get { return (bool)GetValue(IsAnimatedProperty); }
            set { SetValue(IsAnimatedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsAnimated.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsAnimatedProperty =
            DependencyProperty.Register("IsAnimated", typeof(bool), typeof(SymbolTest), new PropertyMetadata(false));




        private static bool RectWidthCallback(object value)
        {
            var width = (double)value;
            Debug.WriteLine($"RectWidthCallback : {width}");
            return width > 0;
        }

        public PointLatLng Center;
        public PointLatLng Bound;


        //public PointLatLng Center   
        //{
        //    get { return (PointLatLng)GetValue(CenterProperty); }
        //    set { SetValue(CenterProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty CenterProperty =
        //    DependencyProperty.Register("MyProperty", typeof(PointLatLng), typeof(SymbolTest), new PropertyMetadata(0));





        static SymbolTest()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SymbolTest), new FrameworkPropertyMetadata(typeof(SymbolTest)));
        }

        public override void OnApplyTemplate()
        {
            whole = Template.FindName("PART_whole", this) as Border;
            innerRect = Template.FindName("PART_body", this) as Rectangle;
            rotateBody = Template.FindName("PART_rotateBody", this) as RotateTransform;
            title = Template.FindName("PART_title", this) as TextBlock;

            Binding sizeRectBinding = new Binding
            {
                Path = new PropertyPath(nameof(BodySize)),
                Source = this,
            };

            Binding sizeWholeBinding = new Binding
            {
                Path = new PropertyPath(nameof(WholeSize)),
                Source = this,
            };

            Binding angleWholeBinding = new Binding
            {
                Path = new PropertyPath(nameof(WholeAngle)),
                Source = this,
            };

            Binding isAnimatedWholeBinding = new Binding
            {
                Path = new PropertyPath(nameof(IsAnimated)),
                Source = this,
            };

            Binding titleBinding = new Binding
            {
                Path = new PropertyPath(nameof(SymbolTitle)),
                Source = this,
            };

            

            innerRect.SetBinding(WidthProperty, sizeRectBinding);
            innerRect.SetBinding(HeightProperty, sizeRectBinding);

            whole.SetBinding(WidthProperty, sizeWholeBinding);
            whole.SetBinding(HeightProperty, sizeWholeBinding);
            whole.SetBinding(WholeAngleProperty, angleWholeBinding);
            whole.SetBinding(IsAnimatedProperty, isAnimatedWholeBinding);

            //rotateBody.SetBinding(AngleProperty, angleWholeBinding);
            title.SetBinding(TextBlock.TextProperty, titleBinding);

            base.OnApplyTemplate();
        }
    }
}
