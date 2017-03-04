using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Package;

namespace DataBaseModel
{
    class Program
    {
        internal static bool exitFlag = false;
        static void Main(string[] args)
        {
            var a = new DataGenerator(5000);
            a.ReceivedData += A_ReceivedData;
            while (exitFlag == false)
            {
                Application.DoEvents();
            }
        }

        private static void A_ReceivedData(TaskStack data)
        {
            if (data == null)
            {
                exitFlag = true;
                return;
            }
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
            });
            Console.WriteLine(data.ToString());
        }
    }
}
