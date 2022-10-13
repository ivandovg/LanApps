using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using LanApp6_2Dll;
using System.IO;

namespace LanApp6_3Server
{
    public class TcpClientConnection
    {
        static int count = 0;
        private int clientId;
        public int ClientId => clientId;

        TcpClient connection;

        public event Action<TcpClientConnection, MessagePacket> IncomingMessage;
        public event Action<TcpClientConnection> ClientDisconnected;

        public TcpClientConnection(TcpClient client)
        {
            connection = client;
            clientId = ++count;
        }
        public override string ToString()
        {
            return "Connection Id: " + clientId.ToString();
        }
        private static MessagePacket messageDelivered = new MessagePacket("server", "Message delivered!");
        public void DoWork()
        {
            if (connection == null || !connection.Connected)
                return;

            NetworkStream ns = connection.GetStream();

            MessagePacket packet = new MessagePacket("server", "Hello");
            packet.ToStream(ns);

            try
            {
                while (true)
                {
                    packet = MessagePacket.FromStream(ns);
                    if (packet != null && packet.MessageText.ToLower().Equals("close"))
                        break;
                    else
                    {
                        IncomingMessage?.Invoke(this, packet);
                        messageDelivered.ToStream(ns);
                    }
                }
            }
            finally
            {
                ClientDisconnected?.Invoke(this);
            }

        }

        public Task DoWorkAsync() => Task.Run(DoWork);
    }
}
