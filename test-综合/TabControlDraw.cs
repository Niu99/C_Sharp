using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class TabControlDraw : Form
    {
        public TabControlDraw()
        {
            InitializeComponent();
        }
        FormSetting _formSetting = new FormSetting();

        private void TabControlDraw_Load(object sender, EventArgs e)
        {
            _formSetting.Dock = DockStyle.Top;
            _formSetting.TopLevel = false;
            _formSetting.Parent = panel1;
            _formSetting.Show();
            _formSetting.DeployChange(false);
            
        }

        private void ControlStatusToPlayback()
        {
            _formSetting.ControlsEnabled = false;
        }

        private void ControlStatusToRealTime()
        {
            _formSetting.ControlsEnabled = true;
        }
    }
}
