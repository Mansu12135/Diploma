using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationModule
{
    internal class PulseRezulter : FieldRezulter
    {
        public PulseRezulter(Type fieldType, string fieldName, Type objecType)
        {
            FieldType = fieldType;
            FieldName = fieldName;
            ObjecType = objecType;
        }

        public override void GetRezult(ref ResearchFieldResult rezult, object classObject)
        {
            base.GetRezult(ref rezult, classObject);
            int val = (int)rezult.FieldValue;
            if (val >= 60 && val <= 70)
            {
               rezult.Level = ResearchLevel.Medium;
               return;
            }
            if (val < 60)
            {
                if (60 - val <= 5)
                {
                    rezult.Level = ResearchLevel.LowMedium;
                    return;
                }
                if (60 - val <= 10)
                {
                    rezult.Level = ResearchLevel.UpperLow;
                    return;
                }
                if (60 - val <= 15)
                {
                    rezult.Level = ResearchLevel.LowMedium;
                    return;
                }
                if (60 - val <= 20)
                {
                    rezult.Level = ResearchLevel.Low;
                    return;
                }
            }
            else if (val > 70)
            {
                if (val - 70 <= 5)
                {
                    rezult.Level = ResearchLevel.UpperMedium;
                    return;
                }
                if (val - 70 <= 10)
                {
                    rezult.Level = ResearchLevel.Lowhigh;
                    return;
                }
                if (val - 70 <= 15)
                {
                    rezult.Level = ResearchLevel.High;
                    return;
                }
                if (val - 70 <= 20)
                {
                    rezult.Level = ResearchLevel.UpperHigh;
                    return;
                }
            }
        }
    }
}
