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
    public partial class FormPoint : Form
    {
        public FormPoint()
        {
            InitializeComponent();
        }

        private void FormPoint_Load(object sender, EventArgs e)
        {
            for(int i=0;i<10;i++)
            {
                chart1.Series[i].ChartType = SeriesChartType.Point;
            }

            Random random = new Random();
            double j = 0;

            for (int i = 0; i < 10000; i++)
            {
                this.chart1.Series[0].Points.AddXY(j, random.Next(0,50));
                chart1.Series[1].Points.AddXY(j, random.Next(50, 100));
                j +=0.01;
            }
        }
    }
}
