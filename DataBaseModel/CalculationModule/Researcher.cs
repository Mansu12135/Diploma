using System;
using System.Collections.Generic;
using Package;

namespace CalculationModule
{
    public class Researcher<T> : ICalculator where T : IData
    {
        Dictionary<string, ResearchFieldResult> ICalculator.CalculationData => vCalculationData ?? (vCalculationData = new Dictionary<string, ResearchFieldResult>());
        private Dictionary<string, ResearchFieldResult> vCalculationData;

        public delegate void OnResearchedHandler(Dictionary<string, ResearchFieldResult> processeDictionary);

        public event OnResearchedHandler ProcessedData;

        public void Calculate(IData data)
        {
            ProcessedData?.Invoke(GetCalculation(data));
        }

        private Dictionary<string, ResearchFieldResult> GetCalculation(IData data)
        {
            var dictionary = new Dictionary<string, ResearchFieldResult>();
            var serializableData = data as SerializableClass;
            if (serializableData == null) { return null; }

            ResearchFieldResult rezult;
            dictionary.Add("Location", new ResearchFieldResult { FieldValue = serializableData.Location, Level = ResearchLevel.None });
            dictionary.Add("NatureOfBattle", new ResearchFieldResult { FieldValue = null, Level = ResearchLevel.None });
            dictionary.Add("SolderID", new ResearchFieldResult { FieldValue = serializableData.SolderID, Level = ResearchLevel.None });
            dictionary.Add("DateID", new ResearchFieldResult { FieldValue = serializableData.DateID, Level = ResearchLevel.None });

            rezult = new ResearchFieldResult();
            new WeatherRezulter().GetRezult(ref rezult, serializableData.WeatherID);
            dictionary.Add("Weather", rezult);

            rezult = new ResearchFieldResult();
            new PulseRezulter(serializableData.Pulse.GetType(), "Pulse", serializableData.GetType()).GetRezult(ref rezult, serializableData);
            dictionary.Add("Pulse", rezult);

            rezult = new ResearchFieldResult();
            new AmmunittionRezulter(serializableData.BulletProofVestState.GetType(), "Ammunittions", serializableData.GetType(), 250).GetRezult(ref rezult, serializableData);
            dictionary.Add("Ammunittions", rezult);

            rezult = new ResearchFieldResult();
            new BulletProofRezulter(serializableData.BulletProofVestState.GetType(), "BulletProofVestState", serializableData.GetType()).GetRezult(ref rezult, serializableData);
            dictionary.Add("BulletProofVestState", rezult);

            return dictionary;
        }
    }
}
