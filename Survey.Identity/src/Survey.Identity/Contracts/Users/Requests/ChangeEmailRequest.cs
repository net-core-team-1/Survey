using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Contracts
{
    public class ChangeEmailRequest
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

    }
}
