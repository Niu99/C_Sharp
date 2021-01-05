using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TextBoxSync
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            this.textBox1.Text = Properties.Resources._About;
        }

        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string name = (sender as LinkLabel).Name;
            if (name == "linkLabel1") System.Diagnostics.Process.Start("http://zzy.my");
            if (name == "linkLabel2") System.Diagnostics.Process.Start("mailto:zzylscy@163.com");
            if (name == "linkLabel3") System.Diagnostics.Process.Start("mailto:zzy@zzy-home.com");
        }
    }
}
