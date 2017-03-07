using System;

namespace CalculationModule
{
    internal class BulletProofRezulter : FieldRezulter
    {
        public BulletProofRezulter(Type fieldType, string fieldName, Type objecType)
        {
            FieldType = fieldType;
            FieldName = fieldName;
            ObjecType = objecType;
        }

        public override void GetRezult(ref ResearchFieldResult rezult, object classObject)
        {
            base.GetRezult(ref rezult, classObject);
            int val = (int)rezult.FieldValue;
            if (val == 100)
            {
                rezult.Level = ResearchLevel.Medium;
                return;
            }
            if (val > 95)
            {
                rezult.Level = ResearchLevel.Low;
                return;
            }
            if (val > 90)
            {
                rezult.Level = ResearchLevel.UpperLow;
                return;
            }
            if (val > 85)
            {
                rezult.Level = ResearchLevel.LowMedium;
                return;
            }
            if (val > 80)
            {
                rezult.Level = ResearchLevel.UpperMedium;
                return;
            }
            if (val > 70)
            {
                rezult.Level = ResearchLevel.Lowhigh;
                return;
            }
            if (val > 60)
            {
                rezult.Level = ResearchLevel.High;
                return;
            }
            if (val > 50)
            {
                rezult.Level = ResearchLevel.UpperHigh;
                return;
            }
            if (val < 50)
            {
                rezult.Level = ResearchLevel.Critical;
                return;
            }
        }
    }
}
