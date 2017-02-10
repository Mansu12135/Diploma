using System.Collections.Generic;
using System.Linq;
using DataBaseModel;

namespace DataBaseModel
{
    internal static class DataBaseWorker
    {
        private static readonly DemoDataofTroopEntities DataBase = new DemoDataofTroopEntities();

        public static string Troop => DataBase.Tasks.First().Troop;

        public static List<decimal> GetSoldersInTroop(string troop)
        {
            return string.IsNullOrEmpty(troop) ? new List<decimal>() : DataBase.Troops.Where(item => item.TroopId == troop).Select(item => item.Solder).ToList();
        }

        public static TaskStack GetDataByNumber(decimal solderId, int n)
        {
            return DataBase.TaskStack.First(item => item.DateID == n && item.SolderID == solderId);
        }

        public static int GetCountOfDataBySolder(decimal solderId)
        {
            return DataBase.TaskStack.Where(item => item.SolderID == solderId).Max(item=>item.DateID);
        }
    }
}
