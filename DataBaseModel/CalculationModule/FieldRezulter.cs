using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CalculationModule
{
    internal abstract class FieldRezulter
    {
        protected Type FieldType { get; set; }

        protected string FieldName { get; set; }

        protected Type ObjecType { get; set; }

        public virtual void GetRezult(ref ResearchFieldResult rezult, object classObject)
        {
            var variable = ObjecType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .Where(field => field.FieldType == FieldType && field.Name.Contains(FieldName))
                .FirstOrDefault();
            if(variable == null) { throw new Exception(); }
            rezult.FieldValue = variable.GetValue(classObject);
        }
    }
}
