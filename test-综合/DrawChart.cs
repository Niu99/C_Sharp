using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class DrawChart : Form
    {
        public DrawChart()
        {
            InitializeComponent();
        }
        GraphEdit graphEdit;
        //Color boardColor = Color.FromArgb(70, 130, 138);//指定绘制图的背景色
        Color boardColor = Color.SteelBlue;
        Thread toUpdate;
        private void LoadingUI()
        {
            graphEdit = new GraphEdit(840, 550, boardColor);
            graphEdit.HorizontalMargin = 50;//横水平边距
            graphEdit.VerticalMargin = 50;//垂直边距
            //graphEdit.AreaColor = Color.FromArgb(100, 100, 0, 0);//画图区域颜色
            graphEdit.AreaColor = Color.Teal;
            //graphEdit.GraphColor = Color.FromArgb(255, 110, 176);//曲线面积颜色
            graphEdit.GraphColor = Color.Green;
            //graphEdit.AxisColor = Color.FromArgb(180, 175, 255);//坐标轴颜色
            graphEdit.AxisColor = Color.White;
            //graphEdit.ScaleColor = Color.FromArgb(20, 255, 255, 255);//刻度线颜色
            graphEdit.ScaleColor = Color.White;

            graphEdit.XScaleCount = 24;//X轴刻度线数量
            graphEdit.YScaleCount = 10;//Y轴刻度线数量
            toUpdate = new Thread(new ThreadStart(Run));
            toUpdate.Start();
        }
        private void Run()
        {
            while (true)
            {
                Image image = graphEdit.GetCurrentGraph(GetBaseData(), xRange, yRange, false);
                Graphics g = CreateGraphics();

                g.DrawImage(image, 0, 0);
                g.Dispose();
                Thread.Sleep(500);
            }
        }
        float xRange = 1440;
        float yRange = 500;
        /// <summary>
        /// 得到数据
        /// </summary>
        /// <returns></returns>
        private List<Point> GetBaseData()
        {
            Random random = new Random();
            List<Point> result = new List<Point>();
            for (int i = 0; i < xRange - 200; i += 30)
            {
                Point p;
                if (i < 100)
                {
                    p = new Point(i, random.Next(201, 210));
                }
                else
                {
                    p = new Point(i, random.Next(210, 220));
                }
                result.Add(p);
            }
            return result;
        }

        private void DrawChart_Load(object sender, EventArgs e)
        {
            LoadingUI();
        }

        private void DrawChart_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                toUpdate.Abort();
            }
            catch (Exception)
            {
                Environment.Exit(0);
            }
        }
    }
}
