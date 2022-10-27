using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using LanApp6_2Dll;

namespace LanAppFileServer
{
    public class TcpFileClient
    {
        static int count = 0;
        int clientId;
        TcpClient client;
        string directoryPath;

        public event Action<TcpFileClient, string> ClientAction;

        public TcpFileClient(TcpClient tcpClient, string path)
        {
            clientId = ++count;
            client = tcpClient;
            directoryPath = path;
        }

        public void DoWork()
        {
            string[] files = Directory.GetFiles(directoryPath).Select(f => Path.GetFileName(f)).ToArray();

            NetworkStream stream = client.GetStream();
            try
            {
                MessagePacket message = new MessagePacket()
                {
                    MessageType = MessageType.List,
                    Data = files
                };
                message.ToStream(stream);
                // close - закрыть подключение

                while (true)
                {
                    try
                    {
                        message = MessagePacket.FromStream(stream);
                        switch (message.MessageType)
                        {
                            case MessageType.Text:
                                if (message.MessageText.ToLower().Equals("close"))
                                {
                                    ClientAction?.Invoke(this, "Disconnected!");
                                    System.Threading.Thread.Sleep(500);
                                    return;
                                }
                                else
                                    goto default;
                            case MessageType.File:
                                try
                                {
                                    using (FileStream fs = new FileStream(Path.Combine(directoryPath, message.MessageText), FileMode.Open, FileAccess.Read))
                                    {
                                        message = new MessagePacket()
                                        {
                                            MessageType = MessageType.File
                                        };
                                        message.Content = new byte[fs.Length];
                                        fs.Read(message.Content, 0, message.Content.Length);
                                        message.ToStream(stream);
                                        stream.Flush();
                                        ClientAction?.Invoke(this, "File send complete!");
                                    }
                                }
                                catch (FileNotFoundException ex)
                                {
                                    try
                                    {
                                        MessagePacket packet = new MessagePacket()
                                        {
                                            MessageType = MessageType.Text,
                                            MessageText = ex.Message
                                        };
                                        packet.ToStream(stream);
                                    }
                                    catch { }
                                    ClientAction?.Invoke(this, ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    ClientAction?.Invoke(this, ex.Message);
                                }

                                break;
                            case MessageType.List:
                                message = new MessagePacket()
                                {
                                    MessageType = MessageType.List,
                                    Data = files
                                };
                                message.ToStream(stream);
                                break;
                            default:
                                ClientAction?.Invoke(this, "Unknown command!");
                                break;
                        }
                    }
                    catch(Exception ex)
                    {
                        if (stream == null)
                            ClientAction?.Invoke(this, $"Close connection ({ex.Message})");
                        else
                            ClientAction?.Invoke(this, ex.Message);
                        
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                ClientAction?.Invoke(this, ex.Message);
            }
        }

        public Task DoWorkAsync() => Task.Run(DoWork);

        public override string ToString()
        {
            return $"Client {clientId} ({client.Client.RemoteEndPoint})";
        }
    }
}
