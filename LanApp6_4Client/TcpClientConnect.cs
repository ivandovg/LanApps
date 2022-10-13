using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using LanApp6_2Dll;

namespace LanApp6_4Client
{
    public class TcpClientConnect
    {
        TcpClient client;
        NetworkStream stream;
        IPEndPoint endPoint;
        string username;

        public Exception InnerException { get; private set; } = null;

        public delegate void ConnectedDelegate(TcpClientConnect clientConnect, bool isConnected);
        public event ConnectedDelegate ConnectedStateChange;

        public delegate void SendCompleteDelegate(TcpClientConnect clientConnect, bool hasNoError);
        public event SendCompleteDelegate SendCompleted;

        public delegate void ReceiveMessageDelegate(TcpClientConnect clientConnect, MessagePacket packet);
        public event ReceiveMessageDelegate ReceiveMessageComplete;

        public string Username 
        {
            get => username;
            set
            {
                if (!username.Equals(value))
                    username = value;
            }
        }

        public bool Connected
        {
            get
            {
                if (client == null)
                    return false;

                return client.Connected;
            }
        }
        public TcpClientConnect(string user, string ip, int port)
        {
            client = null;
            stream = null;
            endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            username = user;
        }

        public void Connect()
        {
            if (client !=null && client.Connected)
                Disconnect();

            try
            {
                InnerException = null;
                client = new TcpClient();
                client.Connect(endPoint);
                stream = client.GetStream();
                ConnectedStateChange?.Invoke(this, client.Connected);
            }
            catch(Exception ex)
            {
                InnerException = ex;
                client = null;
                ConnectedStateChange?.Invoke(this, false);
            }
        }

        public async Task ConnectAsync() => await Task.Run(Connect);

        public void Disconnect()
        {
            try
            {
                if (client.Connected)
                {
                    (new MessagePacket("", "close")).ToStream(stream);
                    System.Threading.Thread.Sleep(100);
                    client.Close();
                }

                client.Dispose();
            }
            finally
            {
                client = null;
                ConnectedStateChange?.Invoke(this, false);
            }
        }

        public void SendMessage(MessagePacket packet)
        {
            if (client == null || !client.Connected)
            {
                InnerException = new Exception("Is not connected state!!!");
                SendCompleted?.Invoke(this, false);
                return;
            }

            try
            {
                InnerException = null;
                packet.ToStream(stream);
                SendCompleted?.Invoke(this, true);
            }
            catch (Exception ex)
            {
                InnerException = ex;
                SendCompleted?.Invoke(this, false);
            }
        }

        public async Task SendMessageAsync(MessagePacket packet) => await Task.Run(() => SendMessage(packet));
        public void ReceiveMessage()
        {
            try
            {
                ReceiveMessageComplete?.Invoke(this, MessagePacket.FromStream(stream));
            }
            catch (Exception ex)
            {
                InnerException = ex;
                ReceiveMessageComplete?.Invoke(this, null);
            }
        }
    }
}
