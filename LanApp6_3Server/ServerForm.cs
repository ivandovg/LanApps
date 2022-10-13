using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanApp6_3Server
{
    public partial class ServerForm : Form
    {
        TcpServer server = null;
        public ServerForm()
        {
            InitializeComponent();
            Load += ServerForm_Load;
            FormClosing += ServerForm_FormClosing;
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                btnStop_Click(null, null);
            }
            catch{ }
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            LocalIPAddress();
            cmbAddress.SelectedIndex = 0;
        }

        private void LocalIPAddress()
        {
            string localIP = IPAddress.Loopback.ToString();
            cmbAddress.Items.Add(localIP);

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    cmbAddress.Items.Add(ip.ToString());
                }
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                server = new TcpServer(cmbAddress.SelectedItem.ToString(), (int)edPort.Value); // взять из комбобокса адрес
                server.IncomingClientMessage += Server_IncomingClientMessage;
                server.ClientDisconnected += Server_ClientDisconnected;
                server.ServerWorking += Server_ServerWorking;
                server.ClientConnected += Server_ClientConnected;
                server.StartServerAsync();
                grSettings.Enabled = false;
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                lsbLog.Items.Clear();
            }
            catch
            {

            }
        }

        private void Server_ClientConnected(TcpClientConnection client)
        {
            Action action = () => { lsbLog.Items.Add(client); };
            Invoke(action);
        }

        private void Server_ServerWorking(TcpServer tcpServer, bool isWork)
        {
            if (isWork)
            {
                Action action = () => { Text = "Working..."; };
                Invoke(action);
            }
            else
            {
                Action action = () => { Text = "Stopped"; };
                Invoke(action);
            }
        }

        private void Server_ClientDisconnected(TcpClientConnection client)
        {
            Action action = () =>
            {
                lsbLog.Items.Add("Client Disconnected");
            };
            Invoke(action);
        }

        private void Server_IncomingClientMessage(TcpClientConnection client, LanApp6_2Dll.MessagePacket packet)
        {
            Action action;
            if (packet != null)
            {
                action = () =>lsbLog.Items.Add(packet);
            }
            else
            {
                action=()=> lsbLog.Items.Add("Unknown packet!!!");
            }
            Invoke(action);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                server.StopServer();
            }
            finally
            {
                grSettings.Enabled = true;
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }
    }
}
