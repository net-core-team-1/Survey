using CSharpFunctionalExtensions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Survey.Identity.Domain.Entities
{
    public class FunctionalCode : ValueObject
    {
        public string Code { get;private  set; }


        protected FunctionalCode()
        {

        }
        private FunctionalCode(string code)
        {
            Code = code;
        }

        public static Result<FunctionalCode> Create(string code)
        {
            if (string.IsNullOrWhiteSpace(code) || code.Length < 3 || code.Length > 6)
                return Result.Failure<FunctionalCode>("func_code_is_not_valid");
            Regex rgx = new Regex(@"^\d{2}[a-zA-Z]{1,}$");

            if (!rgx.IsMatch(code))
                return Result.Failure<FunctionalCode>("func_code_is_not_valid");


            return Result.Success(new FunctionalCode(code));
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }
    }
}
