using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrat.Users.Requests
{
    public class RegisterUserRequest
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CivilityId { get; set; }
        public string Password { get; set; }

        public List<Guid> Permissions { get; set; }

        public RegisterUserRequest()
        {
            Permissions = new List<Guid>();
        }

    }
}
