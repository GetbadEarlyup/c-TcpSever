using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using System.IO;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void Connect()
        {
            // 创建一个负责监听的Socket
            Socket socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 创建IP地址和端口号
            IPAddress ip = IPAddress.Any;
            IPEndPoint point = new IPEndPoint(ip, 8888);

            // 绑定IP地址和端口号
            socketWatch.Bind(point);

            if (label2.InvokeRequired)
            {
                Action SetText111 = delegate { LinkPass(""); };
                label2.Invoke(SetText111);
            }
            else
            {
                label2.Text = "连接成功";
            }

            Console.WriteLine("监听成功");

            // 设置监听队列
            socketWatch.Listen(10);

            // 开启一个新的线程，等待客户端的连接
            Thread th = new Thread(Listen);
            th.IsBackground = true;
            th.Start(socketWatch);
        }

        void Listen(object o)
        {
            Socket socketWatch = o as Socket;
            while (true)
            {
                // 接受客户端的连接
                Socket socketSend = socketWatch.Accept();

                if (label2.InvokeRequired)
                {
                    Action SetText111 = delegate { SetText(""); };
                    label2.Invoke(SetText111);
                }
                else
                {
                    label2.Text = "开启成功";
                }



                // 开启一个新的线程，不停地接收客户端发来的消息
                Thread th = new Thread(Receive);
                th.IsBackground = true;
                th.Start(socketSend);
            }
        }

        private void SetText(object str)
        {
            label2.Text = "连接成功";
        }

        private void LinkPass(object str)
        {
            label2.Text = "开启成功";
        }

        void Receive(object o)
        {
            Socket socketSend = o as Socket;
            while (true)
            {
                try
                {
                    // 接收客户端发来的消息
                    byte[] buffer = new byte[2048];
                    int r = socketSend.Receive(buffer);
                    if (r == 0)
                    {
                        break;
                    }
                    string str = Encoding.UTF8.GetString(buffer, 0, r);

                    if (label3.InvokeRequired)
                    {
                        Action SetText111 = delegate { showText(str); };
                        label3.Invoke(SetText111);
                    }
                    else
                    {
                        label3.Text = "开启成功";
                    }

                    
                    
                }
                catch
                {
                    break;
                }
                
            }
        }

        private void showText(string str)
        {
            label3.Text = str;
            textBox1.Text = str;
            //if (!File.Exists("log.txt"))
            //{
            //   FileStream fs = new FileStream("log.txt", FileMode.Create, FileAccess.Write);
            //}
                
                File.AppendAllText("log.txt",str);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("log.txt");
        }
    }
}
