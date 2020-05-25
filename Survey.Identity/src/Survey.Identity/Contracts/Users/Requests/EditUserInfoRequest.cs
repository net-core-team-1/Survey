using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Contracts
{
    public class EditUserInfoRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid EntityId { get; set; }

        public List<Guid> Roles { get; set; }
        public EditUserInfoRequest()
        {
            Roles = new List<Guid>();
        }
    }
}
