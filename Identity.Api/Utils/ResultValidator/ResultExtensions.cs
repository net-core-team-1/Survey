using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Utils.ResultValidator
{
    public static class ResultExtensions
    {
        public static Result<T> Validate<T>(this Result<T> result)
        {
            if (result.IsFailure)
                throw new IdentityException($"INVALID_FORMAT_FOR_{result.GetType().ToString()}", result.Error);
            else
                return result;
        }
    }
}
