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

namespace FileDelete
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static Dictionary<string, long> dicts = new Dictionary<string, long>();
        static void GetTxtFiles(string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                return;
            }
            //创建一个DirectoryInfo的类
            DirectoryInfo directoryInfo = new DirectoryInfo(filePath);
            //获取当前的目录的文件
            FileInfo[] fileInfos = directoryInfo.GetFiles();
            foreach (FileInfo info in fileInfos)
            {
                //获取文件的名称(包括扩展名)
                string fullName = info.FullName;
                //获取文件的扩展名
                string extension = info.Extension.ToLower();
                if (extension == ".log")
                {
                    //获取文件的大小
                    long length = info.Length;
                    dicts.Add(fullName, length);
                }
            }
            //获取当前目录下的所有子目录
            DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
            foreach (DirectoryInfo info in directoryInfos)
            {
                //获取当前子目录的路径
                string path = info.FullName;
                //递归调用
                GetTxtFiles(path);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"D:\VS文件\test";
            GetTxtFiles(path);
            //Console.WriteLine("总数为:{0}", dicts.Count);
            string mess = "";
            foreach (var key in dicts.Keys)
            {
                //if (dicts[key] > 50)
                //{
                //    File.Delete(key);
                //} 
                mess += string.Format("当前的key:{0},值:{1}\n", key, dicts[key]);
            }
            richTextBox1.Text = mess;
        }
    }
}
