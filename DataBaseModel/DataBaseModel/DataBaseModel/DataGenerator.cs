using System.Linq;
using System.Timers;
using Timer = System.Windows.Forms.Timer;

namespace DataBaseModel
{
    internal class DataGenerator
    {
        private Timer Timer;
        private readonly DemoDataofTroopEntities DB;
        private int Count = 1;

        public DataGenerator(int tick)
        {
            DB = new DemoDataofTroopEntities();
            Timer = new Timer { Interval = tick, Enabled = true };
            Timer.Tick += OnDataReceived;
            Timer.Start();
        }

        private void OnDataReceived(object sender, System.EventArgs e)
        {
            ReceivedData?.Invoke(DB.TaskStack.FirstOrDefault(item => item.DateID == Count));
            Count++;
        }

        public delegate void GetsData(TaskStack data);

        public event GetsData ReceivedData; 
    }
}
