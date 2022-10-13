using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LanApp6_2Dll
{
    [Serializable]
    public enum MessageType
    {
        Text,
        File,
        Image,
        ProcessList,
        Other
    }
    [Serializable]
    public class MessagePacket
    {
        public MessageType MessageType { get; set; }
        public string Username { get; set; }
        public string MessageText { get; set; }
        public DateTime TimeMessage { get; private set; }
        public byte[] Content { get; set; }

        public MessagePacket()
        {
            MessageType = MessageType.Text;
            TimeMessage = DateTime.Now;
            Username = "noname";
            MessageText = string.Empty;
        }
        public MessagePacket(string user, string text) : this()
        {
            Username = user;
            MessageText = text;
        }

        public override string ToString()
        {
            return $"{Username}: {MessageText} (at {TimeMessage.ToLongTimeString()})";
        }

        public byte[] ToByteArray()
        {
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, this);
            ms.Position = 0;
            return ms.ToArray();

        }
        public void ToStream(Stream stream)
        {
            bf.Serialize(stream, this);
        }
        static BinaryFormatter bf = new BinaryFormatter();
        public static MessagePacket FromByteArray(byte[] SourceArray)
        {
            MemoryStream ms = new MemoryStream(SourceArray);
            try
            {
                MessagePacket packet = bf.Deserialize(ms) as MessagePacket;
                return packet;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static MessagePacket FromStream(Stream SourceStream)
        {
            try
            {
                MessagePacket packet = bf.Deserialize(SourceStream) as MessagePacket;
                return packet;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
