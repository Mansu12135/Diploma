using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using DataBaseModel;
using FirstServer;
using Package;

namespace DataBaseModel
{
    public static class Sender
    {
        private static BinaryFormatter Serializer = new BinaryFormatter();

        public static void StartSend()
        {
            List<decimal> objects = DataBaseWorker.GetSoldersInTroop(DataBaseWorker.Troop);
            objects.RemoveRange(1,5);
            foreach (var obj in objects)
            {
                new Thread(() => CreateSender(obj)).Start();
                //ThreadPool.QueueUserWorkItem(CreateSender, new object[]{ objec });
            }
        }

        private static void CreateSender(decimal objectId)
        {
            new Client(objectId);
        }

        internal static void Send(SerializableClass item, Socket client)
        {
            if (!client.Connected)
            {
                client.Connect(Server.LocalEndPoint);
            }
            using (var stream = new MemoryStream())
            {
                try
                {
                    Serializer.Serialize(stream, item);
                    client.Send(stream.GetBuffer());
                }
                catch(Exception ex) { }
            }
        }
    }
}
