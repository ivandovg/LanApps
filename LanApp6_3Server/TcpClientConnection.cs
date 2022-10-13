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
        TcpClient connection;

        public event Action<TcpClientConnection, MessagePacket> IncomingMessage;
        public event Action<TcpClientConnection> ClientDisconnected;

        public TcpClientConnection(TcpClient client)
        {
            connection = client;
        }

        public void DoWork()
        {
            if (connection != null || !connection.Connected)
                return;

            NetworkStream ns = connection.GetStream();

            MessagePacket packet = new MessagePacket("server", "Hello");
            byte[] buffer = packet.ToByteArray();
            ns.Write(buffer, 0, buffer.Length);
            int bytes;
            while (true)
            {
                buffer = new byte[1024];
                MemoryStream ms = new MemoryStream();
                do
                {
                    bytes = ns.Read(buffer, 0, buffer.Length);
                    ms.Write(buffer, 0, bytes);
                } while (ns.DataAvailable);

                packet = MessagePacket.FromStream(ms);
                IncomingMessage?.Invoke(this, packet);

                packet = new MessagePacket("server", "Message delivered");
                buffer = packet.ToByteArray();
                ns.Write(buffer, 0, buffer.Length);

                if (packet.MessageText.ToLower().Equals("close"))
                    break;
            }

            ClientDisconnected?.Invoke(this);
        }

        public Task DoWorkAsync() => Task.Run(DoWork);
    }
}
