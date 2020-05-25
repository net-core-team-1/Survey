using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Survey.Auth
{
    public interface IJwtHandler
    {
        JsonWebToken Create(Guid userId);
        ClaimsPrincipal GetPrincipalClaims(string token);
    }
}
