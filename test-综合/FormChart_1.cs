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
using System.Windows.Forms.DataVisualization.Charting;

namespace test1
{
    public partial class FormChart_1 : Form
    {
        public FormChart_1()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            List<int> x1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            List<int> y1 = new List<int>();
            Random ra = new Random();
            y1 = new List<int>() {
                ra.Next(1, 2),
                ra.Next(2, 3),
                ra.Next(3, 4),
                ra.Next(5, 6),
                ra.Next(4, 5),
                ra.Next(6, 7),
                ra.Next(7, 8),
                ra.Next(8, 9),
                ra.Next(9, 10),
                ra.Next(1, 10),
                ra.Next(2, 10),
                ra.Next(5, 10)
            };
            //for (int i = 0; i < y1.Count; i++)
            //{
            //    if (y1[i] > 1 && y1[i] < 2)
            //    {
            //        ChartHelper.AddSeries(chart3, "曲线图", SeriesChartType.SplineRange, Color.FromArgb(100, 46, 199, 201), Color.Red, true);
            //    }
            //    else if (y1[i] > 2 && y1[i] < 3)
            //    {
            //        ChartHelper.AddSeries(chart3, "曲线图", SeriesChartType.SplineRange, Color.Green, Color.Red, true);
            //    }
            //    else if (y1[i] > 3 && y1[i] < 4)
            //    {
            //        ChartHelper.AddSeries(chart3, "曲线图", SeriesChartType.SplineRange, Color.Blue, Color.Red, true);
            //    }
            //    else if (y1[i] > 4 && y1[i] < 5)
            //    {
            //        ChartHelper.AddSeries(chart3, "曲线图", SeriesChartType.SplineRange, Color.Yellow, Color.Red, true);
            //    }
            //    else if (y1[i] > 5 && y1[i] < 6)
            //    {
            //        ChartHelper.AddSeries(chart3, "曲线图", SeriesChartType.SplineRange, Color.YellowGreen, Color.Red, true);
            //    }
            //    else
            //    {
            //        ChartHelper.AddSeries(chart3, "曲线图", SeriesChartType.SplineRange, Color.Red, Color.Red, true);
            //    }
            //}

            //RefreshChart(x1, y1, "chart1");
            //RefreshChart(x1, y1, "chart2");
            RefreshChart(x1, y1, "chart3");
            //RefreshChart(x1, y1, "chart4");
        }

