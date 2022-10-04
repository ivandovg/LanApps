using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace LanApp1_1
{
    class Program1Srv
    {
        //static bool IsRun = true;
        //static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        //static CancellationToken token = new CancellationToken();
        static void Main(string[] args)
        {
            Console.Title = "Lan Test - Server";
            //Task.Factory.StartNew(StartServer, token);
            //var thread = new Thread(StartServer);
            //thread.IsBackground = true;
            //thread.Start();
            StartServer();

            Console.WriteLine("press any key...");
            Console.ReadKey();

            //IsRun = false;
            Console.WriteLine("Wait stop server...");
            //thread.Join(new TimeSpan(0, 0, 20));
        }

        static void StartServer()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1000);
            //IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, 1000);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 1000);
            socket.Bind(endPoint);
            socket.Listen(10);
            Console.WriteLine("Wait new connection...");
            socket.BeginAccept(AcceptCallback, socket);
        }

        static void AcceptCallback(IAsyncResult result)
        {
            Socket srv = result.AsyncState as Socket;
            if (srv == null)
                throw new Exception("Unknow result socket");

            Socket client = srv.EndAccept(result);
            srv.BeginAccept(AcceptCallback, srv);

            Console.WriteLine($"Accept connection: {client.RemoteEndPoint} at {DateTime.Now.ToLongTimeString()}");

            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            byte[] buffer = new byte[256];
            do
            {
                bytes = client.Receive(buffer);
                builder.Append(Encoding.UTF8.GetString(buffer, 0, bytes));
            } while (client.Available > 0);

            Console.WriteLine(builder.ToString());

            builder.Clear();
            builder.Append($"You message read at {DateTime.Now.ToLongTimeString()}");
            buffer = Encoding.UTF8.GetBytes(builder.ToString());
            client.Send(buffer);

            client.Shutdown(SocketShutdown.Both);
            client.Close();

        }

        //static void StartServer()
        //{
        //    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    //IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1000);
        //    //IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, 1000);
        //    IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 1000);
        //    socket.Bind(endPoint);
        //    socket.Listen(10);

        //    while (IsRun)
        //    {
        //        Console.WriteLine("Wait new connection...");
        //        Socket client = socket.Accept();
        //        Console.WriteLine($"Accept connection: {client.RemoteEndPoint} at {DateTime.Now.ToLongTimeString()}");
        //        //System.Threading.Thread.Sleep(60000);
        //        StringBuilder builder = new StringBuilder();
        //        int bytes = 0;
        //        byte[] buffer = new byte[256];
        //        do
        //        {
        //            bytes = client.Receive(buffer);
        //            builder.Append(Encoding.UTF8.GetString(buffer, 0, bytes));
        //        } while (client.Available > 0);

        //        Console.WriteLine(builder.ToString());

        //        builder.Clear();
        //        builder.Append($"You message read at {DateTime.Now.ToLongTimeString()}");
        //        buffer = Encoding.UTF8.GetBytes(builder.ToString());
        //        client.Send(buffer);

        //        client.Shutdown(SocketShutdown.Both);
        //        client.Close();
        //    }
        //}
    }
}
