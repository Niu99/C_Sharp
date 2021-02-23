using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnListen_Click(object sender, EventArgs e)//监听
        {
            //ip地址
            IPAddress ip = IPAddress.Parse(txtIP.Text.Trim());
            // IPAddress ip = IPAddress.Any;
            //端口号
            IPEndPoint point = new IPEndPoint(ip, int.Parse(txtPort.Text.Trim()));
            //创建监听用的Socket
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Bind(point);//socket监听哪个端口
                socket.Listen(10);//同一个时间点过来10个客户端，排队
                ShowMsg("服务器开始监听");
                Thread thread = new Thread(AcceptInfo);
                thread.IsBackground = true;
                thread.Start(socket);
            }
            catch(Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }
        Dictionary<string, Socket> dic = new Dictionary<string, Socket>(); //记录通信用的Socket
        public void AcceptInfo(object o)
        {
            Socket socket = o as Socket;
            while (true)
            {
                //通信用socket
                try
                {
                    //创建通信用的Socket
                    Socket tSocket = socket.Accept();
                    string point = tSocket.RemoteEndPoint.ToString();
                    //IPEndPoint endPoint = (IPEndPoint)client.RemoteEndPoint;
                    //string me = Dns.GetHostName();//得到本机名称
                    //MessageBox.Show(me);
                    ShowMsg(point + "连接成功！");
                    cboIpPort.Items.Add(point);
                    dic.Add(point, tSocket);
                    //接收消息
                    Thread th = new Thread(ReceiveMsg);
                    th.IsBackground = true;
                    th.Start(tSocket);
                    Thread thread = new Thread(AutoReceivMsg);
                    thread.Start(tSocket);
                }
                catch (Exception ex)
                {

                    ShowMsg(ex.Message);
                    break;
                }
            }
        }
        public void AutoReceivMsg(object o)
        {
            Socket client = o as Socket;
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024];
                    int m = client.Receive(buffer);
                    string s = Encoding.UTF8.GetString(buffer, 0, m);
                    if (s != " ")
                    {
                        //byte[] bf = new byte[1024 * 1024];

                        client.Send(Encoding.UTF8.GetBytes("已收到!"));
                        ShowMsg(client.RemoteEndPoint.ToString() + ":" + s);
                        ShowMsg("已收到!");
                    }
                    else
                    {
                        client.Send(Encoding.UTF8.GetBytes("ok!"));
                        ShowMsg(client.RemoteEndPoint.ToString() + ":" + s);
                        ShowMsg("ok！");
                    }
                }
                catch (Exception ex)
                {
                    ShowMsg(ex.Message);
                    break;
                }
            }
        }
        //接收消息
        public void ReceiveMsg(object o)
        {
            Socket client = o as Socket;
            while (true)
            {
                //接收客户端发送过来的数据
                try
                {
                    //定义byte数组存放从客户端接收过来的数据
                    byte[] buffer = new byte[1024 * 1024];
                    //将接收过来的数据放到buffer中，并返回实际接受数据的长度
                    int n = client.Receive(buffer);
                    //将字节转换成字符串
                    string words = Encoding.UTF8.GetString(buffer, 0, n);
                    ShowMsg(client.RemoteEndPoint.ToString() + ":" + words);
                }

                catch (Exception ex)
                {
                    ShowMsg(ex.Message);
                    break;
                }

            }
        }
        public void ShowMsg(string msg)
        {
            txtLog.AppendText(msg + "\r\n");
        }
        public static byte[] IntArrToByteArr(int[] intArr)
        {
            int intSize = sizeof(int) * intArr.Length;
            byte[] bytArr = new byte[intSize];
            //申请一块非托管内存
            IntPtr ptr = Marshal.AllocHGlobal(intSize);
            //复制int数组到该内存块
            Marshal.Copy(intArr, 0, ptr, intArr.Length);
            //复制回byte数组
            Marshal.Copy(ptr, bytArr, 0, bytArr.Length);
            //释放申请的非托管内存
            Marshal.FreeHGlobal(ptr);
            return bytArr;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                ShowMsg(txtMsg.Text);
                string ip = cboIpPort.Text;
                byte[] buffer = Encoding.UTF8.GetBytes(txtMsg.Text);
                dic[ip].Send(buffer);
                // client.Send(buffer);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)//发送要校验的消息
        {
            try
            {
                ShowMsg(txtMsg.Text);
                string ip = cboIpPort.Text;
                int[] array = new int[1024];
                for (int i = 0; i < 100; i++)
                {
                    array[i] = 2 * i + 1;
                    txtMsg.Text = txtMsg.Text + array[i] + " ";
                }
                byte[] buffer = new byte[1024 * 1024];
                buffer = Encoding.UTF8.GetBytes(txtMsg.Text);
                dic[ip].Send(buffer);

            }

            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }
    }
}
