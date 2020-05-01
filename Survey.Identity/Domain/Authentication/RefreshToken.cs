using Survey.Identity.Domain.Users;
using System;
using System.Security.Cryptography;

namespace Survey.Identity.Domain.Identity
{
    public class RefreshToken 
    {
        public Guid Id { get; set; }
        public string Token { get; set; }

        public string JwtId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public bool Used { get; set; }

        public bool Invalidated { get; set; }

        public byte[] Timestamp { get; private set; }

        public virtual User User { get; set; }

        protected RefreshToken() : base()
        {
            Token = GenerateRefreshToken();
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
