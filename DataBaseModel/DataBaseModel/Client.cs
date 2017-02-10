using System;
using System.Net.Sockets;
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

        private void DoWork(TaskStack data)
        {
            Sender.Send(new SerializableClass
            {
                Ammunittions = data.Ammunittions,
                DateID = data.DateID,
                BulletProofVestState = data.BulletProofVestState,
                FlickerEyes = data.FlickerEyes,
                Pulse = data.Pulse,
                SolderID = data.SolderID,
                TemperatureBarell = data.TemperatureBarell,
                Location = data.Location.AsText()
            }, ClientSocket);
        }
    }
}
