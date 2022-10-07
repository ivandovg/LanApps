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
        UserConnection client;
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
                if(client != null)
                {
                    client.Disconnect();
                }
            }
            catch { }
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                btnConnect.Enabled = false;
                client = new UserConnection("User", IPAddress.Parse(edAddress.Text), (int)edPort.Value);
                client.ConnectionEstablished += Client_ConnectionEstablished;
                client.IncomingMessage += Client_IncomingMessage;
                await client.ConnectAsync();
                await client.ReadMessageAsync();
            }
            catch (Exception)
            {
                client = null;
                btnConnect.Enabled = true;
            }
        }

        private void Client_IncomingMessage(string message)
        {
            Action action = () => { lsbMessages.Items.Add(message); };
            Invoke(action);
        }

        private void Client_ConnectionEstablished(bool IsConnected)
        {
            Action action = () =>
            {
                if (IsConnected)
                {
                    btnConnect.Enabled = false;
                    grSendMessage.Enabled = true;
                }
                else
                {
                    btnConnect.Enabled = true;
                    grSendMessage.Enabled = false;
                }
            };

            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private async void btnSendMessage_Click(object sender, EventArgs e)
        {
            if ((client == null) || !client.Connected
                || string.IsNullOrEmpty(edMessage.Text))
                return;

            btnSendMessage.Enabled = false;
            await client.SendMessageAsync(edMessage.Text);
            edMessage.Text = "";
            edMessage.Focus();
            
            await client.ReadMessageAsync();
            btnSendMessage.Enabled = true;
        }
    }
}
