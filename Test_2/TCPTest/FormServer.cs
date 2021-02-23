using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPTest
{
    public partial class FormServer : Form
    {
        public FormServer()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }
        Thread threadWatch = null; //负责监听客户端的线程
        Socket socketWatch = null; //负责监听客户端的套接字
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //定义一个套接字用于监听客户端发来的信息  包含3个参数(IP4寻址协议,流式连接,TCP协议)
            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //服务端发送信息 需要1个IP地址和端口号
            IPAddress ipaddress = IPAddress.Parse(txtIP.Text.Trim()); //获取文本框输入的IP地址
            //将IP地址和端口号绑定到网络节点endpoint上 
            IPEndPoint endpoint = new IPEndPoint(ipaddress, int.Parse(txtPORT.Text.Trim())); //获取文本框上输入的端口号
            //监听绑定的网络节点
            socketWatch.Bind(endpoint);
            //将套接字的监听队列长度限制为20
            socketWatch.Listen(20);
            //创建一个监听线程 
            threadWatch = new Thread(WatchConnecting);
            //将窗体线程设置为与后台同步
            threadWatch.IsBackground = true;
            //启动线程
            threadWatch.Start();
            //启动线程后 txtMsg文本框显示相应提示
            txtMsg.AppendText("开始监听客户端传来的信息!" + "\r\n");
        }

        //创建一个负责和客户端通信的套接字 
        Socket socConnection = null;

        /// <summary>
        /// 监听客户端发来的请求
        /// </summary>
        private void WatchConnecting()
        {
            while (true)  //持续不断监听客户端发来的请求
            {
                socConnection = socketWatch.Accept();
                txtMsg.AppendText("客户端连接成功" + "\r\n");
                //创建一个通信线程 
                ParameterizedThreadStart pts = new ParameterizedThreadStart(ServerRecMsg);
                Thread thr = new Thread(pts);
                thr.IsBackground = true;
                //启动线程
                thr.Start(socConnection);
            }
        }

        /// <summary>
        /// 发送信息到客户端的方法
        /// </summary>
        /// <param name="sendMsg">发送的字符串信息</param>
        private void ServerSendMsg(string sendMsg)
        {
            //将输入的字符串转换成 机器可以识别的字节数组
            byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendMsg);
            //向客户端发送字节数组信息
            socConnection.Send(arrSendMsg);
            //将发送的字符串信息附加到文本框txtMsg上
            txtMsg.AppendText("本机" + GetCurrentTime() + "\r\n" + sendMsg + "\r\n");
        }

        /// <summary>
        /// 接收客户端发来的信息 
        /// </summary>
        /// <param name="socketClientPara">客户端套接字对象</param>
        private void ServerRecMsg(object socketClientPara)
        {
            Socket socketServer = socketClientPara as Socket;
            bool flag = false;
            while (true)
            {
                //创建一个内存缓冲区 其大小为1024*1024字节  即1M
                byte[] arrServerRecMsg = new byte[1024 * 1024];
                //将接收到的信息存入到内存缓冲区,并返回其字节数组的长度
                int length = socketServer.Receive(arrServerRecMsg);
                //将机器接受到的字节数组转换为人可以读懂的字符串
                string strSRecMsg = Encoding.UTF8.GetString(arrServerRecMsg, 0, length);
                //将发送的字符串信息附加到文本框txtMsg上  
                txtMsg.AppendText("客机" + GetCurrentTime() + "\r\n" + strSRecMsg + "\r\n");
                flag = true;
                int num = Convert.ToInt32(strSRecMsg);
                //count++;
                while (flag == true)
                {
                    ServerSendMsg((++num).ToString());
                    flag = false;
                }
            }
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            //调用 ServerSendMsg方法  发送信息到客户端
            ServerSendMsg(txtSendMsg.Text.Trim());
        }

        /// <summary>
        /// 获取当前系统时间的方法
        /// </summary>
        /// <returns>当前时间</returns>
        private DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }
    }
}
