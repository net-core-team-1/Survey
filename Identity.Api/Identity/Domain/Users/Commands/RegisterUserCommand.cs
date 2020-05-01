﻿using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Commands
{
    public class RegisterUserCommand : ICommand
    {
        public string UserName { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public int CivilityId { get; }
        public string Password { get; }
        public List<Guid> Permissions { get; }

        public RegisterUserCommand(
            string userName,
            string firstName, string lastName, string email,
            string password, int civilityId, List<Guid> permissions)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            CivilityId = civilityId;
            Permissions = permissions;
        }
    }
}