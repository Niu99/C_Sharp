using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=数据.mdb";
            OleDbConnection odcConnection = new OleDbConnection(strConn); //2、打开连接 C#操作Access之按列读取mdb   
            odcConnection.Open(); //建立SQL查询   
            OleDbCommand odCommand = odcConnection.CreateCommand();
            odCommand.CommandText = "select 输出 from tabel1"; //建立读取 C#操作Access之按列读取mdb   
            OleDbDataReader odrReader = odCommand.ExecuteReader();
            ArrayList Arr = new ArrayList();
            while (odrReader.Read())
            {
                Arr.Add(odrReader["输出"].ToString());
            }
            odrReader.Close();
            odcConnection.Close();
            for (int i = 0; i < Arr.Count; i++)
            {
                richTextBox1.AppendText(Arr[i].ToString() + "\n");
            }
        }
        public void BubbleSort(ArrayList arrayList)
        {
            //int i, j, temp;
            double temp;
            bool done = false;
            int j = 1;
            while (j < arrayList.Count && (!done))
            {
                done = true;
                for (int i = 0; i < arrayList.Count - 1; i++)
                {
                    if (Convert.ToDouble(arrayList[i]) > Convert.ToDouble(arrayList[i + 1]))
                    {
                        done = false;
                        temp = Convert.ToDouble(arrayList[i]);
                        arrayList[i] = Convert.ToDouble(arrayList[i + 1]);
                        arrayList[i + 1] = temp;
                    }
                }
                j++;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=数据.mdb";
            OleDbConnection odcConnection = new OleDbConnection(strConn); //2、打开连接 C#操作Access之按列读取mdb   
            odcConnection.Open(); //建立SQL查询   
            OleDbCommand odCommand = odcConnection.CreateCommand();
            odCommand.CommandText = "select 衰减或增益值 from Sheet1"; //建立读取 C#操作Access之按列读取mdb   
            OleDbDataReader odrReader = odCommand.ExecuteReader();
            ArrayList Arr = new ArrayList();

            while (odrReader.Read())
            {
                Arr.Add(odrReader["衰减或增益值"].ToString());
            }
            odrReader.Close();
            odcConnection.Close();
            BubbleSort(Arr);
            //for (int i = 0; i < Arr.Count; i++)
            //{
            //    richTextBox1.AppendText(Arr[i].ToString() + "\n");
            //}
            double result = 0;
            try
            {
                var tmp = Convert.ToDouble(textBox1.Text);
                for (int i = 0; i < Arr.Count; i++)
                {
                    if (Convert.ToDouble(Arr[i]) >= tmp)
                    {
                        //richTextBox1.AppendText(Arr[i].ToString() + "\n");
                        result = Convert.ToDouble(Arr[i]);
                        richTextBox1.AppendText(i.ToString() + "\n");
                        break;
                    }
                }
                richTextBox1.AppendText(result.ToString() + "\n");
                double AT = (result - tmp) / 20;
                double finaresult = Math.Ceiling(Convert.ToDouble(11626 * Math.Pow(10, AT)));
                richTextBox1.AppendText(finaresult.ToString() + "\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            public struct RX
        {
            public int level;//档位
            public int output;//输出
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=数据.mdb";
            OleDbConnection odcConnection = new OleDbConnection(strConn); //2、打开连接 C#操作Access之按列读取mdb   
            odcConnection.Open(); //建立SQL查询   
            OleDbCommand odCommand1 = odcConnection.CreateCommand();
            OleDbCommand odCommand = odcConnection.CreateCommand();
            odCommand1.CommandText = "select 输出 from RX"; //建立读取 C#操作Access之按列读取mdb 
            odCommand.CommandText = "select 档位 from RX";
            OleDbDataReader odrReader = odCommand.ExecuteReader();
            OleDbDataReader oleDbDataReader = odCommand1.ExecuteReader();
            ArrayList Arr1 = new ArrayList();
            ArrayList Arr = new ArrayList();
            while (odrReader.Read())
            {
                Arr.Add(odrReader["档位"].ToString());
            }
            while (oleDbDataReader.Read())
            {
                Arr1.Add(oleDbDataReader["输出"].ToString());
            }
            odrReader.Close();
            oleDbDataReader.Close();
            odcConnection.Close();
            RX[] rs = new RX[Arr.Count + 1];
            for (int i = 0; i < Arr.Count; i++)
            {
                rs[i].level = Convert.ToInt32(Arr[i]);
                rs[i].output = Convert.ToInt32(Arr1[i]);
            }
            for (int i = 0; i < Arr.Count; i++)
            {
                for (int j = i; j < Arr.Count; j++)
                {
                    if (rs[i].output > rs[j].output)
                    {
                        RX temp;
                        temp = rs[i];
                        rs[i] = rs[j];
                        rs[j] = temp;
                    }
                }
            }
            double result = 0;
            try
            {
                var tmp = Convert.ToDouble(textBox1.Text);
                for (int i = 0; i < Arr.Count; i++)
                {
                    if (rs[i].output >= tmp)
                    {
                        //richTextBox1.AppendText(Arr[i].ToString() + "\n");
                        result = rs[i].output;
                        richTextBox1.AppendText(rs[i].level.ToString() + "\n");
                        break;
                    }
                }
                richTextBox1.AppendText(result.ToString() + "\n");
                double AT = (tmp - result) / 20;
                double finaresult = Math.Ceiling(Convert.ToDouble(11626 * Math.Pow(10, AT)));
                richTextBox1.AppendText(finaresult.ToString() + "\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
