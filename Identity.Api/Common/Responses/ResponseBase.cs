using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Common.Responses
{
    public abstract class ResponseBase
    {
        public abstract Int64 Count { get; }
    }
}
