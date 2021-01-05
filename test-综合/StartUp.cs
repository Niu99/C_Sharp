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
    public partial class StartUp : Form
    {
        public StartUp()
        {
            InitializeComponent();
            
        }
        
        private void StartUp_Load(object sender, EventArgs e)
        {
            aimProgressBar1.Maximum = 9;
            aimProgressBar1.Minimum = 0;
            aimProgressBar1.Value = 0;
            timer1.Start();
        }
        public void startprogress()
        {
            for (int i = 0; i < 9; i++)
            {
                //aimProgressBar1.Minimum = 0;
                //aimProgressBar1.Maximum = 9;
                //Thread.Sleep(1000);
                Invoke(new Action(() => aimProgressBar1.Value += aimProgressBar1.Step));
                Invoke(new Action(() => aimProgressBar1.Step = 5));
                
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (aimProgressBar1.Value < aimProgressBar1.Maximum)
            {
                aimProgressBar1.Value += 3;
            }
            else
            {
                timer1.Enabled = false;
            }
        }
    }
}
