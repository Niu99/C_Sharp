using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileToByte
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filepath = @"D:\Git\C_Sharp\Test_2\test.txt";
            //FileStream fs
            byte[] test = File.ReadAllBytes(filepath);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "所有文件(*.*)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                    //string str = richTextBox1.Text.ToString();
                    //byte[] array = System.Text.Encoding.ASCII.GetBytes(str);
                    for (int i = 0; i < test.Length; i++)
                    {
                        streamWriter.WriteLine(test[i]);
                    }
                    streamWriter.Flush();
                    streamWriter.Close();
                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//字节转数组
        {
            string filepath = @"D:\Git\C_Sharp\Test_2\BOOT.bin";
            byte[] buffer;
            string mess = "";
            using (FileStream fs = File.OpenRead(filepath))
            {
                buffer = new byte[fs.Length];
                byte[] b = new byte[1024];
                int i = 0;
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    for (int j = 0; j < 1024; j++)
                    {
                        if (i * 1024 + j < buffer.Length)
                        {
                            buffer[i * 1024 + j] = b[j];
                        }
                    }
                    i++;
                    mess += buffer[i].ToString("X2")+" ";
                }
                fs.Close();
                fs.Dispose();
                
            }
            richTextBox1.AppendText(mess);
        }
    }
}
