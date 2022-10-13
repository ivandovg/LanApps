using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                server = new TcpServer("127.0.0.1", (int)edPort.Value); // взять из комбобокса адрес
                server.IncomingClientMessage += Server_IncomingClientMessage;
                server.ClientDisconnected += Server_ClientDisconnected;
                server.StartServerAsync();
                grSettings.Enabled = false;
                lsbLog.Items.Clear();
            }
            catch
            {

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
            Action action = () =>
            {
                lsbLog.Items.Add(packet);
            };
            Invoke(action);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            grSettings.Enabled = true;
        }
    }
}
