using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Survey.Transverse.Domain.Users
{
    public class Email : ValueObject
    {
        public string EmailAdress { get; private set; }
        protected Email()
        {

        }

        private Email(string emailAdress)
        {
            EmailAdress = emailAdress;
        }

        public static Result<Email> Create(string emailAdress)
        {
            if (string.IsNullOrWhiteSpace(emailAdress))
                return Result.Failure<Email>("Email should not be empty");

            emailAdress = emailAdress.Trim();

            if (emailAdress.Length > 200)
                return Result.Failure<Email>("Email is too long");

            if (!Regex.IsMatch(emailAdress, @"^(.+)@(.+)$"))
                return Result.Failure<Email>("Email is invalid");

            return Result.Success(new Email(emailAdress));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EmailAdress;
        }

        public static implicit operator string(Email email)
        {
            return email.EmailAdress;
        }
    }
}
