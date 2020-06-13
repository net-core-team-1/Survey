using CSharpFunctionalExtensions;
using Identity.Api.Contrats.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.IdentityServices.Authentication
{
    public interface IAuthenticationService
    {
        Task<Result> LoginAsync(string name, string password);

        Task<Result> LogOut(Guid id);

        Task<Result> ChangePassword(Guid id, string newPassword, string oldPassword);

        Task<JsonWebTokenResponse> IssueWebToken(string id = "", string email = "");

        Task<Result<JsonWebTokenResponse>> RefreshToken(string token);
    }
}
