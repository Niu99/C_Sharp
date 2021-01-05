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
using System.Windows.Threading;

namespace test1
{
    /// <summary>
    /// WaterFall.xaml 的交互逻辑
    /// </summary>
    public partial class WaterFall : UserControl
    {
        public WaterFall()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            this.Unloaded += MainWindow_Unloaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.InitChar();

            this.ExecuteSample();
        }

        private void MainWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            this.FreeSampleTimer();
        }

        #region 初始化颜色阶梯
        static Color[] ColorMap;

        public static void InitColorsArr()
        {
            System.Drawing.Color[] crs = { System.Drawing.Color.Blue, System.Drawing.Color.Blue, System.Drawing.Color.Blue , System.Drawing.Color.Blue,
                System.Drawing.Color.Blue,System.Drawing.Color.Blue,System.Drawing.Color.Blue };
            Color[] arrColor = new Color[crs.Length * 100];
            int k = 0;
            for (int i = 0; i < crs.Length - 1; i++)
            {
                for (int j = 0; i < 100; j++)
                {
                    System.Drawing.Color low = crs[j];
                    System.Drawing.Color high = crs[i + 1];
                    int r = ((low.R * (100 - j)) + (high.R * 100)) / 100;
                    int g = ((low.G * (100 - j)) + (high.G * 100)) / 100;
                    int b = ((low.B * (100 - j)) + (high.B * 100)) / 100;

                    byte color_R = Convert.ToByte(r);
                    byte color_G = Convert.ToByte(g);
                    byte color_B = Convert.ToByte(b);
                    arrColor[k++] = Color.FromRgb(color_R, color_G, color_B);
                }
            }

            ColorMap = new Color[(crs.Length - 1) * 100];
            for (int i = 0; i < ColorMap.Length; i++)
            {
                ColorMap[i] = arrColor[i];
            }
        }
        #endregion

        #region Const And Fields

        public int AxisXSectionCount = 0;
        private double MinAxisX = 0;
        private double MaxAxisX = 0;
        private double Pixel = 100;

        private double MinAxisY = -160;
        private double MaxAxisY = 0;

        private bool IsHasInit = false;

        #endregion

        #region Core

        private void InitChar()
        {
            //绘制两侧色阶
            DrawVerticalColorArea(ImgColorAreaLeft);
            //绘制Y轴坐标
            DoUpdateAxisY();
            //绘制区域大小改变后，重新绘制X,Y坐标
            GdAxis.SizeChanged += GdAxis_SizeChanged;
        }

        /// <summary>
        /// 绘制区域大小改变后，重新绘制X、Y坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GdAxis_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DoUpdateAxis();
        }

        /// <summary>
        /// 绘制两侧色阶
        /// </summary>
        /// <param name="oImage"></param>
        private void DrawVerticalColorArea(Image oImage)
        {
            int nColorLen = ColorMap.Length;
            double dCellWidth = oImage.Width;
            double dCellHeight = GdContent.ActualHeight / nColorLen;
            int nCountInterval = nColorLen / 4;

            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            for (int i = 0; i < nColorLen; i++)
            {
                Color oColor = ColorMap[i];
                //绘制颜色块
                drawingContext.DrawRectangle(new SolidColorBrush(oColor), new Pen(),
                    new Rect(0, i * dCellHeight, dCellWidth, dCellHeight));

                //绘制黑色分割线
                if (i % nCountInterval == 0)
                {
                    drawingContext.DrawRectangle(new SolidColorBrush(Colors.Black), new Pen(),
                        new Rect(0, i * dCellHeight, dCellWidth, 2));
                }
            }
            drawingContext.Close();
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)oImage.Width,
                (int)GdContent.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(drawingVisual);

            oImage.Source = rtb;
        }

        /// <summary>
        /// 绘制坐标轴
        /// </summary>
        /// <param name="arrPoints"></param>
        private void UpdateAxis(Point[] arrPoints)
        {
            if (arrPoints != null && arrPoints.Length > 0)
            {
                double dMinX = arrPoints[0].X;
                double dMaxX = arrPoints[0].Y;
                for (int i = 0; i < arrPoints.Length; i++)
                {
                    if (dMinX > arrPoints[i].X)
                    {
                        dMinX = arrPoints[i].X;
                    }
                    if (dMaxX < arrPoints[i].X)
                    {
                        dMaxX = arrPoints[i].X;
                    }
                }
                if (MinAxisX != dMinX || MaxAxisX != dMaxX)
                {
                    MinAxisX = dMinX;
                    MaxAxisX = dMaxX;
                    DoUpdateAxis();
                }
            }
        }

        /// <summary>
        /// 绘制坐标轴
        /// </summary>
        private void DoUpdateAxis()
        {
            Dispatcher.Invoke(DispatcherPriority.Normal,
                new Action(() =>
                {
                    GdAxis.Children.Clear();
                    if (MaxAxisX != 0 && MinAxisX != 0)
                    {
                        DoUpdateAxisX();
                    }
                    DoUpdateAxisY();
                }
                ));
        }

        /// <summary>
        /// 绘制X轴
        /// </summary>
        private void DoUpdateAxisX()
        {
            double dIntervalAxisX = (MaxAxisX - MinAxisX) / AxisXSectionCount;
            double dOffsetIntervalX = VbxContainer.ActualWidth / AxisXSectionCount;
            for (int i = 0; i <= AxisXSectionCount; i++)
            {
                double dAxisValue = Math.Round(MinAxisX + i * dIntervalAxisX, 2);
                double dOffsetX = 35 + i * dOffsetIntervalX;
                TextBlock oTbk = new TextBlock()
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Foreground = new SolidColorBrush(Colors.White)
                };
                oTbk.Text = dAxisValue.ToString();
                oTbk.Margin = new Thickness(dOffsetX, 0, 0, 5);
                GdAxis.Children.Add(oTbk);
            }
        }

        /// <summary>
        /// 绘制Y轴
        /// </summary>
        private void DoUpdateAxisY()
        {
            double dIntervalY = VbxContainer.ActualHeight / 4d;
            double interval = (MaxAxisY - MinAxisY) / 4;
            for (int i = 0; i < 5; i++)
            {
                int nAxisY = (int)(MaxAxisY - i * interval);
                TextBlock oTbk = new TextBlock()
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Foreground = new SolidColorBrush(Colors.White)
                };
                oTbk.Text = nAxisY.ToString();
                oTbk.Margin = new Thickness(15, i * dIntervalY, 0, 0);
                GdAxis.Children.Add(oTbk);
            }
        }

        /// <summary>
        /// 历史绘制的图像
        /// </summary>
        private RenderTargetBitmap PreviousBitmap = null;
        /// <summary>
        /// 添加数据，添加绘制
        /// </summary>
        /// <param name="arrPoints"></param>
        private void DoAddDataArray(Point[] arrPoints)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal,
                new Action(() =>
                {
                    double dPixelWidth = Pixel;
                    double dContainerWidth = VbxContainer.ActualWidth;
                    double dContainerHeight = VbxContainer.ActualWidth;
                    double dPxielHeight = Pixel / 2d;
                    double dCellHeight = 1;
                    double dCellWidth = 1;

                    DrawingVisual drawingVisual = new DrawingVisual();
                    DrawingContext drawingContext = drawingVisual.RenderOpen();
                    drawingContext.DrawRectangle(new SolidColorBrush(Colors.Blue),
                        new Pen(), new Rect(0, 0, dPixelWidth, dCellHeight));

                    //绘制新数据
                    for (int i = 0; i < arrPoints.Length; i++)
                    {
                        double dCellX = Math.Round(((arrPoints[i].X - MinAxisX) / (MaxAxisX - MinAxisX)) * Pixel);
                        double dY = arrPoints[i].Y;
                        Color oColor = GetColor(dY);
                        LinearGradientBrush linearBrush = new LinearGradientBrush();
                        linearBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 0));
                        linearBrush.GradientStops.Add(new GradientStop(oColor, 0.25));
                        linearBrush.GradientStops.Add(new GradientStop(oColor, 0.5));
                        linearBrush.GradientStops.Add(new GradientStop(oColor, 0.75));
                        linearBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 1));
                        drawingContext.DrawRectangle(linearBrush, new Pen(), new Rect(dCellX - 1, 0, dCellWidth + 2, dCellHeight));
                    }

                    //绘制历史数据
                    if (PreviousBitmap != null)
                    {
                        drawingContext.DrawImage(PreviousBitmap, new Rect(0, dCellHeight, dPixelWidth, dPxielHeight));
                    }
                    drawingContext.Close();

                    //生成图像处理
                    RenderTargetBitmap rtbCurrent = new RenderTargetBitmap((int)dPixelWidth, (int)dPxielHeight, 96, 96, PixelFormats.Pbgra32);
                    rtbCurrent.Render(drawingVisual);

                    PreviousBitmap = rtbCurrent;//当前绘制的存为历史，下次绘制时直接调用
                    ImgMain.Source = rtbCurrent;//显示绘制的图像
                }
                ));
        }

        private void AddDataArray(Point[] arrPoints)
        {
            UpdateAxis(arrPoints);//更新坐标
            DoAddDataArray(arrPoints);//绘制
        }

        /// <summary>
        /// 获取颜色
        /// </summary>
        /// <param name="dValue"></param>
        /// <returns></returns>
        private Color GetColor(double dValue)
        {
            if (dValue < MinAxisY)
            {
                return Colors.Blue;
            }
            if (dValue > MaxAxisY)
            {
                return Colors.Red;
            }
            double dIndex = Math.Round((dValue - MinAxisX) / (MaxAxisY - MinAxisY) * (ColorMap.Length - 1));
            int nIndex = (int)dIndex;
            return ColorMap[nIndex];
        }
        #endregion

        #region Sample

        private Point[] GetSampleDatas()
        {
            Point[] arrPoints = new Point[1000];
            double dX = 95.0;
            Random _random = new Random();

            for (int i = 0; i < arrPoints.Length; i++)
            {
                dX += 0.01;
                double dY = 0;
                if (i < 100)
                {
                    dY = _random.Next(-160, -120);
                }
                else if (i < 200)
                {
                    dY = _random.Next(-120, -90);
                }
                else if (i < 300)
                {
                    dY = _random.Next(-90, -60);
                }
                else if (i < 400)
                {
                    dY = _random.Next(-60, -30);
                }
                else if (i < 500)
                {
                    dY = _random.Next(-30, 1);
                }
                else if (i < 600)
                {
                    dY = _random.Next(-30, 1);
                }
                else if (i < 700)
                {
                    dY = _random.Next(-30, -60);
                }
                else if (i < 800)
                {
                    dY = _random.Next(-60, -90);
                }
                else if (i < 900)
                {
                    dY = _random.Next(-90, -120);
                }
                else
                {
                    dY = _random.Next(-120, -160);
                }
                Point _Point = new Point(dX, dY);
                arrPoints[i] = _Point;
            }
            return arrPoints;
        }

        DispatcherTimer TimerSample;
        private void ExecuteSample()
        {
            TimerSample = new DispatcherTimer();
            TimerSample.Interval = TimeSpan.FromMilliseconds(1);
            TimerSample.Tick += TimerSample_Click;
            TimerSample.Start();
        }

        Point[] SamplePoints;
        private void TimerSample_Click(object sender, EventArgs e)
        {
            SamplePoints = GetSampleDatas();
            DoAddDataArray(SamplePoints);
        }

        private void FreeSampleTimer()
        {
            if (this.TimerSample != null)
            {
                this.TimerSample.Stop();
                this.TimerSample.Tick -= TimerSample_Click;
                this.TimerSample = null;
            }
        }
        #endregion
    }
}
