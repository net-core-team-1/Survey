using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<Result> LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Result> LogOut(string email)
        {
            throw new NotImplementedException();
        }
    }
}
