using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Contracts
{
   public sealed  class ChangePasswordRequest
    {
        public Guid Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
