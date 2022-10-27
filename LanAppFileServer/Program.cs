using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanAppFileServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "File Server";
            TcpFileServer server = new TcpFileServer(1000, @"c:\temp");
            server.ServerMessage += Server_ServerMessage;
            server.StartServerAsync();
            Console.WriteLine("press ENTER...");
            Console.ReadLine();
        }

        private static void Server_ServerMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
