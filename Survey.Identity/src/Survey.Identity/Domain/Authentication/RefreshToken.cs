using Survey.Auth;
using Survey.Identity.Domain.Users;
using System;
using System.Security.Cryptography;

namespace Survey.Identity.Domain.Identity
{
    public class RefreshToken
    {
        public Guid Id { get; private set; }
        public string Token { get; private set; }

        public string JwtId { get; private set; }

        public DateTime CreationDate { get; private set; }

        public DateTime ExpiryDate { get; private set; }

        public bool Used { get; private set; }

        public bool Invalidated { get; private set; }

        public byte[] Timestamp { get; private set; }

        public virtual User User { get; private set; }

        protected RefreshToken()
        {
            Token = GenerateRefreshToken();
        }

        public RefreshToken(JsonWebToken webToken)
        {
            Id = Guid.NewGuid();
            Token = webToken.Token;
            JwtId = webToken.JwtId;
            CreationDate = webToken.CreatedOn;
            ExpiryDate = webToken.ExpiryDate;
            Used = false;
            Invalidated = false;
        }
        public void Use()
        {
            Used = true;
        }
        public void Invalidate()
        {
            Invalidated = true;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }


    }

}
