using System;
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
    public partial class AccessDemo : Form
    {
        public AccessDemo()
        {
            InitializeComponent();
        }
        public void AutoUpdate()
        {
            //连接数据库
            string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=数据.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connection);
            dbConnection.Open();
            string strSelect = "Select * from student";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(strSelect, dbConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            dbConnection.Close();
        }
        private void AccessDemo_Load(object sender, EventArgs e)
        {
            AutoUpdate();
        }
       
        private void btnSearch_Click(object sender, EventArgs e)//数据查询
        {
            string ID = textBox1.Text;
            string Name = textBox2.Text;
            DataSet dataSet = new DataSet();
            string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=数据.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connection);
            dbConnection.Open();            
            if (ID == "")
            {
                string SearchByName = "select * from student where 姓名='"+ Name +"'";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(SearchByName, dbConnection);
                dataAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
            }

            else if (ID != "")
            {
                string SearchByID = "select * from student where 学号='" + ID + "'";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(SearchByID, dbConnection);
                dataAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
            }

            dbConnection.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)//数据增加
        {
            string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=数据.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connection);
            dbConnection.Open();
            string ID = textBox1.Text;
            string Name = textBox2.Text;
            string Insert = "insert into student(学号,姓名) values('" + ID + "','" + Name + "')";
            OleDbCommand dbCommand = new OleDbCommand(Insert, dbConnection);
            OleDbDataReader dbDataReader = dbCommand.ExecuteReader();
            //dbCommand.ExecuteNonQuery();
            dbConnection.Close();
            AutoUpdate();
        }

        private void btnChange_Click(object sender, EventArgs e)//数据修改
        {
            string ID = "'" + textBox1.Text + "'";
            string Name = "'" + textBox2.Text + "'";
            string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=数据.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connection);
            dbConnection.Open();
            string Update = "update student set 姓名=" + Name + " where 学号=" + ID;
            OleDbCommand dbCommand = new OleDbCommand(Update, dbConnection);
            dbCommand.ExecuteNonQuery();
            dbConnection.Close();
            AutoUpdate();
        }

        private void btnDel_Click(object sender, EventArgs e)//数据删除
        {
            string ID = "'" + textBox1.Text + "'";
            string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=数据.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connection);
            dbConnection.Open();
            string Delete = "delete from student where 学号=" + ID;
            OleDbCommand dbCommand = new OleDbCommand(Delete, dbConnection);
            dbCommand.ExecuteNonQuery();
            dbConnection.Close();
            AutoUpdate();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DataGridView dgv = sender as DataGridView;
            //if(dgv!=null&&dgv.CurrentCell!=null&&dgv.CurrentCell.RowIndex!=-1)
            string ID = dataGridView1.SelectedCells[0].Value.ToString();
            string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=数据.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connection);
            dbConnection.Open();
            if (MessageBox.Show("是否要删除?", "提示",MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {                
                string Delete = "delete from student where 学号='" + ID + "'";
                OleDbCommand dbCommand = new OleDbCommand(Delete, dbConnection);
                dbCommand.ExecuteNonQuery();
                dbConnection.Close();
                AutoUpdate();
            }                  
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoUpdate();
        }
    }
}
