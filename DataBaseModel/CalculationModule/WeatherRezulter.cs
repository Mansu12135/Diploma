using System;
using Package;

namespace CalculationModule
{
    internal class WeatherRezulter : FieldRezulter
    {
        public override void GetRezult(ref ResearchFieldResult rezult, object classObject)
        {
            var weather = classObject as Weather;
            rezult.FieldValue = weather;
            if (weather == null)
            {
                rezult.Level = ResearchLevel.None;
                return;
            }
            if (weather.WindSpeed <= 5 && Math.Abs(weather.Pressure - 760) < 5 && weather.Humidity < 70 && 24 - weather.Tempherature <= 2)
            {
                rezult.Level = ResearchLevel.Medium;
                return;
            }
            if (weather.WindSpeed - 5 <= 10 && Math.Abs(weather.Pressure - 760) < 10 && 75 - weather.Humidity < 5 && Math.Abs(weather.Tempherature) < 5)
            {
                rezult.Level = ResearchLevel.Low;
                return;
            }
            if (weather.WindSpeed - 5 <= 20 && Math.Abs(weather.Pressure - 760) < 15 && 80 - weather.Humidity < 5 && Math.Abs(weather.Tempherature) < 7)
            {
                rezult.Level = ResearchLevel.UpperLow;
                return;
            }
            if (weather.WindSpeed - 5 <= 30 && Math.Abs(weather.Pressure - 760) < 20 && 85 - weather.Humidity < 5 && Math.Abs(weather.Tempherature) < 10)
            {
                rezult.Level = ResearchLevel.LowMedium;
                return;
            }
            if (weather.WindSpeed - 5 <= 40 && Math.Abs(weather.Pressure - 760) < 25 && 90 - weather.Humidity < 5 && Math.Abs(weather.Tempherature) < 13)
            {
                rezult.Level = ResearchLevel.UpperMedium;
                return;
            }
            if (weather.WindSpeed - 5 <= 50 && Math.Abs(weather.Pressure - 760) < 27 && 95 - weather.Humidity < 5 && Math.Abs(weather.Tempherature) < 15)
            {
                rezult.Level = ResearchLevel.Lowhigh;
                return;
            }
            if (weather.WindSpeed - 5 <= 50 && Math.Abs(weather.Pressure - 760) < 28 && 97 - weather.Humidity < 5 && Math.Abs(weather.Tempherature) < 15)
            {
                rezult.Level = ResearchLevel.High;
                return;
            }
            if (weather.WindSpeed - 5 > 50 && Math.Abs(weather.Pressure - 760) > 28 && 100 - weather.Humidity < 3 && Math.Abs(weather.Tempherature) > 15)
            {
                rezult.Level = ResearchLevel.UpperHigh;
                return;
            }
        }
    }
}
