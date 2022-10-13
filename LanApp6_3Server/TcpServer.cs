using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using LanApp6_2Dll;

namespace LanApp6_3Server
{
    public class TcpServer
    {
        IPEndPoint endPoint;
        TcpListener server;

        public event Action<TcpClientConnection, MessagePacket> IncomingClientMessage;
        public event Action<TcpClientConnection> ClientDisconnected;
        public event Action<TcpClientConnection> ClientConnected;
        public event Action<TcpServer, bool> ServerWorking; 

        public TcpServer(string address, int port)
        {
            endPoint = new IPEndPoint(IPAddress.Parse(address), port);
            server = null;
        }
        public Task StartServerAsync() => Task.Run(StartServer);

        public void StartServer()
        {
            if (server != null)
                return;

            server = new TcpListener(endPoint);
            server.Start(10);
            ServerWorking?.Invoke(this, true);
            try
            {
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    TcpClientConnection clientConnection = new TcpClientConnection(client);
                    clientConnection.IncomingMessage += ClientConnection_IncomingMessage;
                    clientConnection.ClientDisconnected += ClientConnection_ClientDisconnected;
                    clientConnection.DoWorkAsync();
                    ClientConnected?.Invoke(clientConnection);
                }
            }
            finally
            {
                StopServer();
            }
        }

        private void ClientConnection_ClientDisconnected(TcpClientConnection client)
        {
            ClientDisconnected?.Invoke(client);
        }

        private void ClientConnection_IncomingMessage(TcpClientConnection client, MessagePacket packet)
        {
            IncomingClientMessage?.Invoke(client, packet);
        }

        public void StopServer()
        {
            if (server == null)
                return;

            try
            {
                server.Stop();
            }
            finally
            {
                server = null;
                ServerWorking?.Invoke(this, true);
            }
        }
    }
}
