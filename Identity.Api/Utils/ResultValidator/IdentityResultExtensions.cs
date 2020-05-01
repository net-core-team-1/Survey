using Identity.Api.Exceptions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace Identity.Api.Utils.ResultValidator
{
    public static class IdentityResultExtensions
    {
        public static IdentityResult Validate(this IdentityResult result)
        {
            if (!result.Succeeded)
            {
                throw new IdentityException($"INVALID_OPERATION",
                    result.Errors.Select(x => $"CODE:{x.Code},DESC:{x.Description}").ToList().Join(" |"));
            }
            else return result;

        }
    }
}
