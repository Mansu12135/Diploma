using System;

namespace CalculationModule
{
    internal class AmmunittionRezulter : FieldRezulter
    {
        private int MaxCount;

        public AmmunittionRezulter(Type fieldType, string fieldName, Type objecType, int maxCount)
        {
            FieldType = fieldType;
            FieldName = fieldName;
            ObjecType = objecType;
            MaxCount = maxCount;
        }

        public override void GetRezult(ref ResearchFieldResult rezult, object classObject)
        {
            base.GetRezult(ref rezult, classObject);
            int val = (int) rezult.FieldValue;
            int percentage = MaxCount * 100 / val;
            if (percentage == 100)
            {
                rezult.Level = ResearchLevel.Medium;
                return;
            }
            if (percentage > 95)
            {
                rezult.Level = ResearchLevel.Low;
                return;
            }
            if (percentage > 90)
            {
                rezult.Level = ResearchLevel.UpperLow;
                return;
            }
            if (percentage > 85)
            {
                rezult.Level = ResearchLevel.LowMedium;
                return;
            }
            if (percentage > 80)
            {
                rezult.Level = ResearchLevel.UpperMedium;
                return;
            }
            if (percentage > 70)
            {
                rezult.Level = ResearchLevel.Lowhigh;
                return;
            }
            if (percentage > 60)
            {
                rezult.Level = ResearchLevel.High;
                return;
            }
            if (percentage > 50)
            {
                rezult.Level = ResearchLevel.UpperHigh;
                return;
            }
            if (percentage < 50)
            {
                rezult.Level = ResearchLevel.Critical;
                return;
            }
        }
    }
}
