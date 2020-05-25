
using CSharpFunctionalExtensions;
using Survey.Identity.Contracts.Authentication.Responses;
using System;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<Result> LoginAsync(string email, string password);

        Task<Result> LogOut(Guid id);

        Task<Result> ChangePassword(Guid id, string newPassword, string oldPassword);

        Task<JsonWebTokenResponse> IssueWebToken(string id = "", string email = "");

        Task<Result<JsonWebTokenResponse>> RefreshToken(string token);



    }
}
