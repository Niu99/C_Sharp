using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace test1
{
    public partial class picture : Form
    {
        public picture()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//打开图片
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "所有文件(*.*)|*.*|*jpg|*.JPG|*.GIF|*.BMP|*.png|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = openFileDialog.FileName;
                FileStream fileStream = new FileStream(filepath, FileMode.Open);
                byte[] PictureByte = new byte[fileStream.Length];
                BinaryReader binaryReader = new BinaryReader(fileStream);
                PictureByte = binaryReader.ReadBytes(Convert.ToInt32(fileStream.Length));
                MemoryStream memoryStream = new MemoryStream(PictureByte);
                Bitmap bitmap = new Bitmap(memoryStream);
                pictureBox1.Image = bitmap;
            }
            else
            {
                MessageBox.Show("打开失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)//保存图片
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*jpg | *.GIF | *.BMP | *.png | *.png";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != string.Empty && saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog.FileName);
            }
        }
    }
}
