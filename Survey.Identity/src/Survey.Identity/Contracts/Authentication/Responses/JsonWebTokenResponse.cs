using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Contracts.Authentication.Responses
{
    public class JsonWebTokenResponse
    {
        public string Token { get; set; }
        public long Expires { get; set; }
    }
}
