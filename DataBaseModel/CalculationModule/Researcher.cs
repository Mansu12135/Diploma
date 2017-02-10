using System.Collections.Generic;

namespace CalculationModule
{
    internal class Researcher<T> : ICalculator where T : IData
    {
        Dictionary<string, ResearchFieldResult> ICalculator.CalculationData => vCalculationData ?? (vCalculationData = new Dictionary<string, ResearchFieldResult>());
        private Dictionary<string, ResearchFieldResult> vCalculationData;

        public delegate void OnResearchedHandler(Dictionary<string, ResearchFieldResult> processeDictionary);

        public event OnResearchedHandler ProcessedData; 

        public void Calculate(IData data)
        {

            ProcessedData?.Invoke(vCalculationData);
        }
    }
}
