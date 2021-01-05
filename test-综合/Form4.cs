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

namespace test1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 设置RichTextBox控件根据条件设置行颜色
        /// </summary>
        /// <param name="rTxt">RichTextBox控件</param>
        /// <param name="bl">条件</param>
        /// <param name="yes">条件true显示颜色</param>
        /// <param name="no">条件false显示颜色</param>
        public static void SetRichTextBoxLineColor(RichTextBox rTxt, bool bl, Color yes, Color no)
        {
            for (int i = 0; i < rTxt.Lines.Length; i++)
            {
                rTxt.Select(rTxt.GetFirstCharIndexFromLine(i), rTxt.Lines[i].Length);
                if (bl)
                {
                    rTxt.SelectionColor = yes;
                }
                else
                {
                    rTxt.SelectionColor = no;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SetRichTextBoxLineColor(richTextBox1, false, Color.Red, Color.White);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string FilePath = @"D:\VS文件";
            DateTime dateTime = DateTime.Now;
            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);
            FilePath = string.Format(FilePath + "\\{0:D4}{1:D2}{2:D2}.txt", dateTime.Year, dateTime.Month, dateTime.Day);
            //FilePath = "保存结果.txt";
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(FilePath, true, Encoding.Default))
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    streamWriter.Write(dateTime);
                    streamWriter.Write("\n");
                    for (int j = 0; j < dataGridViewPeak.Columns.Count; j++)
                    {
                        stringBuilder.Append(dataGridViewPeak.Columns[j].Name.ToString() + "\t");
                    }
                    streamWriter.WriteLine(stringBuilder.ToString());
                    for (int i = 0; i < dataGridViewPeak.Rows.Count; i++)
                    {
                        stringBuilder = new StringBuilder();
                        for (int j = 0; j < dataGridViewPeak.Columns.Count; j++)
                        {
                            stringBuilder.Append(dataGridViewPeak.Rows[i].Cells[j].Value.ToString() + "\t");
                        }
                        streamWriter.WriteLine(stringBuilder.ToString());
                    }
                }
                MessageBox.Show("日志保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string outFilePath = @"D:\\VS文件\\保存结果.txt";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "导出结果";
            saveFileDialog.Filter = "导出结果(*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string saveFilename = saveFileDialog.FileName;
                if (!string.IsNullOrEmpty(saveFilename))
                {
                    outFilePath = saveFileDialog.FileName;
                }
            }
            if (outFilePath == "")
            {
                MessageBox.Show("路径不存在!");
                return;
            }
            if (dataGridViewPeak == null || dataGridViewPeak.Rows.Count == 0)
            {
                MessageBox.Show("导出行数不能为空！");
                return;
            }
            FileStream fileStream = new FileStream(outFilePath, FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(fileStream, System.Text.Encoding.Unicode);
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                for (int j = 0; j < dataGridViewPeak.Columns.Count; j++)
                {
                    stringBuilder.Append(dataGridViewPeak.Columns[j].Name.ToString() + "\t");
                }
                streamWriter.WriteLine(stringBuilder.ToString());
                for (int i = 0; i < dataGridViewPeak.Rows.Count; i++)
                {
                    stringBuilder = new StringBuilder();
                    for (int j = 0; j < dataGridViewPeak.Columns.Count; j++)
                    {
                        stringBuilder.Append(dataGridViewPeak.Rows[i].Cells[j].Value.ToString() + "\t");
                    }
                    streamWriter.WriteLine(stringBuilder.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                streamWriter.Close();
                fileStream.Close();
                MessageBox.Show("导出完成！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] dr2 = { "9999", "1000" };
            DataGridViewRow Row = new DataGridViewRow();
            int index2 = dataGridViewPeak.Rows.Add(Row);
            dataGridViewPeak.Rows[index2].Cells[0].Value = dr2[0];
            dataGridViewPeak.Rows[index2].Cells[1].Value = dr2[1];
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string[] dr1 = { "1", "555" };
            string[] dr2 = { "4444", "55" };
            DataGridViewRow Row = new DataGridViewRow();
            int index = dataGridViewPeak.Rows.Add(Row);
            dataGridViewPeak.Rows[index].Cells[0].Value = dr1[0].ToString();
            dataGridViewPeak.Rows[index].Cells[1].Value = dr1[1].ToString();
        }
    }
}
