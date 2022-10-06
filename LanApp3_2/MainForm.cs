using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace LanApp3_2
{
    public partial class MainForm : Form
    {
        TcpClient client;
        public MainForm()
        {
            client = null;
            InitializeComponent();
            FormClosing += MainForm_FormClosing;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if(client != null && client.Connected)
                {
                    NetworkStream ns = client.GetStream();
                    byte[] buffer = Encoding.UTF8.GetBytes("exit");
                    ns.Write(buffer, 0, buffer.Length);
                    System.Threading.Thread.Sleep(1000);
                    client.Close();
                }
            }
            catch { }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient();
                client.Connect(new IPEndPoint(IPAddress.Parse(edAddress.Text), (int)edPort.Value));
                Task.Run(ReadMessage);
            }
            catch (Exception)
            {
                client = null;
            }
        }

        private void ReadMessage()
        {
            if ((client == null) || !client.Connected)
                return;

            NetworkStream ns = client.GetStream();
            int bytes = 0;
            byte[] buffer = new byte[256];
            StringBuilder sb = new StringBuilder();
            do
            {
                bytes = ns.Read(buffer, 0, buffer.Length);
                sb.Append(Encoding.UTF8.GetString(buffer, 0, bytes));
            }while(ns.DataAvailable);

            Action action = () =>
            {
                lsbMessages.Items.Add($"{DateTime.Now.ToLongTimeString()}: {sb}");
                grSendMessage.Enabled = true;
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if ((client == null) || !client.Connected
                || string.IsNullOrEmpty(edMessage.Text))
                return;

            NetworkStream ns = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(edMessage.Text);
            ns.Write(buffer, 0, buffer.Length);

            Task.Run(ReadMessage);

            edMessage.Text = "";
            edMessage.Focus();
        }
    }
}
