using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanApp6_4Client
{
    public partial class ClientForm : Form
    {
        TcpClientConnect clientConnect;
        public ClientForm()
        {
            InitializeComponent();
            FormClosing += ClientForm_FormClosing;
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnDisconnect_Click(null, null);
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                clientConnect = new TcpClientConnect(edUsername.Text, edRemoteIp.Text, (int)edRemotePort.Value);
                clientConnect.ConnectedStateChange += ClientConnect_ConnectedStateChange;
                clientConnect.SendCompleted += ClientConnect_SendCompleted;
                clientConnect.ReceiveMessageComplete += ClientConnect_ReceiveMessageComplete;
                await clientConnect.ConnectAsync();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
                clientConnect = null;
            }
        }

        private void ClientConnect_ReceiveMessageComplete(TcpClientConnect clientConnect, LanApp6_2Dll.MessagePacket packet)
        {
            string s;
            if (packet == null)
            {
                s = $"Rceive error: {clientConnect.InnerException.Message}";
            }
            else
            {
                s = $"{packet.TimeMessage.ToLongTimeString()} >> {packet.Username}: {packet.MessageText}";
            }

            Action a = () => {
                lsbMessages.Items.Add(s);
                grSendMessage.Enabled = true;
                edMessage.Focus();
                edMessage.SelectAll();
            };
            Invoke(a);
        }

        private void ClientConnect_SendCompleted(TcpClientConnect clientConnect, bool hasNoError)
        {
            if (hasNoError)
            {
                Action a = () => { btnSendText.Enabled = true; };
                btnSendText.BeginInvoke(a);
                clientConnect.ReceiveMessage();
            }
            else
            {
                MessageBox.Show("ERROR: " + clientConnect.InnerException.Message);
            }
        }

        private void ClientConnect_ConnectedStateChange(TcpClientConnect clientConnect, bool isConnected)
        {
            Action action = () =>
            {
                btnConnect.Enabled = !isConnected;
                btnDisconnect.Enabled = isConnected;
                grUserinfo.Enabled = !isConnected;
                grSendMessage.Enabled = isConnected;
                string time = DateTime.Now.ToLongTimeString();
                lsbMessages.Items.Add(time + ((isConnected) ? ">> connection esatblished" : ">> disconnect"));
            };
            Invoke(action);

            if (isConnected)
            {
                clientConnect.ReceiveMessage();
                grSendMessage.Enabled = true;
            }
            else
                clientConnect = null;
        }

        private async void btnSendText_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(edMessage.Text))
                return;

            btnSendText.Enabled = false;
            await clientConnect.SendMessageAsync(new LanApp6_2Dll.MessagePacket(edUsername.Text, edMessage.Text));
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (clientConnect == null && !clientConnect.Connected)
                return;

            try
            {
                clientConnect.Disconnect();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }
    }
}
