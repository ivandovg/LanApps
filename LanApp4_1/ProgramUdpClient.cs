using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace LanApp4_1
{
    class ProgramUdpClient
    {
        static string remoteAddress; // адрес получателя
        static int remotePort; // порт получателя
        static int localPort; // порт приема
        static void Main(string[] args)
        {
            Console.Title = "UDPClient Test ";
            try
            {
                Console.Write("Local port: ");
                localPort = int.Parse(Console.ReadLine());
                Console.Write("Remote port: ");
                remotePort = int.Parse(Console.ReadLine());
                Console.Write("Remote address: ");
                remoteAddress = Console.ReadLine();

                var taskReceiver = Task.Run(ReceiveMessage);

                SendMessage();
                //Task.WaitAll(taskReceiver);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void SendMessage()
        {
            UdpClient client = new UdpClient();
            string message;
            byte[] buffer;
            int bytes;
            Console.WriteLine("Enter your message: ");
            try
            {
                while (true)
                {
                    message = Console.ReadLine();
                    if (message.ToLower().Equals("exit"))
                        break;
                    else
                    {
                        buffer = Encoding.UTF8.GetBytes(message);
                        bytes = client.Send(buffer, buffer.Length, remoteAddress, remotePort);
                        if (buffer.Length != bytes)
                        {
                            Console.WriteLine($"Warning!!! Send {bytes} from {buffer.Length} bytes!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }
            
        }
        static void ReceiveMessage()
        {
            UdpClient server = new UdpClient(localPort);
            IPEndPoint endPoint = null;
            try
            {
                byte[] buffer;
                string message;
                while (true)
                {
                    buffer = server.Receive(ref endPoint);
                    message = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                    Console.WriteLine($"{endPoint} >> {message}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                server.Close();
            }
        }
    }
}
