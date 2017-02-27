using System;
using DataBaseModel;
using FirstServer;
using Package;

namespace CalculationModule
{
    public class Module: IDisposable
    {
        private readonly Researcher<SerializableClass> vResearcher = new Researcher<SerializableClass>();
        private Server Server;

        public Module()
        {
            Server = new Server();
            AttachEventHandlers();
            Server.StartServer();
            ImitateData();
        }

        public Researcher<SerializableClass> Researcher => vResearcher;

        private void ImitateData()
        {
            Sender.StartSend();
        }

        private void AttachEventHandlers()
        {
            DettachEventHandlers();
            Server.OnDatareceived += vResearcher.Calculate;
        }

        private void DettachEventHandlers()
        {
            Server.OnDatareceived -= vResearcher.Calculate;
        }

        public void Dispose()
        {
            Server.StopServer();
            DettachEventHandlers();
            Server = null;
        }

    }
}
