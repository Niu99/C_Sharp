using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketTrans
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 关闭对文本框的非法线程操作检查
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }
        //创建 1个客户端套接字
        Socket socketClient = null;

        //定义相对应的数据结构
        public struct DMA_WRITE
        {
            public UInt32 uiCmd;//DMA发数到FPGA,1
            public UInt32 uiLength;//消息总长度，包含消息头
            public byte[] ucData;//DMA数据
        }
        public struct DMA_READ
        {
            public UInt32 uiCmd;//DMA从FPGA读数
            public UInt32 uiLength;//消息总长度，包含消息头
            public UInt32 uiDmaLength;//DMA读数长度
        }
        public struct LITE_WRITE
        {
            public UInt32 uiCmd;//lite写DMA寄存器
            public UInt32 uiLength;//消息总长度，包含消息头
            public UInt32 uiAddr;//寄存器号
            public UInt32 uiData;//寄存器值
        }
        public struct LITE_READ
        {
            public UInt32 uiCmd;//lite读DMA寄存器
            public UInt32 uiLength;//消息总长度，包含消息头
            public UInt32 uiAddr;//寄存器号
        }
        public struct BOOT_Upgrade
        {
            public UInt32 uiCmd;//升级BOOT.BIN
            public UInt32 uiLength;//消息总长度，包含消息头
            public byte[] ucData;//boot.bin数据
        }

        /// <summary>
        /// TCP连接服务器端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //定义一个套字节监听  包含3个参数(IP4寻址协议,流式连接,TCP协议)
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //需要获取文本框中的IP地址
            IPAddress ipaddress = IPAddress.Parse(txtIP.Text.Trim());
            //将获取的ip地址和端口号绑定到网络节点endpoint上
            IPEndPoint endpoint = new IPEndPoint(ipaddress, int.Parse(txtPort.Text.Trim()));
            //这里客户端套接字连接到网络节点(服务端)用的方法是Connect 而不是Bind
            socketClient.Connect(endpoint);
            ////创建一个线程 用于监听服务端发来的消息
            //threadClient = new Thread(RecMsg);
            ////将窗体线程设置为与后台同步
            //threadClient.IsBackground = true;
            ////启动线程
            //threadClient.Start();
            if (socketClient.Connected)
            {
                MessageBox.Show("连接成功！");
            }
            Thread threadreceive = new Thread(RecMsg);
            threadreceive.Start();
            threadreceive.IsBackground = true;
        }

        /// <summary>
        /// 接收服务端发来信息的方法
        /// </summary>
        private void RecMsg()
        {
            while (true)
            {
                //定义一个1M的内存缓冲区 用于临时性存储接收到的信息
                byte[] arrRecMsg = new byte[1024 * 1024 * 1024];
                //将客户端套接字接收到的数据存入内存缓冲区, 并获取其长度
                int length = socketClient.Receive(arrRecMsg);
                int[] RecMess = new int[length];
                string mess = "";
                //将套接字获取到的字节数组转换为人可以看懂的字符串
                for (int i = 0; i < length; i++)
                {
                    RecMess[i] = arrRecMsg[i];
                    if (i % 4 == 1 || i % 4 == 3)
                    {
                        mess += RecMess[i].ToString("X2") + "\t";
                    }
                    else
                    {
                        mess += RecMess[i].ToString("X2");
                    }
                }
                richtxtResult.AppendText("收到的反馈:" + GetCurrentTime() + "\n" + mess + "\n");

                if (RecMess[0] == 0x00000001 && RecMess[4] == 0x00000008)//收到的数据是0100 0000 0800 0000时表明写入数据成功
                {
                    //在写入数据成功的情况下，进行DMA数据的读取
                    List<byte> read = new List<byte>();
                    DMA_READ _dma_read;
                    //编号2表示从DMA读数
                    _dma_read.uiCmd = 2;
                    byte[] _dma_read_uiCmd = BitConverter.GetBytes(_dma_read.uiCmd);
                    read.AddRange(_dma_read_uiCmd);
                    //消息长度为12
                    _dma_read.uiLength = 12;
                    byte[] _dma_read_uiLength = BitConverter.GetBytes(_dma_read.uiLength);
                    read.AddRange(_dma_read_uiLength);
                    //DMA读数的长度
                    string tmplength = txtLength.Text;
                    int readlength = Convert.ToInt32(tmplength, 16) - 8;
                    _dma_read.uiDmaLength = Convert.ToUInt32(readlength);//需要发送的消息的总长度
                    byte[] _dma_read_uiDmaLength = BitConverter.GetBytes(_dma_read.uiDmaLength);
                    read.AddRange(_dma_read_uiDmaLength);
                    //发送指令
                    byte[] _dma_read_send = read.ToArray();
                    socketClient.Send(_dma_read_send);
                }
            }
        }

        /// <summary>
        /// DMA数据读写功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDMA_Click(object sender, EventArgs e)
        {
            DMA_WRITE _dma_write;
            //执行编号
            _dma_write.uiCmd = 1;
            string tmplength = txtLength.Text;
            int length = Convert.ToInt32(tmplength, 16);
            _dma_write.uiLength = Convert.ToUInt32(length);//需要发送的消息的总长度
            //将写DMA的数据转换成byte类型进行发送
            List<byte> ts = new List<byte>();
            //编号
            byte[] _dma_write_uiCmd = BitConverter.GetBytes(_dma_write.uiCmd);
            ts.AddRange(_dma_write_uiCmd);
            //要发送的数据长度
            byte[] _dma_write_length = BitConverter.GetBytes(_dma_write.uiLength);
            ts.AddRange(_dma_write_length);
            //发送的数据
            //产生相应长度的递增数
            int[] _data = new int[length - 8];
            List<byte> Bdata = new List<byte>();
            for (int i = 0; i < length - 8; i++)
            {
                _data[i] = i;
                byte[] tmpdata = BitConverter.GetBytes(_data[i]);
                Bdata.AddRange(tmpdata);
            }
            ts.AddRange(Bdata);
            byte[] _dma_write_send = ts.ToArray();
            socketClient.Send(_dma_write_send);
        }

        /// <summary>
        /// REG写寄存器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnREGWrite_Click(object sender, EventArgs e)
        {
            LITE_WRITE _lite_write;
            //3表示执行寄存器写的功能
            _lite_write.uiCmd = 3;
            //获取寄存器号,即寄存器地址
            string tmpaddr = txtADDR.Text;
            int Addr = Convert.ToInt32(tmpaddr, 16);
            _lite_write.uiAddr = Convert.ToUInt32(Addr);
            //获取要写入寄存器的值
            string tmpdata = txtData.Text;
            int Data = Convert.ToInt32(tmpdata, 16);
            _lite_write.uiData = Convert.ToUInt32(Data);
            //写入寄存器的数据的长度
            _lite_write.uiLength = 16;
            //转换成byte
            List<byte> ts = new List<byte>();
            //指令值
            byte[] _lite_write_uiCmd = BitConverter.GetBytes(_lite_write.uiCmd);
            ts.AddRange(_lite_write_uiCmd);
            //消息总长度
            byte[] _lite_write_length = BitConverter.GetBytes(_lite_write.uiLength);
            ts.AddRange(_lite_write_length);
            //寄存器号
            byte[] _lite_write_uiAddr = BitConverter.GetBytes(_lite_write.uiAddr);
            ts.AddRange(_lite_write_uiAddr);
            //寄存器值
            byte[] _lite_write_uiData = BitConverter.GetBytes(_lite_write.uiData);
            ts.AddRange(_lite_write_uiData);
            byte[] _lite_write_send = ts.ToArray();
            socketClient.Send(_lite_write_send);
        }

        /// <summary>
        /// REG读寄存器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnREGRead_Click(object sender, EventArgs e)
        {
            LITE_READ _lite_read;
            //3表示执行寄存器写的功能
            _lite_read.uiCmd = 4;
            //获取寄存器号,即寄存器地址
            string tmpaddr = txtADDR.Text;
            int Addr = Convert.ToInt32(tmpaddr, 16);
            _lite_read.uiAddr = Convert.ToUInt32(Addr);
            //写入寄存器的数据的长度
            _lite_read.uiLength = 12;
            //转换成byte
            List<byte> ts = new List<byte>();
            //指令值
            byte[] _lite_write_uiCmd = BitConverter.GetBytes(_lite_read.uiCmd);
            ts.AddRange(_lite_write_uiCmd);
            //消息总长度
            byte[] _lite_write_length = BitConverter.GetBytes(_lite_read.uiLength);
            ts.AddRange(_lite_write_length);
            //寄存器号
            byte[] _lite_write_uiAddr = BitConverter.GetBytes(_lite_read.uiAddr);
            ts.AddRange(_lite_write_uiAddr);
            byte[] _lite_write_send = ts.ToArray();
            socketClient.Send(_lite_write_send);
        }

        /// <summary>
        /// 选择bin文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBinSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "所有文件(*.*)|*.bin";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filepath = openFileDialog.FileName;
                    txtPath.Text = filepath;
                }
                catch
                {
                    MessageBox.Show("文件打开失败！");
                }
            }
        }

        /// <summary>
        /// 传输bin文件进行升级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBinUpgrade_Click(object sender, EventArgs e)
        {
            BOOT_Upgrade _boot_upgrade;
            //指令5
            _boot_upgrade.uiCmd = 5;
            List<byte> ts = new List<byte>();
            //指令值
            byte[] _boot_upgrade_uiCmd = BitConverter.GetBytes(_boot_upgrade.uiCmd);
            ts.AddRange(_boot_upgrade_uiCmd);

            //根据选定的bin文件路径对bin文件进行传输
            string filepath = txtPath.Text;
            byte[] bin;
            //读取bin文件到byte数组
            using (FileStream fs = File.OpenRead(filepath))
            {
                bin = new byte[fs.Length];
                byte[] b = new byte[1024];
                int i = 0;
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    for (int j = 0; j < 1024; j++)
                    {
                        if (i * 1024 + j < bin.Length)
                        {
                            bin[i * 1024 + j] = b[j];
                        }

                    }
                    i++;
                }
                fs.Close();
                fs.Dispose();
                //消息总长度
                _boot_upgrade.uiLength = Convert.ToUInt32(bin.Length + 8);
            }
            //消息总长度
            byte[] _boot_upgrade_length = BitConverter.GetBytes(_boot_upgrade.uiLength);
            ts.AddRange(_boot_upgrade_length);
            _boot_upgrade.ucData = new byte[bin.Length];
            _boot_upgrade.ucData = bin;
            ts.AddRange(_boot_upgrade.ucData);
            byte[] _boot_upgrade_send = ts.ToArray();
            socketClient.Send(_boot_upgrade_send);
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
