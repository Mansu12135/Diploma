using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Package;

namespace DataBaseModel
{
    internal static class Sender
    {
        private static IPEndPoint RemoteEP = new IPEndPoint(Dns.Resolve("127.0.0.1").AddressList[0], 11000);
        private static Socket Client = new Socket(AddressFamily.InterNetwork,
             SocketType.Stream, ProtocolType.Tcp);
        private static BinaryFormatter Serializer = new BinaryFormatter();

        internal static void Send(SerializableClass item)
        {
            if (!Client.Connected)
            {
                Client.Connect(RemoteEP);
            }
            using (var stream = new MemoryStream())
            {
                try
                {
                    Serializer.Serialize(stream, item);
                    Client.Send(stream.GetBuffer());
                }
                catch(Exception ex) { }
            }
        }
    }
}
