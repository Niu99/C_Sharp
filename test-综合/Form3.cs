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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//允许访问线程外的控件
        }
        struct Array
        {
            public int number;
            public string result;
        };
        DataTable dataTable = new DataTable();
        DataSet dataSet = new DataSet();
        int rowindex = 0;
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        //System.Threading.Timer timer;
        Array[] arrays = new Array[214748364];
        int flag = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            //timer = new System.Threading.Timer(makerandom, null, 0, Timeout.Infinite);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(makerandom);//生成随机数据并判断结果
            timer.AutoReset = false;//每到指定时间Elapsed事件触发一次
            //timer.AutoReset = true;//每到指定时间Elapsed事件一直触发
            timer.Enabled = true;
            timer.Start();//启动
            flag = 1;
        }
        public void makerandom(object obj, System.Timers.ElapsedEventArgs e)
        {
            Random random = new Random();
            int i = 0;
            try
            {
                int min = Convert.ToInt32(textBox1.Text.Trim());
                int max = Convert.ToInt32(textBox2.Text.Trim());
                while (flag == 1)
                {
                    arrays[i].number = random.Next();//随机结果放入数组中
                    //判断结果
                    if (arrays[i].number >= min && arrays[i].number <= max && min <= max)
                    {
                        arrays[i].result = "Yes";
                    }
                    else
                    {
                        arrays[i].result = "No";
                    }
                    Thread.Sleep(1000);
                    //用于防止多线程更新dgv数据出现界面卡死的情况
                    this.Invoke(new Action(delegate
                    {
                        //绑定datagridview代码
                        //将结果更新到dgv中
                        DataGridViewRow dr = new DataGridViewRow();
                        dr.CreateCells(dataGridView1);
                        rowindex++;
                        DataRow dataRow = dataTable.NewRow();//新建一行
                                                             //绑定数组相对应的数据
                        dataRow[0] = arrays[i].number;
                        dataRow[1] = arrays[i].result;
                        dataTable.Rows.Add(dataRow);
                        dataGridView1.DataSource = dataSet.Tables[0];
                        this.dataGridView1.Update();
                    }));
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据输入有误，请重新输入！");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataTable.Columns.Add("数据");
            dataTable.Columns.Add("是否在范围内");
            dataSet.Tables.Add(dataTable);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();
            flag = 0;
        }
    }
}
