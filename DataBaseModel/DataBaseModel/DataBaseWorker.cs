using System.Collections.Generic;
using System.Linq;
using DataBaseModel;
using Package;

namespace DataBaseModel
{
    internal static class DataBaseWorker
    {
        private static readonly object Locker = new object();
        private static readonly DemoDataofTroopEntities DataBase = new DemoDataofTroopEntities();

        public static string Troop => DataBase.Tasks.First().Troop;

        public static List<decimal> GetSoldersInTroop(string troop)
        {
            return string.IsNullOrEmpty(troop) ? new List<decimal>() : DataBase.Troops.Where(item => item.TroopId == troop).Select(item => item.Solder).ToList();
        }

        public static SerializableClass GetDataByNumber(decimal solderId, int n)
        {
            lock (Locker)
            {
                if (!DataBase.TaskStack.Any(item => item.DateID == n && item.SolderID == solderId))
                {
                    n = 1;
                }
                TaskStack data = DataBase.TaskStack.First(item => item.DateID == n && item.SolderID == solderId);
                return new SerializableClass
                {
                    Ammunittions = data.Ammunittions,
                    DateID = data.DateID,
                    BulletProofVestState = data.BulletProofVestState,
                    FlickerEyes = data.FlickerEyes,
                    Pulse = data.Pulse,
                    SolderID = data.SolderID,
                    TemperatureBarell = data.TemperatureBarell,
                    Location = data.Location.AsText(),
                    WeatherID = new Package.Weather { Humidity = data.Weather.Humidity, WindSpeed = data.Weather.WindSpeed, Pressure = data.Weather.Pressure, WeatherID = data.Weather.WeatherID, Tempherature = data.Weather.Tempherature }
                };
            }
        }

        public static int GetCountOfDataBySolder(decimal solderId)
        {
            return DataBase.TaskStack.Where(item => item.SolderID == solderId).Max(item=>item.DateID);
        }
    }
}
