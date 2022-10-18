using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace LanApp7_1Listener
{
    class ProgramHttpListener
    {
        static HttpListener listener;
        static void Main(string[] args)
        {
            Console.Title = "HTTPListener Test";
            listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:5000/connection/");
            listener.Start();

            Task.Run(StartServer);
            Console.WriteLine("press enter for stop server...");
            Console.ReadLine();
            try
            {
                listener.Stop();
            }
            catch { }
        }

        private static void StartServer()
        {
            try
            {
                Console.WriteLine("Wait connection...");
                // ответ для клиента
                string answer = "<html><head><meta charset='utf-8'><title>Home page</title></head><body><b>Hello</b><br>Test page</body></html>";
                byte[] answerArray = Encoding.UTF8.GetBytes(answer);
                while (true)
                {
                    // ожидаем подключение
                    HttpListenerContext context = listener.GetContext();
                    // получаем запрос от клиента
                    HttpListenerRequest request = context.Request;
                    // вывод подключения
                    Console.WriteLine($"Conection: {request.RemoteEndPoint}, Hostname: {request.UserHostName}");
                    // отправка ответа
                    HttpListenerResponse response = context.Response;
                    response.ContentLength64 = answerArray.Length;
                    response.OutputStream.Write(answerArray, 0, answerArray.Length);
                    response.OutputStream.Close();
                }
            }
            finally
            {
                Console.WriteLine("Exit...");
            }
        }
    }
}
