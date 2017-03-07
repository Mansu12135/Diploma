using System;
using System.Net.Sockets;
using System.Resources;
using System.Windows.Forms;
using DataBaseModel;
using Package;

namespace DataBaseModel
{
    internal class Client
    {
        private readonly DataGenerator Generator;
        private readonly Socket ClientSocket;

        public Client(decimal id)
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            Generator = new DataGenerator(id);
            Generator.ReceivedData += DoWork;
            while (true)
            {
                Application.DoEvents();
            }
        }

        private void DoWork(SerializableClass data)
        {
          
            Sender.Send(data, ClientSocket);
        }
    }
}
