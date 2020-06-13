using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrats.Authentication.Requests
{
    public class SignOutRequest
    {
        public Guid Id { get; set; }
        public SignOutRequest(Guid id)
        {
            Id = id;
        }
    }
}
