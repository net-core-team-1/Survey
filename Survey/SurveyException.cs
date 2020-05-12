using System;
using System.Collections.Generic;
using System.Text;

namespace Survey
{
   public class SurveyException : Exception
    {
        public string Code { get; }

        public SurveyException()
        {
        }

        public SurveyException(string code)
        {
            Code = code;
        }

        public SurveyException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public SurveyException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public SurveyException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public SurveyException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
