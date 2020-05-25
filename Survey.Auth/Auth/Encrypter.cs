using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Survey.Auth
{
    public class Encrypter : IEncrypter
    {
        private static readonly int SaltSize = 40;
        private static readonly int DeriveBytesIterationsCount = 10000;

        public byte[] GetSalt()
        {
            var random = new Random();
            var saltBytes = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return saltBytes;
        }

        public byte[] GetHash(string value, byte[] salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(value, salt, DeriveBytesIterationsCount);

            return pbkdf2.GetBytes(SaltSize);
        }


    }
}
