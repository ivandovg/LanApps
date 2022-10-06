using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace LanApp2_2AsyncClient
{
    public class AsyncTcpClient : IDisposable
    {
        Socket socket;
        IPEndPoint ipEndPoint;

        public event Action<AsyncTcpClient, bool> Connected;
        public event Action<AsyncTcpClient> Disconnected;
        public event Action<AsyncTcpClient, int> SendMessageEvent;
        public event Action<AsyncTcpClient, string> ReceiveMessage;

        public AsyncTcpClient(IPEndPoint endPoint)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ipEndPoint = endPoint;
        }
        public AsyncTcpClient(string ip, int port) : this(new IPEndPoint(IPAddress.Parse(ip), port))
        {

        }
        public void ConnectAsync()
        {
            Task.Run(Connect);
        }
        public void Connect()
        {
            if (socket.Connected)
                return;

            try
            {
                socket.Connect(ipEndPoint);
                //ClientEvent?.Invoke(this, "Connection established");
                Connected?.Invoke(this, true);
            }
            catch (Exception ex)
            {
                //ClientEvent?.Invoke(this, ex.Message);
                Connected?.Invoke(this, false);
            }
        }

        public void Disconnect()
        {
            if (!socket.Connected)
                return;

            try
            {
                socket.Shutdown(SocketShutdown.Send);
                socket.Close();
            }
            finally
            {
                Disconnected?.Invoke(this);
            }
        }

        public void SendMessage(string message)
        {
            if (string.IsNullOrEmpty(message) || !socket.Connected)
                return;

            byte[] buffer = Encoding.UTF8.GetBytes(message);
            int sending = socket.Send(buffer);

            SendMessageEvent?.Invoke(this, sending);
        }

        public void SendMessageAsync(string message)
        {
            Task.Run(() => SendMessage(message));
        }

        public void ReceiveMessages()
        {
            if (!socket.Connected)
                return;

            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            byte[] buffer = new byte[256];
            //while (socket.Connected)
            //{
            do
            {
                bytes = socket.Receive(buffer);
                builder.Append(Encoding.UTF8.GetString(buffer, 0, bytes));
            } while (socket.Available > 0);

            ReceiveMessage?.Invoke(this, builder.ToString());
            builder.Clear();
            //}
        }

        public void ReceiveMessagesAsync() => Task.Run(ReceiveMessages);

        public void Dispose()
        {
            try
            {
                Disconnect();
            }
            catch { }
        }
    }
}
