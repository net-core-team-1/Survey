using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Contracts
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
