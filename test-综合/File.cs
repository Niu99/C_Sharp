using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class File : Form
    {
        public File()
        {
            InitializeComponent();
        }
        private void File_Load(object sender, EventArgs e)
        {
            ReadFileInformation();
        }
        private void button1_Click(object sender, EventArgs e)//读取txt文件
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //string filepath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);//获取桌面的保存路径
            openFileDialog.Filter = "所有文件(*.*)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filepath = openFileDialog.FileName;
                    StreamReader streamReader = new StreamReader(filepath, System.Text.Encoding.ASCII);
                    richTextBox1.Text = streamReader.ReadToEnd();
                    streamReader.Close();
                }
                catch
                {
                    MessageBox.Show("文件打开失败");
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)//txt文件的保存
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "所有文件(*.*)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                    string str = richTextBox1.Text.ToString();
                    byte[] array = System.Text.Encoding.ASCII.GetBytes(str);
                    for (int i = 0; i < array.Length; i++)
                    {
                        streamWriter.WriteLine(array[i]);
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

        public void ReadFileInformation()
        {
            string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=FileInformation.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connection);
            dbConnection.Open();
            string strSelect = "Select * from File";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(strSelect, dbConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            dbConnection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string filename = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string filepath = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            try
            {
                StreamReader streamReader = new StreamReader(filepath + "\\" + filename, System.Text.Encoding.ASCII);
                richTextBox2.Text = streamReader.ReadToEnd();
                streamReader.Close();
            }
            catch
            {
                MessageBox.Show("文件打开失败");
            }

        }
    }
}
