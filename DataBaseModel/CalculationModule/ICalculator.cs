
using System.Collections.Generic;

namespace CalculationModule
{
    internal interface ICalculator
    {
        Dictionary<string, ResearchFieldResult> CalculationData { get; }
        void Calculate(IData data);
    }
}
