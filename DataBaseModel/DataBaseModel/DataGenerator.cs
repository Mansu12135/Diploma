using Package;
using Timer = System.Windows.Forms.Timer;

namespace DataBaseModel
{
    internal class DataGenerator
    {
        private Timer Timer;
        private int Count = 1;
        private decimal ObjectId;

        public static int Tick = 5000; 

        public DataGenerator(decimal objectId)
        {
            ObjectId = objectId;
            Timer = new Timer { Interval = Tick, Enabled = true };
            Timer.Tick += OnDataReceived;
            Timer.Start();
        }

        private void OnDataReceived(object sender, System.EventArgs e)
        {
            ReceivedData?.Invoke(DataBaseWorker.GetDataByNumber(ObjectId, Count));
            Count++;
        }

        public delegate void GetsData(SerializableClass data);

        public event GetsData ReceivedData; 
    }
}
