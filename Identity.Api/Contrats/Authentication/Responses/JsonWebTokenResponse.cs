using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrats.Authentication
{
    public class JsonWebTokenResponse
    {
        public string Token { get; set; }
        public long Expires { get; set; }
    }
}
