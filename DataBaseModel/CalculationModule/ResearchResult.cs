
namespace CalculationModule
{
    internal struct ResearchFieldResult
    {
        public string FieldName;
        public ResearchLevel Level;
    }

    internal enum ResearchLevel
    {
        Low = 0,
        UpperLow = 1,
        LowMedium = 2,
        Medium = 3,
        UpperMedium = 4,
        Lowhigh = 5,
        High = 6,
        UpeerHigh = 7,
        Critical = 8,
    }
}
