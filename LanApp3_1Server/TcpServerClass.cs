using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace LanApp3_1Server
{
    class TcpServerClass
    {
        TcpListener listener;
        List<TcpClientConnection> clientConnections;
        public event Action<string> MessageString;
        //public event Action<TcpClientConnection, string> ClientMessage;
        
        public TcpServerClass(IPAddress address, int port)
        {
            listener = new TcpListener(address, port);
            clientConnections = new List<TcpClientConnection>();
        }

        public Task StartServerAsync() => Task.Run(StartServer);

        public void StartServer()
        {
            try
            {
                MessageString?.Invoke("Start server...");
                listener.Start(100);
                MessageString?.Invoke("Wait connection...");
                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    MessageString?.Invoke($"Accept connection: {client.Client.RemoteEndPoint}");
                    // v1
                    //NetworkStream ns = client.GetStream();
                    //byte[] buffer = Encoding.UTF8.GetBytes("Hello, current time " + DateTime.Now.ToLongTimeString());
                    //ns.Write(buffer, 0, buffer.Length);
                    //client.Close();

                    TcpClientConnection clientConnection = new TcpClientConnection(client);
                    clientConnection.Disconnect += ClientConnection_Disconnect;
                    clientConnection.IncomingMessage += ClientConnection_IncomingMessage;
                    clientConnection.DoWorkAsync();

                    clientConnections.Add(clientConnection);
                }
            }
            catch (Exception ex)
            {
                MessageString?.Invoke(ex.Message);
            }
            finally
            {
                if (listener != null)
                {
                    listener.Stop();
                    listener = null;
                    MessageString?.Invoke("Stop server!");
                }
            }
        }

        private void ClientConnection_IncomingMessage(TcpClientConnection clientConnection, string message)
        {
            MessageString?.Invoke($"{DateTime.Now.ToLongTimeString()} {clientConnection}: {message}");
        }

        private void ClientConnection_Disconnect(TcpClientConnection clientConnection)
        {
            if (clientConnections.Contains(clientConnection))
                clientConnections.Remove(clientConnection);
        }
    }
}
