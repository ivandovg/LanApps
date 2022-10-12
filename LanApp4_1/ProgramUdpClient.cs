using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LanApp4_1
{
    class ProgramUdpClient
    {
        static string username; // имя отправителя
        static string remoteAddress; // адрес получателя
        static int remotePort; // порт получателя
        static int localPort; // порт приема
        static void Main(string[] args)
        {
            Console.Title = "UDPClient Test ";
            try
            {
                Console.Write("Your name: ");
                username = Console.ReadLine();

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
            MessagePacket packet;
            int bytes;
            Console.WriteLine("Enter your message: ");
            try
            {
                while (true)
                {
                    packet = new MessagePacket(username, Console.ReadLine());
                    if (packet.MessageText.ToLower().Equals("exit"))
                        break;
                    else
                    {
                        byte[] buffer = packet.ToByteArray();
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
                while (true)
                {
                    MemoryStream ms = new MemoryStream();
                    do
                    {
                        buffer = server.Receive(ref endPoint);
                        ms.Write(buffer, 0, buffer.Length);
                    } while (server.Available > 0);

                    MessagePacket packet = MessagePacket.FromByteArray(ms.ToArray());
                    Console.WriteLine(packet);
                    ms.Close();
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
