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
using System.IO;

namespace LanAppFileClient
{
    public partial class MainFormFileClient : Form
    {
        TcpClient client;
        NetworkStream stream;
        SaveFileDialog dlgSave;
        public MainFormFileClient()
        {
            client = null;
            InitializeComponent();
            FormClosing += MainFormFileClient_FormClosing;
            dlgSave = new SaveFileDialog();
            dlgSave.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void CloseConnection()
        {
            if (client == null)
                return;

            try
            {
                lsbList.Items.Clear();
                Text = "Wait close connection...";
                MessagePacket message = new MessagePacket() { MessageType = MessageType.Text, MessageText = "close" };
                message.ToStream(stream);
                System.Threading.Thread.Sleep(1000);
            }
            catch { }
            finally
            {
                client = null;
            }
        }
        private void MainFormFileClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseConnection();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (client == null)
            {
                try
                {
                    client = new TcpClient();
                    client.Connect(IPAddress.Parse(edAddress.Text), (int)edPort.Value);
                    btnConnect.Text = "Disconnect";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR connection: " + ex.Message);
                    client = null;
                    return;
                }
                stream = client.GetStream();
                edAddress.Enabled = false;
                edPort.Enabled = false;
                lsbList.Items.Clear();
                MessagePacket message = MessagePacket.FromStream(stream);
                if (message.Data is string[])
                    lsbList.Items.AddRange(message.Data as string[]);
            }
            else
            {
                btnConnect.Text = "Connect";
                CloseConnection();
                Text = "Click 'Connect'";
            }
        }

        private void lsbList_DoubleClick(object sender, EventArgs e)
        {
            if (lsbList.SelectedIndex == ListBox.NoMatches)
                return;

            dlgSave.FileName = lsbList.SelectedItem.ToString();
            if (dlgSave.ShowDialog() != DialogResult.OK)
                return;

            MessagePacket message = new MessagePacket() { 
                MessageType = MessageType.File, 
                MessageText = lsbList.SelectedItem.ToString()
            };

            try
            {
                message.ToStream(stream);
                AcceptFile(dlgSave.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void AcceptFile(string savePath)
        {
            Text = "Wait file accept...";
            MessagePacket packet;
            try
            {
                try
                {
                    packet = MessagePacket.FromStream(stream);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR receive message packet: " + ex.Message);
                    return;
                }

                Text = "Saving accepted file...";
                try
                {
                    if (packet.MessageType != MessageType.File)
                    {
                        MessageBox.Show("ERROR receive file (server say): " + packet.MessageText);
                    }
                    else
                        using (var fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(packet.Content, 0, packet.Content.Length);
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR save file: " + ex.Message);
                }
            }
            finally
            {
                Text = "Select file to download";
            }
        }
    }
}
