using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using LanApp6_2Dll;

namespace LanAppFileClient
{
    public partial class MainFormFileClient : Form
    {
        TcpClient client;
        NetworkStream stream;
        public MainFormFileClient()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            client.Connect(IPAddress.Parse(edAddress.Text), (int)edPort.Value);
            stream = client.GetStream();
            edAddress.Enabled = false;
            edPort.Enabled = false;
            lsbList.Items.Clear();
            MessagePacket message = MessagePacket.FromStream(stream);
            string[] files = message.Data as string[];
            foreach (string n in files)
            {
                lsbList.Items.Add(System.IO.Path.GetFileName(n));
            }
        }
    }
}
