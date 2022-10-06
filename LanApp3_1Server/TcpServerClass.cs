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
        public event Action<string> MessageString;
        public TcpServerClass(IPAddress address, int port)
        {
            listener = new TcpListener(address, port);
        }

        public Task StartServerAsync() => Task.Run(StartServer);

        public void StartServer()
        {
            try
            {
                listener.Start(100);
                while (true)
                {
                    MessageString?.Invoke("Wait connection...");
                    TcpClient client = listener.AcceptTcpClient();
                    MessageString?.Invoke($"Accept connection: {client.Client.RemoteEndPoint}");
                    NetworkStream ns = client.GetStream();

                    byte[] buffer = Encoding.UTF8.GetBytes("Hello, current time " + DateTime.Now.ToLongTimeString());

                    ns.Write(buffer, 0, buffer.Length);

                    client.Close();
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
    }
}
