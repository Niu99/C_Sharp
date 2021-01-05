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
    public partial class MoreDraw : Form
    {
        public MoreDraw()
        {
            InitializeComponent();
        }
		private void InitChart()
		{
            //定义图表区域
            //chart1.ChartAreas.Clear();
            //ChartArea chartArea1 = new ChartArea("C1");
            //chart1.ChartAreas.Add(chartArea1);
            ////定义存储和显示点的容器
            //chart1.Series.Clear();
            //Series series1 = new Series("Drop_Freq");
            //series1.ChartArea = "C1";
            //chart1.Series.Add(series1);

            ////设置图表显示样式
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.ChartAreas[0].AxisX.Interval = 100;
            chart1.ChartAreas[0].AxisY.Interval = chart1.ChartAreas[0].AxisY.Maximum / 2;
            //chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Silver;
            //chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Silver;
            //chart1.ChartAreas[0].BackColor = Color.Gainsboro;
            //标题设置
            //chart1.Titles.Clear();
            //chart1.Titles.Add("S01");
            //chart1.Titles[0].Text = "多普勒频率显示";
            //chart1.Titles[0].ForeColor = Color.Green;
            //chart1.Titles[0].Font = new Font("Microsoft Sans Serif", 12F);
            //设置图表显示样式
            //chart1.Series[0].Color = Color.Green;
            //chart1.Titles[0].Text = "多普勒频率显示";
            //chart1.Series[0].ChartType = SeriesChartType.SplineArea;//画图用曲线
            //chart1.Series[0].Points.Clear();
        }
		private Queue<double> dataQueue = new Queue<double>(100);
		private void UpdateQueueValue()
		{
			if (dataQueue.Count > 100)
			{
				for (int i = 0; i < 5; i++)
				{
					dataQueue.Dequeue();
				}
			}
			for (int i = 0; i < 1; i++)
			{
				Random random = new Random();
				dataQueue.Enqueue(random.Next(0,100));
			}
		}
		private void button1_Click(object sender, EventArgs e)
        {
			timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
			UpdateQueueValue();
			for (int i = 0; i < dataQueue.Count; i++)
			{
                if (dataQueue.ElementAt(i) > 0 && dataQueue.ElementAt(i) < 25)
                {
                    chart1.Series[1].Points.AddXY((i + 1), dataQueue.ElementAt(i));
                }
                if (dataQueue.ElementAt(i) > 25 && dataQueue.ElementAt(i) < 50)
                {
                    chart1.Series[2].Points.AddXY((i + 1), dataQueue.ElementAt(i));
                }
                if (dataQueue.ElementAt(i) > 50 && dataQueue.ElementAt(i) < 75)
                {
                    chart1.Series[3].Points.AddXY((i + 1), dataQueue.ElementAt(i));
                }
                if (dataQueue.ElementAt(i) > 75 && dataQueue.ElementAt(i) < 100)
                {
                    chart1.Series[0].Points.AddXY((i + 1), dataQueue.ElementAt(i));
                }
                if (i / 100 == 0)
                {
                    chart1.Series[0].Points.Clear();
                    chart1.Series[1].Points.Clear();
                    chart1.Series[2].Points.Clear();
                    chart1.Series[3].Points.Clear();
                }
            }
		}


        private void button2_Click(object sender, EventArgs e)
        {
			timer1.Stop();
        }
    }
}
