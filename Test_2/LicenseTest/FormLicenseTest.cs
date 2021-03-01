using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicenseTest
{
    public partial class FormLicenseTest : Form
    {
        public FormLicenseTest()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取CPU的参数
        /// </summary>
        /// <returns></returns>
        public string GetCPUId()
        {
            string CpuId = null;
            ManagementClass managementClass = new ManagementClass("Win32_Processor");
            ManagementObjectCollection managementObjectCollection = managementClass.GetInstances();
            foreach (ManagementObject managementObject in managementObjectCollection)
            {
                CpuId = managementObject.Properties["Processorid"].Value.ToString();
                break;
            }
            return CpuId;
        }

        /// <summary>
        /// 获取硬盘的参数
        /// </summary>
        /// <returns></returns>
        public string GetDiskVolumSerialNumber()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject mo = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            mo.Get();
            return mo.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        /// <summary>
        /// 获取硬件信息,生成机器码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            txtMachineInfo.Text = GetCPUId() + GetDiskVolumSerialNumber();//获得24位Cpu和硬盘序列号
        }

        public int[] intCode = new int[127];//用于存密钥
        public void setIntCode()
        {
            for (int i = 1; i < intCode.Length; i++)
            {
                intCode[i] = i % 10;
            }
        }
        public int[] intNumber = new int[25];//用于存机器码的ASCII值
        public char[] Charcode = new char[25];//存储机器码字

        /// <summary>
        /// 生成注册码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtMachineInfo.Text != "")
            {
                txtRegistText.Text = GetRegistText(txtMachineInfo.Text);
            }
            else
            {
                MessageBox.Show("请生成机器码", "提示");
            }
        }

        /// <summary>
        /// 根据机器码获取注册码
        /// </summary>
        /// <param name="machineText"></param>
        /// <returns></returns>
        private string GetRegistText(string machineText)
        {
            //把机器码存入到数组中
            setIntCode();//初始化127位数组
            for (int i = 1; i < Charcode.Length; i++)
            {
                Charcode[i] = Convert.ToChar(machineText.Substring(i - 1, 1));
            }
            for (int j = 1; j < intNumber.Length; j++)
            {
                intNumber[j] = intCode[Convert.ToInt32(Charcode[j])] + Convert.ToInt32(Charcode[j]);
            }

            string strASCIIName = null;//用于存储机器码
            for (int j = 1; j < intNumber.Length; j++)
            {
                if (intNumber[j] >= 48 && intNumber[j] <= 57)//判断字符ASCII值是否0－9之间
                {
                    strASCIIName += Convert.ToChar(intNumber[j]).ToString();
                }
                else if (intNumber[j] >= 65 && intNumber[j] <= 90)//判断字符ASCII值是否A－Z之间
                {
                    strASCIIName += Convert.ToChar(intNumber[j]).ToString();
                }
                else if (intNumber[j] >= 97 && intNumber[j] <= 122)//判断字符ASCII值是否a－z之间
                {
                    strASCIIName += Convert.ToChar(intNumber[j]).ToString();
                }
                else//判断字符ASCII值不在以上范围内
                {
                    if (intNumber[j] > 122)//判断字符ASCII值是否大于z
                    {
                        strASCIIName += Convert.ToChar(intNumber[j] - 10).ToString();
                    }
                    else
                    {
                        strASCIIName += Convert.ToChar(intNumber[j] - 9).ToString();
                    }
                }
            }
            return strASCIIName;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (txtRegistText.Text != "")
            {
                if(textBox1.Text.TrimEnd().Equals(txtRegistText.Text.TrimEnd()))
                {
                    //这里需要将机器码和注册码保存到数据库或注册表中，以便以后校验（推荐保存到数据库中，这样不怕重装系统）
                    MessageBox.Show("注册成功");
                }
                else
                {
                    MessageBox.Show("注册码输入错误");

                }

            }
            else 
            { 
                MessageBox.Show("请生成注册码", "注册提示"); 
            }
        }

        /// <summary>
        /// 验证是否激活软件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //这里重新生成机器码和注册码，与数据库中进行对比。只要有一个参数不一致，就是未激活
        }
    }
}
