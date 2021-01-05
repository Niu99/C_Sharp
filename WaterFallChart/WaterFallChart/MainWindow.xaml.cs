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
using System.Windows.Shapes;

namespace WaterFallChart
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Window Ineractive Events

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void BdrHeaderBg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                    DragMove();
            }
        }

        #endregion

        private void BdrChart2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ChartWnd2 wndChart = new ChartWnd2();
            wndChart.Show();
        }

        private void BdrChart1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ChartWnd1 wndChart = new ChartWnd1();
            wndChart.Show();
        }
    }
}
