using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Identity.Domain
{
    public class FullName : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        protected FullName()
        {

        }
        private FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public static Result<FullName> Create(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return Result.Failure<FullName>("First name should not be empty");
            if (string.IsNullOrWhiteSpace(lastName))
                return Result.Failure<FullName>("Last name should not be empty");

            firstName = firstName.Trim();
            lastName = lastName.Trim();

            if (firstName.Length > 200)
                return Result.Failure<FullName>("First name is too long");
            if (lastName.Length > 200)
                return Result.Failure<FullName>("Last name is too long");

            return Result.Success(new FullName(firstName, lastName));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
