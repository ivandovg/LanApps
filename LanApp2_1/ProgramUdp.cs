using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace LanApp2_1
{
    class ProgramUdp
    {
        static int localPort; // порт чтения
        static int remotePort; // порт отправки
        static IPAddress remoteIp;
        static Socket readSocket = null;
        static List<EndPoint> clients = new List<EndPoint>();

        static void Main(string[] args)
        {
            Console.Title = "Lan Test - UDP";
            Console.Write("Local port: ");
            localPort = int.Parse(Console.ReadLine());
            Console.Write("Remote port: ");
            remotePort = int.Parse(Console.ReadLine());
            Console.Write("Remote IP: ");
            remoteIp = IPAddress.Parse(Console.ReadLine());
            clients.Add(new IPEndPoint(remoteIp, remotePort));
            
            try
            {
                readSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                Task taskRead = Task.Factory.StartNew(ReadMessage);

                string message = string.Empty;
                byte[] buffer;
                Console.Write("Write your message: ");
                while (true)
                {
                    message = Console.ReadLine();
                    buffer = Encoding.UTF8.GetBytes(message);
                    //readSocket.SendTo(buffer, remoteEndPoint);
                    foreach (EndPoint ep in clients)
                    {
                        readSocket.SendTo(buffer, ep);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        static void ReadMessage()
        {
            try
            {
                IPEndPoint localEP = new IPEndPoint(IPAddress.Any, localPort);
                readSocket.Bind(localEP);

                while (true)
                {
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    byte[] buffer = new byte[256];
                    EndPoint receiveEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    do
                    {
                        bytes = readSocket.ReceiveFrom(buffer, ref receiveEndPoint);
                        builder.Append(Encoding.UTF8.GetString(buffer, 0, bytes));
                    } while (readSocket.Available > 0);

                    if (!clients.Contains(receiveEndPoint))
                        clients.Add(receiveEndPoint);
                    
                    IPEndPoint endPoint = receiveEndPoint as IPEndPoint;
                    Console.WriteLine($"Receive from {endPoint.Address}:{endPoint.Port}, Message: "+builder.ToString());
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        static void CloseConnection()
        {
            if (readSocket != null)
            {
                readSocket.Shutdown(SocketShutdown.Both);
                readSocket.Close();
                readSocket = null;
            }
        }
    }
}
