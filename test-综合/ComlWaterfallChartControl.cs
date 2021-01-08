using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace test1
{

    public partial class ComlWaterfallChartControl: UserControl
    {
        public delegate void MyEventHandler(object sender, int switchType, int switchNumber, EventArgs e);

        public ComlWaterfallChartControl()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |

                     ControlStyles.ResizeRedraw |

                     ControlStyles.AllPaintingInWmPaint, true);

            InitColorsArr();
            //InitChart();

        }
        # region 字段
        #endregion

        #region 属性
       
        #endregion
        #region 事件
        #endregion

        //protected override void OnPaint(PaintEventArgs e)
        //{
           
        //}

        //protected override void OnMouseClick(MouseEventArgs e)
        //{

        //}

        #region 初始化颜色阶梯

        static Color[] ColorMap;

        //static ChartWnd1()
        //{
        //    InitColorsArr();
        //}

        private void InitColorsArr()
        {
            System.Drawing.Color[] crs = {System.Drawing.Color.Blue, System.Drawing.Color.Green,
                System.Drawing.Color.GreenYellow, System.Drawing.Color.Yellow,System.Drawing.Color.Orange,
                    System.Drawing.Color.OrangeRed, System.Drawing.Color.Red};
            Color[] arrColor = new Color[crs.Length * 50];
            int k = 0;
            for (int i = 0; i < crs.Length - 1; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    System.Drawing.Color low = crs[i];
                    System.Drawing.Color high = crs[i + 1];
                    int r = ((low.R * (50 - j)) + (high.R * j)) / 50;
                    int g = ((low.G * (50 - j)) + (high.G * j)) / 50;
                    int b = ((low.B * (50 - j)) + (high.B * j)) / 50;

                    byte color_R = Convert.ToByte(r);
                    byte color_G = Convert.ToByte(g);
                    byte color_B = Convert.ToByte(b);
                    //arrColor[k++] = Color.FromRgb(color_R, color_G, color_B);
                    arrColor[k++] = Color.FromArgb(color_R, color_G, color_B);
                }
            }

            ColorMap = new Color[(crs.Length - 1) * 50];
            for (int i = 0; i < ColorMap.Length; i++)
                ColorMap[i] = arrColor[i];
        }

        #endregion


        #region Const And Fields

        public int AxisXSectionCount = 90;
        private double MinAxisX = 0;
        private double MaxAxisX = 0;
        private double Pixel = 1000;

        private double MinAxisY = -160;
        private double MaxAxisY = 0;

        private bool IsHasInit = false;
        #endregion

        #region Core

        private void InitChart()
        {
            // 绘制两侧色阶
            //this.DrawVerticalColorArea(this.ImgColorAreaLeft);

            // 绘制Y轴坐标
            this.DoUpdateAxisY();
            // 绘制区域大小改变后，重新绘制X、Y坐标
            //this.GdAxis.SizeChanged += GdAxis_SizeChanged;
            this.SizeChanged += ComlWaterfallChartControl_SizeChanged;
        }

        private void ComlWaterfallChartControl_SizeChanged(object sender, EventArgs e)
        {
            this.DoUpdateAxis();
            //throw new NotImplementedException();
        }

        ///// <summary>
        /////  绘制区域大小改变后，重新绘制X、Y坐标
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void GdAxis_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    this.DoUpdateAxis();
        //}

        /// <summary>
        /// 绘制两侧色阶
        /// </summary>
        /// <param name="oImage"></param>
        private void DrawVerticalColorArea(Image oImage)
        {
            //int nColorLen = ColorMap.Length;
            //double dCellWidth = oImage.Width;
            //double dCellHeight = this.GdContent.ActualHeight / nColorLen;
            //int nCountInterval = nColorLen / 4;

            //DrawingVisual drawingVisual = new DrawingVisual();
            //DrawingContext drawingContext = drawingVisual.RenderOpen();
            //for (int i = 0; i < nColorLen; i++)
            //{
            //    Color oColor = ColorMap[i];
            //    // 绘制颜色块
            //    drawingContext.DrawRectangle(new SolidColorBrush(oColor),
            //        new Pen(), new Rect(0, i * dCellHeight, dCellWidth, dCellHeight));

            //    // 绘制黑色分割线
            //    if (i % nCountInterval == 0)
            //    {
            //        drawingContext.DrawRectangle(new SolidColorBrush(Colors.Black),
            //      new Pen(), new Rect(0, i * dCellHeight, dCellWidth, 2));
            //    }
            //}
            //drawingContext.Close();
            //RenderTargetBitmap rtb = new RenderTargetBitmap((int)oImage.Width,
            //    (int)this.GdContent.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            //rtb.Render(drawingVisual);

            //oImage.Source = rtb;
        }

        /// <summary>
        /// 绘制坐标轴
        /// </summary>
        /// <param name="arrPoints"></param>
        private void UpdateAxis(PointF[] arrPoints)
        {
            if (arrPoints != null && arrPoints.Length > 0)
            {
                double dMinX = arrPoints[0].X;
                double dMaxX = arrPoints[0].X;
                for (int i = 0; i < arrPoints.Length; i++)
                {
                    if (dMinX > arrPoints[i].X)
                        dMinX = arrPoints[i].X;
                    if (dMaxX < arrPoints[i].X)
                        dMaxX = arrPoints[i].X;
                }

                if (MinAxisX != dMinX || MaxAxisX != dMaxX)
                {
                    MinAxisX = dMinX;
                    MaxAxisX = dMaxX;

                    this.DoUpdateAxis();
                }
            }
        }

        /// <summary>
        /// 绘制坐标轴
        /// </summary>
        private void DoUpdateAxis()
        {
            //this.Dispatcher.Invoke(DispatcherPriority.Normal,
            //   new Action(() =>
            //   {
            //       this.GdAxis.Children.Clear();
            //       if (this.MaxAxisX != 0 && this.MinAxisX != 0)
            //           this.DoUpdateAxisX();
            //       this.DoUpdateAxisY();
            //   }));


            if (this.MaxAxisX != 0 && this.MinAxisX != 0)
            {
                this.DoUpdateAxisX();
            }
            this.DoUpdateAxisY();
        }

        /// <summary>
        /// 绘制X轴
        /// </summary>
        private void DoUpdateAxisX()
        {
            double dIntervalAxisX = (MaxAxisX - MinAxisX) / AxisXSectionCount;
            //double dOffsetIntervalX = this.VbxContainer.ActualWidth / AxisXSectionCount;
            //for (int i = 0; i <= AxisXSectionCount; i++)
            //{
            //    double dAxisValue = Math.Round(MinAxisX + i * dIntervalAxisX, 2);
            //    double dOffsetX = 35 + i * dOffsetIntervalX;

            //    TextBlock oTbk = new TextBlock()
            //    {
            //        HorizontalAlignment = HorizontalAlignment.Left,
            //        VerticalAlignment = VerticalAlignment.Bottom,
            //        Foreground = new SolidColorBrush(Colors.White)
            //    };
            //    oTbk.Text = dAxisValue.ToString();
            //    oTbk.Margin = new Thickness(dOffsetX, 0, 0, 5);
            //    this.GdAxis.Children.Add(oTbk);
            //}
        }

        /// <summary>
        /// 绘制Y轴
        /// </summary>
        private void DoUpdateAxisY()
        {
            //double dIntervalY = this.VbxContainer.ActualHeight / 4d;
            //double interval = (MaxAxisY - MinAxisY) / 4;
            //for (int i = 0; i < 5; i++)
            //{
            //    //int nAxisY = 90 - i * 25;
            //    int nAxisY = (int)(MaxAxisY - i * interval);
            //    TextBlock oTbk = new TextBlock()
            //    {
            //        HorizontalAlignment = HorizontalAlignment.Left,
            //        VerticalAlignment = VerticalAlignment.Top,
            //        Foreground = new SolidColorBrush(Colors.White)
            //    };
            //    oTbk.Text = nAxisY.ToString();
            //    oTbk.Margin = new Thickness(15, i * dIntervalY, 0, 0);
            //    this.GdAxis.Children.Add(oTbk);
            //}
            ////TextBlock tbkUnit = new TextBlock()
            ////{
            ////    HorizontalAlignment = HorizontalAlignment.Left,
            ////    VerticalAlignment = VerticalAlignment.Top,
            ////    Foreground = new SolidColorBrush(Colors.White),

            ////};
            ////tbkUnit.Text = "dBm";
            ////tbkUnit.Margin = new Thickness(0, 2.5 * dIntervalY, 0, 0);
            ////GdAxis.Children.Add(tbkUnit);
        }

        private PointF[] m_RecentArrPoints = new PointF[0];

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //this.Dispatcher.Invoke(DispatcherPriority.Normal,
            //   new Action(() =>
            //   {


            double dPixelWidth = Pixel;
            //double dContainerWidth = this.VbxContainer.ActualWidth;
            //double dContainerHeight = this.VbxContainer.ActualHeight;
            double dPixelHeight = Pixel / 2d;
            double dCellHeight = 2;
            double dCellWidth = 1;


            //DrawingVisual drawingVisual = new DrawingVisual();
            //DrawingContext drawingContext = drawingVisual.RenderOpen();
            g.DrawRectangle(new Pen(Color.Blue), new Rectangle(0, 0, (int)dPixelWidth, (int)dCellHeight));

            //// 绘制新数据

            for (int i = 0; i < m_RecentArrPoints.Length; i++)
            {
                double dCellX = Math.Round(((m_RecentArrPoints[i].X - MinAxisX) / (MaxAxisX - MinAxisX)) * Pixel);
                double dY = m_RecentArrPoints[i].Y;
                Color oColor = this.GetColor(dY);
                g.DrawRectangle(new Pen(oColor), new Rectangle((int)dCellX - 1, 0, (int)dCellWidth + 2, (int)dCellHeight));
                //    LinearGradientBrush lineBrush = new LinearGradientBrush();
                //    lineBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 0));
                //    lineBrush.GradientStops.Add(new GradientStop(oColor, 0.25));
                //    lineBrush.GradientStops.Add(new GradientStop(oColor, 0.5));
                //    lineBrush.GradientStops.Add(new GradientStop(oColor, 0.75));
                //    lineBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 1));
                //    drawingContext.DrawRectangle(lineBrush, new Pen(), new Rect(dCellX - 1, 0, dCellWidth + 2, dCellHeight));
            }


            // 绘制历史数据
            if (this.PreviousBitmap != null)
                //drawingContext.DrawImage(this.PreviousBitmap, new Rect(0, dCellHeight, dPixelWidth, dPixelHeight));
                g.DrawImage(this.PreviousBitmap, new Rectangle(0, (int)dCellHeight, (int)dPixelWidth, (int)dPixelHeight));
            //drawingContext.Close();

            // 生成图像处理
            //RenderTargetBitmap rtbCurrent = new RenderTargetBitmap((int)dPixelWidth,
            //    (int)dPixelHeight, 96, 96, PixelFormats.Pbgra32);
            Bitmap rtbCurrent = new Bitmap((int)dPixelWidth,
                (int)dPixelHeight);
            this.DrawToBitmap(rtbCurrent, new Rectangle(0, 0, (int)dPixelWidth, (int)dPixelHeight));

            //Marshal.Copy(Pixels, 0, Iptr, Pixels.Length);
            //rtbCurrent.Render(drawingVisual);

            this.PreviousBitmap = rtbCurrent; // 当前绘制的存为历史，下次绘制时直接调用

            //this.ImgMain.Source = rtbCurrent; // 显示绘制的图像
            //}));
        }
        /// <summary>
        /// 添加数据，附加绘制
        /// </summary>
        /// <param name="arrPoints"></param>
        private void DoAddDataArray(PointF[] arrPoints)
        {
            m_RecentArrPoints = arrPoints;
            this.Refresh();
        }

        /// <summary>
        /// 历史绘制的图像
        /// </summary>
        //private RenderTargetBitmap PreviousBitmap = null;
        private Bitmap PreviousBitmap = null;

        private void AddDataArray(PointF[] arrPoints)
        {
            this.UpdateAxis(arrPoints); // 更新坐标
            this.DoAddDataArray(arrPoints); // 绘制
        }

        /// <summary>
        /// 获取颜色
        /// </summary>
        /// <param name="dValue"></param>
        /// <returns></returns>
        private Color GetColor(double dValue)
        {
            if (dValue < MinAxisY)
                return Color.Blue;

            if (dValue > MaxAxisY)
                return Color.Red;

            double dIndex = Math.Round(((dValue - MinAxisY) / (MaxAxisY - MinAxisY)) * (ColorMap.Length - 1));
            int nIndex = (int)dIndex;
            return ColorMap[nIndex];
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            PointF[] SamplePoints = this.GetSampleDatas();
            this.AddDataArray(SamplePoints);
        }
        private PointF[] GetSampleDatas()
        {
            PointF[] arrPoints = new PointF[800];
            int dX = 1;

            Random oRandom = new Random();

            for (int i = 0; i < arrPoints.Length; i++)
            {
                dX += 1;

                //int dY = ;
                int dY=0;//= oRandom.Next(-160, -140);
                //if (i < 50)
                //    dY = oRandom.Next(-140, -110);
                //else if (i < 100)
                //    dY = oRandom.Next(-100, -80);
                //else if (i < 150)
                //    dY = oRandom.Next(-60, 0);
                //else if (i < 200)
                //    dY = oRandom.Next(-100, -80);
                //else if (i < 500)
                //    dY = oRandom.Next(-140, -110);
                //else if (i < 600)
                //    dY = oRandom.Next(-30, 1);
                //else if (i < 700)
                //    dY = oRandom.Next(-60, -30);
                //else if (i < 800)
                //    dY = oRandom.Next(-90, -60);
                //else if (i < 900)
                //    dY = oRandom.Next(-120, -90);
                //else
                //    dY = oRandom.Next(-160, -120);

                PointF oPoint = new PointF(dX, dY);
                arrPoints[i] = oPoint;
            }
            Thread.Sleep(5000);
            PointF _Pointf = new PointF(3, oRandom.Next(-80, 0));
            return arrPoints;
        }
    }
}
