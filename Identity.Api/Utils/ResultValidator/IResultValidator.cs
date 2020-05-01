using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Utils.ResultValidator
{
    public interface IResultValidator
    {
        void Validate<T>(Result<T> input);
    }
}
