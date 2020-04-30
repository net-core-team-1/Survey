
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Authentication
{
   public interface IAuthenticationService
    {
        Task<Result> LoginAsync(string email, string password);

        Task<Result> LogOut(string email);
    }
}
