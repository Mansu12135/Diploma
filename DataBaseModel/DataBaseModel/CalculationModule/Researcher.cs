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
            dictionary.Add("Location", new ResearchFieldResult { FieldValue = serializableData.Location, Level = ResearchLevel.None });
            dictionary.Add("SolderID", new ResearchFieldResult { FieldValue = serializableData.SolderID, Level = ResearchLevel.None });
            dictionary.Add("DateID", new ResearchFieldResult { FieldValue = serializableData.DateID, Level = ResearchLevel.None });
            ResearchFieldResult rezult = new ResearchFieldResult();
            new PulseRezulter(serializableData.Pulse.GetType(), "Pulse", serializableData.GetType()).GetRezult(ref rezult, serializableData);
            dictionary.Add("Pulse", rezult);
            dictionary.Add("Ammunittions", new ResearchFieldResult { FieldValue = serializableData.Ammunittions, Level = ResearchLevel.UpperLow });
            dictionary.Add("BulletProofVestState", new ResearchFieldResult { FieldValue = serializableData.BulletProofVestState, Level = ResearchLevel.UpperLow });

            return dictionary;
        }
    }
}
