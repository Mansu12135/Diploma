using System;
using CalculationModule;

namespace Package
{
    [Serializable]
    public class SerializableClass : IData

    {
        public decimal SolderID { get; set; }
        public int DateID { get; set; }
        public string Location { get; set; }
        public int Pulse { get; set; }
        public int BulletProofVestState { get; set; }
        public int FlickerEyes { get; set; }
        public int Ammunittions { get; set; }
        public double TemperatureBarell { get; set; }
        public Weather WeatherID { get; set; }
    }
    [Serializable]
    public class Weather
    {
        public int WeatherID { get; set; }
        public int Humidity { get; set; }
        public float WindSpeed { get; set; }
        public int Pressure { get; set; }
    }
}
