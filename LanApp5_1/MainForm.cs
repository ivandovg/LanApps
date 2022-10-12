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
using System.IO;

namespace LanApp5_1
{
    public partial class MainForm : Form
    {
        private UdpClient senderUdp;
        private UdpClient receiver;
        public MainForm()
        {
            InitializeComponent();
            senderUdp = new UdpClient();
        }

        private async void btnSendFile_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                MessagePacket packet = new MessagePacket()
                {
                    MessageType = MessageType.File,
                    //MessageType = MessageType.Image,
                    MessageText = dlgOpen.FileName,
                    Username = edUsername.Text
                };
                var file = dlgOpen.OpenFile();
                packet.Content = new byte[file.Length];
                file.Read(packet.Content, 0, packet.Content.Length);
                file.Close();
                
                var buffer = packet.ToByteArray();

                try
                {
                    await senderUdp.SendAsync(buffer, buffer.Length, edRemoteIp.Text, (int)edRemotePort.Value);
                    Action a = () => { lsbMessages.Items.Add("File send"); };
                    Invoke(a);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void btnSendText_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(edMessage.Text))
                return;

            MessagePacket packet = new MessagePacket(edUsername.Text, edMessage.Text);
            var buffer = packet.ToByteArray(); 
            try
            {
                await senderUdp.SendAsync(buffer, buffer.Length, edRemoteIp.Text, (int)edRemotePort.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ReceiveMessage()
        {
            IPEndPoint endPoint = null;
            try
            {
                byte[] buffer;
                while (true)
                {
                    MemoryStream ms = new MemoryStream();
                    do
                    {
                        buffer = receiver.Receive(ref endPoint);
                        ms.Write(buffer, 0, buffer.Length);
                    } while (receiver.Available > 0);

                    Action a = () => CheckMessage(MessagePacket.FromByteArray(ms.ToArray()));
                    if (InvokeRequired)
                        Invoke(a);
                    else
                        a();

                    ms.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                receiver.Close();
            }
        }

        private void SaveIncomingFile(MessagePacket packet)
        {
            dlgSave.FileName = packet.MessageText;

            if (dlgSave.ShowDialog() != DialogResult.OK)
                return;

            using (FileStream file = new FileStream(dlgSave.FileName, FileMode.Create, FileAccess.Write))
            {
                file.Write(packet.Content, 0, packet.Content.Length);
            }
        }
        private void ShowImage(MessagePacket packet)
        {

            try
            {
                MemoryStream ms = new MemoryStream(packet.Content);
                pictureBox1.Image = Image.FromStream(ms);
                pictureBox1.Visible = true;
            }
            catch (Exception)
            {
                pictureBox1.Visible = false;
            }

        }
        private void CheckMessage(MessagePacket packet)
        {
            switch (packet.MessageType)
            {
                case MessageType.Text:
                    lsbMessages.Items.Add(packet.ToString());
                    break;
                case MessageType.File:
                    lsbMessages.Items.Add("Incoming file: " + packet.MessageText);
                    SaveIncomingFile(packet);
                    break;
                case MessageType.Image:
                    lsbMessages.Items.Add("Incoming image: " + packet.MessageText);
                    ShowImage(packet);
                    break;
                case MessageType.ProcessList:
                    lsbMessages.Items.Add(packet.ToString());
                    break;
                case MessageType.Other:
                    lsbMessages.Items.Add(packet.ToString());
                    break;
                default:
                    lsbMessages.Items.Add("Unknown packet");
                    break;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (receiver != null)
            {
                btnStart.Text = "Start";
                //receiver.Close();
                receiver.Dispose();
                receiver = null;
            }
            else
            {
                btnStart.Text = "Stop";
                receiver = new UdpClient((int)edLocalPort.Value);
                Task.Run(ReceiveMessage);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }
    }
}
