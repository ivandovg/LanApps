using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanApp3_1Server
{
    class ProgramSrv
    {
        static void Main(string[] args)
        {
            Console.Title = "Lan Test - TcpListener (Server)";
            Console.Write("Enter port number: ");
            int port;
            port = int.Parse(Console.ReadLine());
            TcpServerClass tcpServer = new TcpServerClass(System.Net.IPAddress.Any, port);
            tcpServer.MessageString += TcpServer_MessageString;

            Task server = tcpServer.StartServerAsync();

            Console.WriteLine("press ENTER for exit...");
            Console.ReadLine();
        }

        private static void TcpServer_MessageString(string message)
        {
            Console.WriteLine(message);
        }
    }
}