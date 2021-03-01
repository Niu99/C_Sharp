using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LicenseTest.EncryptionHelper;

namespace LicenseTest
{
    public partial class FormLicenseTestfalse : Form
    {
        public FormLicenseTestfalse()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private string encryptComputer = string.Empty;
        private bool isRegist = false;
        private const int timeCount = 30;

        private void FormLicenseTest_Load(object sender, EventArgs e)
        {
            string computer = GetComputerInfo.GetComputerInformation();
            encryptComputer = new EncryptionHelper().EncryptString(computer);
            if (CheckRegist() == true)
            {
                lbRegistInfo.Text = "已注册";
            }
            else
            {
                lbRegistInfo.Text = "待注册，运行十分钟后自动关闭";
                RegistFileHelper.WriteComputerInfoFile(encryptComputer);
                TryRunForm();
            }

        }
        /// <summary>
        /// 试运行窗口
        /// </summary>
        private void TryRunForm()
        {
            Thread threadClose = new Thread(CloseForm);
            threadClose.IsBackground = true;
            threadClose.Start();
        }
        private bool CheckRegist()
        {
            EncryptionHelper helper = new EncryptionHelper();
            string md5key = helper.GetMD5String(encryptComputer);
            return CheckRegistData(md5key);
        }
        private bool CheckRegistData(string key)
        {
            if (RegistFileHelper.ExistRegistInfofile() == false)
            {
                isRegist = false;
                return false;
            }
            else
            {
                string info = RegistFileHelper.ReadRegistFile();
                var helper = new EncryptionHelper(EncryptionKeyEnum.KeyB);
                string registData = helper.DecryptString(info);
                if (key == registData)
                {
                    isRegist = true;
                    return true;
                }
                else
                {
                    isRegist = false;
                    return false;
                }
            }
        }

        private void CloseForm()
        {
            int count = 0;
            while (count < timeCount && isRegist == false)
            {
                if (isRegist == true)
                {
                    return;
                }
                Thread.Sleep(1 * 1000);
                count++;
            }
            if (isRegist == true)
            {
                return;
            }
            else
            {
                this.Close();
            }
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            if (lbRegistInfo.Text == "已注册")
            {
                MessageBox.Show("已经注册");
                return;
            }
            string fileName = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
            }
            else
            {
                return;
            }
            string localFileName = string.Concat(
                Environment.CurrentDirectory,
                Path.DirectorySeparatorChar,
                RegistFileHelper.RegistInfofile);
            if (fileName != localFileName)
                File.Copy(fileName, localFileName, true);

            if (CheckRegist() == true)
            {
                lbRegistInfo.Text = "已注册";
                MessageBox.Show("注册成功");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //string fileName = string.Empty;
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    fileName = openFileDialog.FileName;
            //}
            //else
            //{
            //    return;
            //}
            //string localFileName = string.Concat(
            //    Environment.CurrentDirectory,
            //    Path.DirectorySeparatorChar,
            //    RegistFileHelper.ComputerInfofile);

            //if (fileName != localFileName)
            //{
            //    File.Copy(fileName, localFileName, true);
            //}
            //string computer = RegistFileHelper.ReadComputerInfoFile();
            //EncryptionHelper help = new EncryptionHelper(EncryptionKeyEnum.KeyB);
            //string md5String = help.GetMD5String(computer);
            //string registInfo = help.EncryptString(md5String);
            //RegistFileHelper.WriteRegistFile(registInfo);
            //MessageBox.Show("注册码已生成");
        }
    }
}

