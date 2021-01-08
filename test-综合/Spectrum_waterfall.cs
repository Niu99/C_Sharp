using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace test1
{
    public partial class Spectrum_waterfall : Form
    {
        public Spectrum_waterfall()
        {
            InitializeComponent();
        }

        private void ShowChart()
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            // clearing not teste
            GraphPane myPane = zedGraphControl1.GraphPane;
            //myPane.Title.Text = "消费者学历统计";  //设计图表的标题
            myPane.XAxis.Title.Text = "X"; //X轴标题
            myPane.YAxis.Title.Text = "Y"; //Y轴标题
            //      myPane.XAxis.Type = ZedGraph.AxisType.Date;

            // Date wont work in our case
            PointPairList PPLa = new PointPairList();
            //PointPairList PPLb = new PointPairList();
            //PointPairList PPLc = new PointPairList();
            //PointPairList PPLd = new PointPairList();

            //for (int i = 1; i < 2; i++)
            //{
                PPLa.Add(0, 1.2);
                //PPLb.Add(i + 1, i + 4);
                //PPLc.Add(i + 2, i + 5);
                //PPLd.Add(i + 3, i + 6);
            //}
            // dragged drawing baritems out of forloop
            BarItem myBara = myPane.AddBar("A", PPLa, Color.Red);
            //BarItem myBarb = myPane.AddBar("B", PPLb, Color.Blue);
            //BarItem myBarc = myPane.AddBar("C", PPLc, Color.Gray);
            //BarItem myBard = myPane.AddBar("D", PPLd, Color.Black);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();//这句话非常重要，否则不会立即显示
        }

        private void Spectrum_waterfall_Load(object sender, EventArgs e)
        {
            ShowChart();
        }
    }
}
