using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    class DataJudge
    {
        public void Judge<T>(TextBox textBox, T leftnum, T rightnum,int flag)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show("输入数据不能为空");
            }
            else
            {                
                switch (flag)
                {
                    case 0://保留一位小数，主要用于载波电平部分
                        var num = Convert.ToDouble(textBox.Text);
                        double left = Convert.ToDouble(leftnum);
                        double right = Convert.ToDouble(rightnum);
                        if (num < left)
                        {
                            num = left;
                        }
                        else if (num > right)
                        {
                            num = right;
                        }
                        else
                        {
                            return;
                        }
                        textBox.Text = num.ToString("F1");
                        break;
                    case 1://数据为int类型
                        var num1 = Convert.ToInt32(textBox.Text);
                        int left1 = Convert.ToInt32(leftnum);
                        int right1 = Convert.ToInt32(rightnum);
                        if (num1 < left1)
                        {
                            num1 = left1;
                        }
                        else if (num1 > right1)
                        {
                            num1 = right1;
                        }
                        else
                        {
                            return;
                        }
                        textBox.Text = Convert.ToInt32(num1).ToString();
                        break;
                    case 2://数据为十六进制数
                        var num2 = textBox.Text;
                        int number2 = int.Parse(num2, System.Globalization.NumberStyles.HexNumber);
                        int left2 = Convert.ToInt32(leftnum);
                        int right2 = Convert.ToInt32(rightnum);
                        if (number2 < left2)
                        {
                            number2 = left2;
                        }
                        else if (number2 > right2)
                        {
                            number2 = right2;
                        }
                        else
                        {
                            return;
                        }
                        textBox.Text = number2.ToString("X2");
                        break;
                    default:break;
                }
            }
        }
    }
}
