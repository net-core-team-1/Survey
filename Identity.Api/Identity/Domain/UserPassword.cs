using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain
{
    public class UserPassword : ValueObject
    {
        public string Value { get; }

        private UserPassword(string password)
        {
            Value = password;
        }

        public static Result<UserPassword> Create(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return Result.Failure<UserPassword>("Password should not be empty");
            if (string.IsNullOrEmpty(password))
                return Result.Failure<UserPassword>("Password should not be empty");
            if (password.Length < 10)
                return Result.Failure<UserPassword>("Password too short, length must be greated than 10 caraters");
            if (password.Length > 20)
                return Result.Failure<UserPassword>("Password too long, length must be less than 20 caraters");
            var passwordRegularExpression = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{10,20}$";
            var match = Regex.Match(password, passwordRegularExpression);
            if (!match.Success)
                return Result.Failure<UserPassword>("Invalid password format: Password must contain at least one uppercase, " +
                    "one lowerCase, one number and one special caracter");

            return Result.Success(new UserPassword(password));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }


    }
}
