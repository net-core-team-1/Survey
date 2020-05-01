using Identity.Api.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Utils.ResultValidator
{
    public class IdentityResultValidator : IResultIdentityValidation
    {
        public void Validate(IdentityResult result)
        {
            if (!result.Succeeded)
                throw new IdentityException($"INVALID_OPERATION",
                    result.Errors.
                        Select(x => $"CODE:{x.Code},DESC:{x.Description}")
                        .Join("| ")
                        );
        }
    }
}