        public delegate void RefreshChartDelegate(List<int> x, List<int> y, string type);
        public void RefreshChart(List<int> x, List<int> y, string type)
        {
            //if (type == "chart1")
            //{
            //    if (this.chart1.InvokeRequired)
            //    {
            //        RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
            //        this.Invoke(stcb, new object[] { x, y, type });
            //    }
            //    else
            //    {
            //        chart1.Series[0].Points.DataBindXY(x, y);
            //        chart1.Series[1].Points.DataBindXY(x, y);
            //    }
            //}
            //else if (type == "chart2")
            //{
            //    if (this.chart2.InvokeRequired)
            //    {
            //        RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
            //        this.Invoke(stcb, new object[] { x, y, type });
            //    }
            //    else
            //    {
            //        chart2.Series[0].Points.DataBindXY(x, y);
            //        List<Color> colors = new List<Color>() {
            //            Color.Red,
            //            Color.DarkRed,
            //            Color.IndianRed,
            //            Color.MediumVioletRed,
            //            Color.OrangeRed,
            //            Color.PaleVioletRed,
            //            Color.Purple,
            //            Color.DarkOrange,
            //            Color.Maroon,
            //            Color.LightCoral,
            //            Color.LightPink,
            //            Color.Magenta
            //        };
            //        DataPointCollection points = chart2.Series[0].Points;
            //        for (int i = 0; i < points.Count; i++)
            //        {
            //            points[i].Color = colors[i];
            //        }
            //    }
            //}
            //else if (type == "chart3")
            //{
                if (this.chart3.InvokeRequired)
                {
                    RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                    this.Invoke(stcb, new object[] { x, y, type });
                }
                else
                {
                    chart3.Series[0].Points.DataBindXY(x, y);
                }
            //}
            //else if (type == "chart4")
            //{
            //    if (this.chart4.InvokeRequired)
            //    {
            //        RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
            //        this.Invoke(stcb, new object[] { x, y, type });
            //    }
            //    else
            //    {
            //        chart4.Series[0].Points.DataBindXY(x, y);
            //        List<Color> colors = new List<Color>() {
            //            Color.Red,
            //            Color.DarkRed,
            //            Color.IndianRed,
            //            Color.MediumVioletRed,
            //            Color.OrangeRed,
            //            Color.PaleVioletRed,
            //            Color.Purple,
            //            Color.DarkOrange,
            //            Color.Maroon,
            //            Color.LightCoral,
            //            Color.LightPink,
            //            Color.Magenta
            //        };
            //        DataPointCollection points = chart4.Series[0].Points;
            //        for (int i = 0; i < points.Count; i++)
            //        {
            //            points[i].Color = colors[i];
            //        }
            //    }
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(RefreshData)).Start();
        }

        private void FormChart_1_Load(object sender, EventArgs e)
        {
            //chart1.Series.Clear();
            //ChartHelper.AddSeries(chart1, "柱状图", SeriesChartType.Column, Color.Lime, Color.Red, true);
            //ChartHelper.AddSeries(chart1, "曲线图", SeriesChartType.Spline, Color.Red, Color.Red);
            //ChartHelper.SetTitle(chart1, "柱状图与曲线图", new Font("微软雅黑", 12), Docking.Bottom, Color.White);
            //ChartHelper.SetStyle(chart1, Color.Transparent, Color.White);
            //ChartHelper.SetLegend(chart1, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);
            //ChartHelper.SetXY(chart1, "序号", "数值", StringAlignment.Far, Color.White, Color.White, AxisArrowStyle.SharpTriangle, 1, 2);
            //ChartHelper.SetMajorGrid(chart1, Color.Gray, 20, 2);

            //chart2.Series.Clear();
            //ChartHelper.AddSeries(chart2, "饼状图", SeriesChartType.Pie, Color.Lime, Color.Red, true);
            //ChartHelper.SetStyle(chart2, Color.Transparent, Color.White);
            //ChartHelper.SetLegend(chart2, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);

            //chart3.Series.Clear();
            //ChartHelper.AddSeries(chart3, "曲线图", SeriesChartType.SplineRange, Color.FromArgb(100, 46, 199, 201), Color.Red, true);
            //ChartHelper.SetTitle(chart3, "曲线图", new Font("微软雅黑", 12), Docking.Bottom, Color.FromArgb(46, 199, 201));
            //ChartHelper.SetStyle(chart3, Color.Transparent, Color.White);
            //ChartHelper.SetLegend(chart3, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);
            //ChartHelper.SetXY(chart3, "序号", "数值", StringAlignment.Far, Color.White, Color.White, AxisArrowStyle.SharpTriangle, 1, 2);
            //ChartHelper.SetMajorGrid(chart3, Color.Gray, 20, 2);

            chart3.Series.Clear();
            ChartHelper.AddSeries(chart3, "曲线图", SeriesChartType.SplineRange, Color.FromArgb(100, 46, 199, 201), Color.Red, true);
            ChartHelper.SetTitle(chart3, "曲线图", new Font("微软雅黑", 12), Docking.Bottom, Color.FromArgb(46, 199, 201));
            ChartHelper.SetStyle(chart3, Color.Transparent, Color.White);
            ChartHelper.SetLegend(chart3, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);
            ChartHelper.SetXY(chart3, "序号", "数值", StringAlignment.Far, Color.Black, Color.Black, AxisArrowStyle.SharpTriangle, 1, 2);
            ChartHelper.SetMajorGrid(chart3, Color.Gray, 20, 2);

            //chart4.Series.Clear();
            //ChartHelper.AddSeries(chart4, "饼状图", SeriesChartType.Funnel, Color.Lime, Color.Red, true);
            //ChartHelper.SetStyle(chart4, Color.Transparent, Color.White);
            //ChartHelper.SetLegend(chart4, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);

            RefreshData();
        }
        public class ChartHelper
        {
            /// <summary>
            /// Name：添加序列
            /// Author：by boxuming 2019-04-28 13:59
            /// </summary>
            /// <param name="chart">图表对象</param>
            /// <param name="seriesName">序列名称</param>
            /// <param name="chartType">图表类型</param>
            /// <param name="color">颜色</param>
            /// <param name="markColor">标记点颜色</param>
            /// <param name="showValue">是否显示数值</param>
            public static void AddSeries(Chart chart, string seriesName, SeriesChartType chartType, Color color, Color markColor, bool showValue = false)
            {
                chart.Series.Add(seriesName);
                chart.Series[seriesName].ChartType = chartType;
                chart.Series[seriesName].Color = color;
                if (showValue)
                {
                    chart.Series[seriesName].IsValueShownAsLabel = true;
                    chart.Series[seriesName].MarkerStyle = MarkerStyle.Circle;
                    chart.Series[seriesName].MarkerColor = markColor;
                    chart.Series[seriesName].LabelForeColor = color;
                    chart.Series[seriesName].LabelAngle = -90;
                }
            }

            /// <summary>
            /// Name：设置标题
            /// Author：by boxuming 2019-04-28 14:25
            /// </summary>
            /// <param name="chart">图表对象</param>
            /// <param name="chartName">图表名称</param>
            public static void SetTitle(Chart chart, string chartName, Font font, Docking docking, Color foreColor)
            {
                chart.Titles.Add(chartName);
                chart.Titles[0].Font = font;
                chart.Titles[0].Docking = docking;
                chart.Titles[0].ForeColor = foreColor;
            }

            /// <summary>
            /// Name：设置样式
            /// Author：by boxuming 2019-04-23 14:04
            /// </summary>
            /// <param name="chart">图表对象</param>
            /// <param name="backColor">背景颜色</param>
            /// <param name="foreColor">字体颜色</param>
            public static void SetStyle(Chart chart, Color backColor, Color foreColor)
            {
                chart.BackColor = backColor;
                chart.ChartAreas[0].BackColor = backColor;
                chart.ForeColor = Color.Red;
            }

            /// <summary>
            /// Name：设置图例
            /// Author：by boxuming 2019-04-23 14:30
            /// </summary>
            /// <param name="chart">图表对象</param>
            /// <param name="docking">停靠位置</param>
            /// <param name="align">对齐方式</param>
            /// <param name="backColor">背景颜色</param>
            /// <param name="foreColor">字体颜色</param>
            public static void SetLegend(Chart chart, Docking docking, StringAlignment align, Color backColor, Color foreColor)
            {
                chart.Legends[0].Docking = docking;
                chart.Legends[0].Alignment = align;
                chart.Legends[0].BackColor = backColor;
                chart.Legends[0].ForeColor = foreColor;
            }

            /// <summary>
            /// Name：设置XY轴
            /// Author：by boxuming 2019-04-23 14:35
            /// </summary>
            /// <param name="chart">图表对象</param>
            /// <param name="xTitle">X轴标题</param>
            /// <param name="yTitle">Y轴标题</param>
            /// <param name="align">坐标轴标题对齐方式</param>
            /// <param name="foreColor">坐标轴字体颜色</param>
            /// <param name="lineColor">坐标轴颜色</param>
            /// <param name="arrowStyle">坐标轴箭头样式</param>
            /// <param name="xInterval">X轴的间距</param>
            /// <param name="yInterval">Y轴的间距</param>
            public static void SetXY(Chart chart, string xTitle, string yTitle, StringAlignment align, Color foreColor, Color lineColor, AxisArrowStyle arrowStyle, double xInterval, double yInterval)
            {
                chart.ChartAreas[0].AxisX.Title = xTitle;
                chart.ChartAreas[0].AxisY.Title = yTitle;
                chart.ChartAreas[0].AxisX.TitleAlignment = align;
                chart.ChartAreas[0].AxisY.TitleAlignment = align;
                chart.ChartAreas[0].AxisX.TitleForeColor = foreColor;
                chart.ChartAreas[0].AxisY.TitleForeColor = foreColor;
                chart.ChartAreas[0].AxisX.LabelStyle = new LabelStyle() { ForeColor = foreColor };
                chart.ChartAreas[0].AxisY.LabelStyle = new LabelStyle() { ForeColor = foreColor };
                chart.ChartAreas[0].AxisX.LineColor = lineColor;
                chart.ChartAreas[0].AxisY.LineColor = lineColor;
                chart.ChartAreas[0].AxisX.ArrowStyle = arrowStyle;
                chart.ChartAreas[0].AxisY.ArrowStyle = arrowStyle;
                chart.ChartAreas[0].AxisX.Interval = xInterval;
                chart.ChartAreas[0].AxisY.Interval = yInterval;
            }

            /// <summary>
            /// Name：设置网格
            /// Author：by boxuming 2019-04-23 14:55
            /// </summary>
            /// <param name="chart">图表对象</param>
            /// <param name="lineColor">网格线颜色</param>
            /// <param name="xInterval">X轴网格的间距</param>
            /// <param name="yInterval">Y轴网格的间距</param>
            public static void SetMajorGrid(Chart chart, Color lineColor, double xInterval, double yInterval)
            {
                chart.ChartAreas[0].AxisX.MajorGrid.LineColor = lineColor;
                chart.ChartAreas[0].AxisY.MajorGrid.LineColor = lineColor;
                chart.ChartAreas[0].AxisX.MajorGrid.Interval = xInterval;
                chart.ChartAreas[0].AxisY.MajorGrid.Interval = yInterval;
            }
        }
    }
}
