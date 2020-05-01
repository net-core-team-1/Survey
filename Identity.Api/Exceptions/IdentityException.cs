using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Exceptions
{
    public class IdentityException : Exception
    {
        public string Code { get; }

        public string FullErrorMessage => $"{Code}_{Message}";
        public IdentityException()
        {
        }

        public IdentityException(string code)
        {
            Code = code;
        }

        public IdentityException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public IdentityException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public IdentityException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public IdentityException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
