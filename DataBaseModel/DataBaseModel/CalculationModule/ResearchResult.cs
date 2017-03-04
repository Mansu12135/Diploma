
namespace CalculationModule
{
    public struct ResearchFieldResult
    {
        public object FieldValue;
        public ResearchLevel Level;
    }

    public enum ResearchLevel
    {
        None = 0,
        Low = 1,
        UpperLow = 2,
        LowMedium = 3,
        Medium = 4,
        UpperMedium = 5,
        Lowhigh = 6,
        High = 7,
        UpperHigh = 8,
        Critical = 9,
    }
}
