using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Common.Utils.CustomAttributes
{

    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public class FieldAnonymizerAttribute : Attribute
    {
        public string anonymizeValue { get; }

        public FieldAnonymizerAttribute(string anonymizeValue)
        {
            this.anonymizeValue = anonymizeValue;
        }
    }
}
