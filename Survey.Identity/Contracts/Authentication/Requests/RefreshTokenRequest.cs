using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Contracts
{
   public class RefreshTokenRequest
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
