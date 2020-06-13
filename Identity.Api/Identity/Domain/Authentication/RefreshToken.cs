using Identity.Api.Identity.Domain.Users;
using Survey.Authentication.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Authentication
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

        public virtual Guid UserId { get; private set; }
        public virtual AppUser User { get; private set; }

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
            UserId = webToken.UserId;
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
