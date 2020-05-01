using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain
{
    public class UserEmail : ValueObject
    {
        private static String EMAIL_PATTERN =
        "^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@"
        + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";

        public string Value { get; }
        protected UserEmail(string email)
        {
            Value = email;
        }
        public static Result<UserEmail> Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return Result.Failure<UserEmail>("Email should not be empty");
            if (string.IsNullOrEmpty(email))
                return Result.Failure<UserEmail>("Email should not be empty");

            var match = Regex.Match(email, EMAIL_PATTERN);
            if (!match.Success)
                return Result.Failure<UserEmail>("Invalid email format");

            return Result.Success<UserEmail>(new UserEmail(email));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
