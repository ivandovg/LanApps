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

namespace LanApp6_1
{
    public partial class MainForm : Form
    {
        UdpClient senderUdp = null; // new UdpClient();
        UdpClient receiverUdp = null;
        IPEndPoint senderEP = null;
        bool IsConnected = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                senderUdp = new UdpClient();
                senderEP = new IPEndPoint(IPAddress.Parse(edRemoteIp.Text), (int)edLocalPort.Value);
                IsConnected = true;
                Task.Run(ReceiveMessage);
                // after connection
                grUserinfo.Enabled = false;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                grSendMessage.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                IsConnected = false;

                senderUdp.Close();
                senderUdp = null;
                //receiverUdp.Close();
            }
            finally
            {
                grUserinfo.Enabled = true;
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                grSendMessage.Enabled = false;
            }
        }

        private void btnSendText_Click(object sender, EventArgs e)
        {
            if (senderUdp == null)
                return;

            btnSendText.Enabled = false;
            byte[] buffer = Encoding.UTF8.GetBytes($"{edUsername.Text} >> {edMessage.Text}");
            senderUdp.Send(buffer, buffer.Length, senderEP);
            btnSendText.Enabled = true;
            edMessage.Focus();
        }

        private void ReceiveMessage()
        {
            receiverUdp = new UdpClient((int)edLocalPort.Value);
            receiverUdp.JoinMulticastGroup(IPAddress.Parse(edRemoteIp.Text), 50);
            IPEndPoint remoteIp = null;
            string localIp = LocalIPAddress();
            try
            {
                byte[] buffer;

                while (IsConnected)
                {
                    buffer = receiverUdp.Receive(ref remoteIp);
                    string message = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                    //if (remoteIp.Address.ToString().Equals(localIp))
                    //    continue;

                    Action action = () => lsbMessages.Items.Add($"{remoteIp.Address}: {message}");
                    Invoke(action);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
            finally
            {
                receiverUdp.DropMulticastGroup(IPAddress.Parse(edRemoteIp.Text));
                receiverUdp.Close();
                receiverUdp = null;
            }
        }

        private static string LocalIPAddress()
        {
            string localIP = "";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

    }
}
