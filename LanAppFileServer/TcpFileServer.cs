using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace LanAppFileServer
{
    public class TcpFileServer: IDisposable
    {
        public event Action<string> ServerMessage;

        TcpListener server;
        int localPort;
        string directoryPath;
        public TcpFileServer(int port, string path)
        {
            localPort = port;
            directoryPath = path;
        }

        public Task StartServerAsync() => Task.Run(StartServer);
        public void StartServer()
        {
            if (server != null)
                return;

            server = new TcpListener(new IPEndPoint(IPAddress.Any, localPort));
            server.Start(50);
            ServerMessage?.Invoke("Start server");
            try
            {
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    ServerMessage?.Invoke("Accept connection: " + client.Client.RemoteEndPoint.ToString());
                    TcpFileClient fileClient = new TcpFileClient(client, directoryPath);
                    fileClient.ClientAction += FileClient_ClientAction;
                    fileClient.DoWorkAsync();
                }
            }
            finally
            {
                Dispose();
            }
        }

        private void FileClient_ClientAction(TcpFileClient client, string message)
        {
            ServerMessage?.Invoke($"{client}: {message}");
        }

        public void Dispose()
        {
            if (server != null)
            {
                try
                {
                    server.Stop();
                    server = null;
                }
                catch { }
            }
        }
    }
}
