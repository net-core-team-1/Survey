using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Authentication.Auth
{
    public class JsonWebToken
    {
        public string Token { get; set; }
        public long Expires { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string JwtId { get; set; }
        public Guid UserId { get; set; }
    }
}
