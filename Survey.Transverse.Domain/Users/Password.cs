using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Domain.Users
{
    public class Password : ValueObject
    {
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }

        protected Password()
        {

        }
        private Password(string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            Common.Identity.Authentication.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
        public static Result<Password> Create(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return Result.Failure<Password>("password should not be empty");

            if (password.Length > 200 && password.Length < 5)
                return Result.Failure<Password>("Password is too long");

            return Result.Success(new Password(password));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PasswordHash;
            yield return PasswordSalt;
        }
    }
}
