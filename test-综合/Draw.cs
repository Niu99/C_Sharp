using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace test1
{
    public partial class Draw : Form
    {
        public Draw()
        {
            InitializeComponent();
        }
        private Queue<double> dataQueue = new Queue<double>(100);
        private int curValue = 0;
        private int num = 5;
        private void Draw_Load(object sender, EventArgs e)
        {

        }
        ///<summary>
        ///开始事件
        ///</summary>
        ///<param name="sender"></param>
        ///<param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            InitChart();
            timer1.Start();
        }

        ///<summary>
        ///停止事件
        ///</summary>
        ///<param name="sender"></param>
        ///<param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        ///<summary>
        ///定时器事件
        ///</summary>
        ///<param name="sender"></param>
        ///<param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateQueueValue();
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < dataQueue.Count; i++)
            {
                if (dataQueue.ElementAt(i) > -50 && dataQueue.ElementAt(i) < -20)
                {
                    chart1.Series[0].Color = Color.Blue;
                }
                if (dataQueue.ElementAt(i) > -20 && dataQueue.ElementAt(i) < 10)
                {
                    chart1.Series[0].Color = Color.Red;
                }
                else
                {
                    chart1.Series[0].Color = Color.Green;
                }
                chart1.Series[0].Points.AddXY(10, dataQueue.ElementAt(i));
            }
        }
        ///<summary>
        ///初始化图表
        ///</summary>
        private void InitChart()
        {
            //定义图表区域
            chart1.ChartAreas.Clear();
            ChartArea chartArea1 = new ChartArea("C1");
            chart1.ChartAreas.Add(chartArea1);
            //定义存储和显示点的容器
            chart1.Series.Clear();
            Series series1 = new Series("S1");
            series1.ChartArea = "C1";
            chart1.Series.Add(series1);
            //设置图表显示样式
            int minmum = Convert.ToInt32(textBox1.Text);
            int maxmum = Convert.ToInt32(textBox2.Text);
            chart1.ChartAreas[0].AxisY.Minimum = minmum;
            chart1.ChartAreas[0].AxisY.Maximum = maxmum;
            //chart1.ChartAreas[0].AxisX.Interval = 10;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Silver;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Silver;
            //设置标题
            chart1.Titles.Clear();
            chart1.Titles.Add("S01");
            chart1.Titles[0].Text = "xxx显示";
            chart1.Titles[0].ForeColor = Color.RoyalBlue;
            chart1.Titles[0].Font = new Font("Microsoft Sans Serif", 12F);
            //设置图表显示样式
            chart1.Series[0].Color = Color.Green;
            if (radioButton1.Checked)
            {
                chart1.Titles[0].Text = string.Format("{0}显示", radioButton1.Text);
                chart1.Series[0].ChartType = SeriesChartType.Column;
                chart1.Series[0].Color = Color.Blue;
            }
            if (radioButton2.Checked)
            {
                chart1.Titles[0].Text = string.Format("{0} 显示", radioButton2.Text);
                chart1.Series[0].ChartType = SeriesChartType.Spline;
            }
            if (radioButton3.Checked)
            {
                chart1.Series[0].Points.Clear();
                chart1.Titles[0].Text = string.Format("{0}显示", radioButton3.Text);
                chart1.Series[0].ChartType = SeriesChartType.Point;
            }
            chart1.Series[0].Points.Clear();
        }

        //更新队列中的值
        private void UpdateQueueValue()
        {
            int leftnum = Convert.ToInt32(textBox3.Text);
            int rightnum = Convert.ToInt32(textBox4.Text);
            if (dataQueue.Count > 100)
            {
                for (int i = 0; i < num; i++)
                {
                    dataQueue.Dequeue();
                }
            }
            if (radioButton1.Checked)
            {
                Random random = new Random();
                for (int i = 0; i < num; i++)
                {
                    dataQueue.Enqueue(random.Next(leftnum, rightnum));
                }
            }
            if (radioButton2.Checked)
            {
                for (int i = 0; i < num; i++)
                {
                    //对curValue只取[0,360]之间的值
                    curValue = curValue % 360;
                    //对得到的正弦值，放大50倍，并上移50
                    dataQueue.Enqueue((10 * Math.Sin(curValue * Math.PI / 180)));
                    curValue = curValue + 10;
                }
            }
            if (radioButton3.Checked)
            {
                Random random = new Random();
                for (int i = 0; i < num; i++)
                {
                    dataQueue.Enqueue(random.Next(leftnum, rightnum));
                }
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            InitChart();
        }

    }
}
