using Survey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Domain.Users.Commands
{
    public class ChangeEmailCommand:ICommand
    {

        public Guid Id { get;  }
        public string Email { get;  }
        public ChangeEmailCommand(Guid id,string email)
        {
            Id = id;
            Email = email;
        }
    }
}
