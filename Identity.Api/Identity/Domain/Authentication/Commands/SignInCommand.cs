using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Authentication.Commands
{
    public class SignInCommand : ICommand
    {
        public string UserName { get; }
        public string Password { get; }

        public SignInCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

    }
}
