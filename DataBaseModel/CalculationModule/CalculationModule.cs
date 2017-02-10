using System;
using DataBaseModel;
using FirstServer;
using Package;

namespace CalculationModule
{
    public class CalculationModule: IDisposable
    {
        private readonly Researcher<SerializableClass> Researcher = new Researcher<SerializableClass>();
        private Server Server;

        public CalculationModule()
        {
            Server = new Server();
            AttachEventHandlers();
            Server.StartServer();
            ImitateData();
        }

        private void ImitateData()
        {
            Sender.StartSend();
        }

        private void AttachEventHandlers()
        {
            DettachEventHandlers();
            Server.OnDatareceived += Researcher.Calculate;
        }

        private void DettachEventHandlers()
        {
            Server.OnDatareceived -= Researcher.Calculate;
        }

        public void Dispose()
        {
            Server.StopServer();
            DettachEventHandlers();
            Server = null;
        }

    }
}
