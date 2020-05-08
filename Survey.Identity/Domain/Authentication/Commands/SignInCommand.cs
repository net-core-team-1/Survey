using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Domain.Authentication.Commands
{
    public class SignInCommand : ICommand
    {
        public string Email { get; }
        public string Password { get; }

        public SignInCommand(string email,string password)
        {
            Email = email;
            Password = password;
        }

    }
}
