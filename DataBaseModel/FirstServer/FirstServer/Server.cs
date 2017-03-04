using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using CalculationModule;
using Package;

namespace FirstServer
{
    public class Server
    {
        private static ManualResetEvent AllDone = new ManualResetEvent(false);
        private readonly BinaryFormatter Deserealizer = new BinaryFormatter();
        private Thread ServerThread;

        public static readonly IPEndPoint LocalEndPoint = new IPEndPoint(Dns.Resolve("127.0.0.1").AddressList[0], 11000);

        public void StartServer()
        {
            ServerThread = new Thread(StartListening) { Name = "Thread for Server listening" };
            ServerThread.Start();
        }

        public void StopServer()
        {
            ServerThread.Join();
            if (ServerThread.IsAlive) { return; }
            ServerThread.Abort();
        }

        private void StartListening()
        {
            var listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(LocalEndPoint);
                listener.Listen(100);

                while (true)
                {
                    AllDone.Reset();
                    listener.BeginAccept(AcceptCallback, listener);
                    AllDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            AllDone.Set();

            var listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            var state = new State { workSocket = handler };
            handler.BeginReceive(state.buffer, 0, State.BufferSize, 0,
                ReadCallback, state);
        }

        private void ReadCallback(IAsyncResult ar)
        {
            var state = (State)ar.AsyncState;
            Socket handler = state.workSocket;

            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {

                using (var stream = new MemoryStream(state.buffer))
                {
                    SerializableClass newObject;
                    try
                    {
                        newObject = Deserealizer.Deserialize(stream) as SerializableClass;
                        if (newObject != null || OnDatareceived != null)
                        {
                            OnDatareceived.Invoke(newObject);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                handler.BeginReceive(state.buffer, 0, State.BufferSize, 0, ReadCallback, state);
            }
        }
        public delegate void ResearcherHandler(IData data);

        public event ResearcherHandler OnDatareceived;
    }
}
