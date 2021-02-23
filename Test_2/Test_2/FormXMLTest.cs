using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Test_2
{
    public partial class FormXMLTest : Form
    {
        public FormXMLTest()
        {
            InitializeComponent();
        }
        //文件存放路径
        private const string ConfigPath = @"D:\VS2019\Test_2\";

        private void GetXElement(XElement root)
        {
            foreach (XElement element in root.Elements())
            {
                if (element.Elements().Count() > 0)
                {
                    richTextBox1.Text += element.Name.ToString() + "\n";
                    GetXElement(element);
                }
                else
                {
                    richTextBox1.Text += element.Value.ToString() + "\n";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //通过XDocument类访问读取xml文件
            XDocument xDocument = XDocument.Load(ConfigPath + "Test.xml");
            XElement root = xDocument.Root;

            GetXElement(root);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XDocument xDocument = XDocument.Load(ConfigPath + "Test.xml");
            XElement root = xDocument.Root;
            TreeNode treeNode = this.treeView1.Nodes.Add(root.Name.ToString());
            LoadNode(root, treeNode);
        }
        private void LoadNode(XElement element, TreeNode treeNode)
        {
            foreach (XElement xElement in element.Elements())
            {
                if (xElement.Elements().Count() > 0)
                {
                    TreeNode node = treeNode.Nodes.Add(xElement.Name.ToString());
                    foreach (XAttribute attribute in element.Attributes())
                    {
                        node.Text += "[" + attribute.Name.ToString() + "=" + attribute.Value + "]";
                    }
                    LoadNode(xElement, node);
                }
                else
                {
                    TreeNode node = treeNode.Nodes.Add(xElement.Value);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)//写入XML文件
        {

        }
    }
}
