
using CSharpFunctionalExtensions;
using Survey.Common.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Authentication
{
   public interface IAuthenticationService
    {
        Task<Result> LoginAsync(string email, string password);

        Task<Result> LogOut(Guid id);

        Task<Result> ChangePassword(Guid id, string newPassword, string oldPassword);

        Task<JsonWebToken> IssueWebToken(string email);
    }
}
