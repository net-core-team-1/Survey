using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Common.Auth
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public long ExpiryMinutes { get; set; }
        public string Issuer { get; set; }
    }
}
