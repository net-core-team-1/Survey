using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrat.Users.Requests
{
    public class EditUserRequest
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CivilityId { get; set; }

        public EditUserRequest()
        {
          
        }
    }
}
