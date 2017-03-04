using System.Net.Sockets;

namespace FirstServer
{
    internal class State
    {
        public Socket workSocket = null;
        public const int BufferSize = 4096;
        public byte[] buffer = new byte[BufferSize];
    }
}
