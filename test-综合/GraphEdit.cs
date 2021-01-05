using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    public partial class GraphEdit : Component
    {
        public GraphEdit()
        {
            InitializeComponent();
        }

        public GraphEdit(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        /// <summary>
        /// 画板宽度
        /// </summary>
        public int BoardWidth { get; set; }
        
        /// <summary>
        /// 画板高度
        /// </summary>
        public int BoardHeight { get; set; }
        /// <summary>
        /// 画板颜色
        /// </summary>
        public Color BoardColor { get; set; }
        /// <summary>
        /// 画图区域颜色
        /// </summary>
        public Color AreaColor { get; set; }
        /// <summary>
        /// 曲线图颜色
        /// </summary>
        public Color GraphColor { get; set; }
        /// <summary>
        /// 坐标轴颜色
        /// </summary>
        public Color AxisColor { get; set; }
        /// <summary>
        /// 刻度线颜色
        /// </summary>
        public Color ScaleColor { get; set; }
        /// <summary>
        /// 当前绘制的图
        /// </summary>
        public Bitmap CurrentImage { get; set; }
        /// <summary>
        /// 垂直边距
        /// </summary>
        public int VerticalMargin { get; set; }
        /// <summary>
        /// 平行边距
        /// </summary>
        public int HorizontalMargin { get; set; }
        /// <summary>
        /// X轴刻度线数量
        /// </summary>
        public int XScaleCount { get; set; }
        /// <summary>
        /// Y轴刻度线数量
        /// </summary>
        public int YScaleCount { get; set; }

        public GraphEdit(int width, int height, Color boardColor)
        {
            BoardWidth = width;
            BoardHeight = height;
            BoardColor = boardColor;
            XScaleCount = 10;
            YScaleCount = 10;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">需要绘制的数据</param>
        /// <param name="xRange">X轴的范围（data数据里面的实际范围）</param>
        /// <param name="yRange">Y轴的范围data数据里面的实际范围</param>
        /// <param name="isFill">是否需要面积填充</param>
        /// <returns>当前的曲线面积图</returns>
        public Image GetCurrentGraph(List<Point> data, float xRange, float yRange, bool isFill)
        {
            CurrentImage = new Bitmap(BoardWidth, BoardHeight);
            Graphics g = Graphics.FromImage(CurrentImage);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(BoardColor);

            //确定曲线图区域
            int iAreaWidth = BoardWidth - 2 * HorizontalMargin;//画图区域宽度
            int iAreaHeight = BoardHeight - 2 * VerticalMargin;//画图区域高度
            Point pAreaStart = new Point(HorizontalMargin, VerticalMargin);//画图区域起点
            Point pAreaEnd = new Point(BoardWidth - HorizontalMargin, BoardHeight - VerticalMargin);//画图区域终点
            Point pOrigin = new Point(HorizontalMargin, BoardHeight - VerticalMargin);//原点
            Rectangle rectangle = new Rectangle(pAreaStart, new Size(iAreaWidth, iAreaWidth));
            SolidBrush sbAreaBG = new SolidBrush(AreaColor);
            g.FillRectangle(sbAreaBG, rectangle);

            sbAreaBG.Dispose();

            //确定坐标轴
            Pen penAxis = new Pen(AxisColor, 5);
            penAxis.EndCap = LineCap.ArrowAnchor;
            g.DrawLine(penAxis, pOrigin, new Point(pAreaStart.X, pAreaStart.Y - VerticalMargin / 2));
            g.DrawLine(penAxis, pOrigin, new Point(pAreaEnd.X + HorizontalMargin / 2, pAreaEnd.Y));

            penAxis.Dispose();

            //确定刻度线和标签
            Pen penScale = new Pen(ScaleColor, 1);
            int fontSize = 8;
            for (int i = 0; i <= XScaleCount; i++)
            {
                int x = i * (iAreaWidth / XScaleCount) + pAreaStart.X;
                g.DrawLine(penScale, x, pAreaStart.Y, x, pAreaEnd.Y);
                string label = (i * (xRange / XScaleCount)).ToString();
                if (xRange == 1440)
                {
                    label = (i * (xRange / XScaleCount) / 60).ToString();
                }
                if (i != 0)
                {
                    g.DrawString(label, new Font("楷体", fontSize, FontStyle.Regular), new SolidBrush(AxisColor), new Point(x - fontSize, pAreaEnd.Y + VerticalMargin / 9));
                }
            }
            for (int i = 0; i < YScaleCount; i++)
            {
                int y = pAreaEnd.Y - (i * (iAreaHeight / YScaleCount));
                g.DrawLine(penScale, pAreaStart.X, y, pAreaEnd.X, y);
                string label = (i * (yRange / YScaleCount)).ToString();
                g.DrawString(label, new Font("楷体", fontSize, FontStyle.Regular), new SolidBrush(AxisColor), new Point(pAreaStart.X - (fontSize * label.Length) - HorizontalMargin / 9, y - fontSize / 2));
            }

            //获取数据并排序
            //绘画曲线面积
            List<Point> listPointData = SortingData(data);

            //数据转换，将实际的数据转换到图上的点
            List<Point> listPointGraphics = new List<Point>();//用于绘图的点
            foreach (Point point in listPointData)
            {
                Point p = new Point();
                p.X = pAreaStart.X + Convert.ToInt32((iAreaWidth / xRange) * point.X);//120为实际值的取值范围0-120
                p.Y = pAreaStart.Y + (iAreaHeight = Convert.ToInt32((iAreaHeight / yRange) * point.Y));//1000为实际值的取值范围0-1000
                listPointGraphics.Add(p);
            }

            //将点的集合加入到画曲线图的路径中
            GraphicsPath gpArea = new GraphicsPath();

            //第一个点，起点要从X轴上开始画，结束点也要画回X轴，即在开始点和结束点要多画一次原点的Y
            gpArea.AddLine(new Point(listPointGraphics[0].X, pOrigin.Y), listPointGraphics[0]);
            //中间点
            for (int i = 0; i < listPointGraphics.Count - 1; i++)
            {
                gpArea.AddLine(listPointGraphics[i], listPointGraphics[i + 1]);
            }
            //最后一个点
            gpArea.AddLine(listPointGraphics[listPointGraphics.Count - 1], new Point(listPointGraphics[listPointGraphics.Count - 1].X, pOrigin.Y));

            SolidBrush brush = new SolidBrush(GraphColor);//定义单色画刷

            if (isFill)
            {
                g.FillPath(brush, gpArea);//填充
            }
            else
            {
                g.DrawPath(new Pen(GraphColor, 5), gpArea);//边缘
            }
            gpArea.CloseFigure();//是否封闭
            return CurrentImage;
        }
        /// <summary>
        /// 数据排序
        /// </summary>
        /// <param name="lp"></param>
        /// <returns></returns>
        private List<Point> SortingData(List<Point> lp)
        {
            for (int i = 0; i < lp.Count; i++)
            {
                for (int j = 0; j < lp.Count - 1 - i; j++)
                {
                    if (lp[j].X > lp[j + 1].X)
                    {
                        Point temp = lp[j];
                        lp[j] = lp[j + 1];
                        lp[j + 1] = temp;
                    }
                }
            }
            return lp;
        }

    }
}
