using CSharpFunctionalExtensions;
using Survey.Auth;
using System.Collections.Generic;

namespace Survey.Transverse.Domain.Users
{
    public class Password : ValueObject
    {

        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }


        protected Password()
        {
        }
        private Password(byte[] hash,byte[] salt)
        {
            PasswordHash = hash;
            PasswordSalt = salt;
        }
        public static Result<Password> Create(string password,IEncrypter encrypter)
        {
            if (string.IsNullOrWhiteSpace(password))
                return Result.Failure<Password>("password should not be empty");

            if (password.Length > 200 && password.Length < 5)
                return Result.Failure<Password>("Password is too long");

            byte[] passwordSalt = encrypter.GetSalt();
            byte[] passwordHash = encrypter.GetHash(password, passwordSalt);

            return Result.Success(new Password(passwordHash,passwordSalt));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PasswordHash;
            yield return PasswordSalt;
        }
    }
}
