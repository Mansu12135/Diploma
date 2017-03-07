using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (weather.WindSpeed <= 20 && weather.Pressure == 760 && weather.Humidity < 70)
            {
                rezult.Level = ResearchLevel.Medium;
                return;
            }
            
        }
    }
}
