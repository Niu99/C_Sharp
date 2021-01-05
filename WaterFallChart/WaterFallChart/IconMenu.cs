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

namespace WaterFallChart
{
    public class IconMenu : Control
    {
        public string IconData
        {
            get { return (string)base.GetValue(IconDataProperty); }
            set { base.SetValue(IconDataProperty, value); }
        }
        public static readonly DependencyProperty IconDataProperty =
            DependencyProperty.Register("IconData", typeof(string), typeof(IconMenu),
                new FrameworkPropertyMetadata(""));

        public double IconSize
        {
            get { return (double)base.GetValue(IconSizeProperty); }
            set { base.SetValue(IconSizeProperty, value); }
        }
        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register("IconSize", typeof(double), typeof(IconMenu),
                new FrameworkPropertyMetadata(13d));

        public Brush IconBrush
        {
            get { return (Brush)base.GetValue(IconBrushProperty); }
            set { base.SetValue(IconBrushProperty, value); }
        }
        public static readonly DependencyProperty IconBrushProperty =
            DependencyProperty.Register("IconBrush", typeof(Brush), typeof(IconMenu),
                new FrameworkPropertyMetadata(Brushes.Black));

        public Brush FocusBrush
        {
            get { return (Brush)base.GetValue(FocusBrushProperty); }
            set { base.SetValue(FocusBrushProperty, value); }
        }
        public static readonly DependencyProperty FocusBrushProperty =
            DependencyProperty.Register("FocusBrush", typeof(Brush), typeof(IconMenu),
                new FrameworkPropertyMetadata(Brushes.Black));

        static IconMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconMenu),
                new FrameworkPropertyMetadata(typeof(IconMenu)));
        }
    }
}
