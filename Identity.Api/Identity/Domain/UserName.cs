using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain
{
    public class UserName : ValueObject
    {
        public string Value { get; }

        protected UserName(string value)
        {
            Value = value;
        }
        public static Result<UserName> Create(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return Result.Failure<UserName>("UserName should not be empty");
            if (string.IsNullOrEmpty(userName))
                return Result.Failure<UserName>("UserName should not be empty");
            if (userName.Length < 5)
                return Result.Failure<UserName>("UserName too short, length must be greated than 5 caraters");
            if (userName.Length > 15)
                return Result.Failure<UserName>("UserName too long, length must be less than 15 caraters");

            var userNameRegularExpression = @"^[a-zA-Z0-9]*$";
            var match = Regex.Match(userName, userNameRegularExpression);
            if (!match.Success)
                return Result.Failure<UserName>("Invalid UserName format: username must contain letters and digits only");

            return Result.Success<UserName>(new UserName(userName));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
