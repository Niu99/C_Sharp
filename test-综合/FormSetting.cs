using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test1.Properties;

namespace test1
{
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
            FormSetting.DeploySettingPanelEvent += FormSetting_DeploySettingPanelEvent;
        }
        #region 委托
        public delegate void DeploySettingPanelEventHandler(object source, string settingTitle, EventArgs e);
        #endregion

        private string _HeadText = "";
        private int _FormHight = 100;
        private bool _FlageDeloyed = true;
        private bool _ControlsEnabled = true;
        public static event DeploySettingPanelEventHandler DeploySettingPanelEvent;
        public void DeployChange(bool isDeploy)
        {
            if (isDeploy)
            {
                Size = new Size(Width, _FormHight);
                button1.Image = Resources.ToolbarShown;
                DeploySettingPanelEvent(this, _HeadText, new EventArgs());
                foreach (Control control in Controls)
                {
                    if (control == tableLayoutPanel1 || control == button1 || control == panel1 || control is Splitter)
                    {

                    }
                    else
                    {
                        control.Visible = false;
                    }
                }
            }
            else
            {
                Size = new Size(Width, panel1.Height + 4);
                button1.Image = Resources.ToolbarHideden;
                foreach (Control control in Controls)
                {
                    if (control == tableLayoutPanel1 || control == button1 || control == panel1 || control is Splitter)
                    {

                    }
                    else
                    {
                        control.Visible = false;
                    }
                }
            }
            _FlageDeloyed = isDeploy;
            Refresh();
        }

        public int FormHight
        {
            set
            {
                _FormHight = value;
            }
            get
            {
                return _FormHight;
            }
        }

        public string HeadText { set; get; }

        public bool ControlsEnabled
        {
            set
            {
                _ControlsEnabled = value;
                foreach (Control control in Controls)
                {
                    control.Enabled = _ControlsEnabled;
                }
            }
            get
            {
                return _ControlsEnabled;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _FlageDeloyed = !_FlageDeloyed;
            DeployChange(_FlageDeloyed);
        }

        private void FormSetting_DeploySettingPanelEvent(object source, string settingTitle, EventArgs e)
        {
            if (settingTitle != _HeadText)
            {
                DeployChange(false);
            }
        }
    }
}
