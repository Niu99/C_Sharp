using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataJudge dataJudge = new DataJudge();
            dataJudge.Judge(textBox1, 10, 20, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataJudge dataJudge = new DataJudge();
            dataJudge.Judge(textBox2, 100, 200, 1);
        }

        private void button3_Click(object sender, EventArgs e)//判断并自动修正数据
        {
            DataJudge dataJudge = new DataJudge();
            dataJudge.Judge(textBox3, 00, int.Parse("FFE",System.Globalization.NumberStyles.HexNumber), 2);
        }

        private void button4_Click(object sender, EventArgs e)//获取本地IP地址
        {
            string HostName = Dns.GetHostName();
            textBox4.Text = HostName;
            IPHostEntry MyEntry = Dns.GetHostByName(Dns.GetHostName());
            IPAddress MyAddress = new IPAddress(MyEntry.AddressList[2].Address);
            textBox4.Text = MyAddress.ToString();
            
        }

        private void button5_Click(object sender, EventArgs e)//生成log文件
        {
            for (int i = 0; i < 5000; i++)
            {
                DateTime dateTime = DateTime.Now;
                string time = string.Format("{0:D4}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2} {6:D2}\n",
                      dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
                textBox5.AppendText(time);
            }
            if (textBox5.Text != "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "日志" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                //将日期时间作为文件名
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName, true);
                streamWriter.Write(textBox5.Text);
                streamWriter.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "(*.txt)|*.txt|(*.*)|*.*";
            saveFileDialog.FileName = "文件" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            //将日期时间作为文件名
            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //{
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName, true);
                streamWriter.Write(textBox5.Text);
                streamWriter.Close();
           // }
        }
    }
}
