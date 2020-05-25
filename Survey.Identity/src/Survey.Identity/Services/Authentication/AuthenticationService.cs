using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using Survey.Auth;
using Survey.Identity.Contracts.Authentication.Responses;
using Survey.Identity.Domain.Authentication;
using Survey.Identity.Domain.Identity;
using Survey.Identity.Domain.Users;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtHandler _jwtHandler;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AuthenticationService(UserManager<User> userManager,
                                     IJwtHandler jwtHandler,
                                     IRefreshTokenRepository refreshTokenRepository)
        {
            _userManager = userManager;
            _jwtHandler = jwtHandler;
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<Result> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return await Task<Result>.FromResult(Result.Failure($"Invalid_credentials"));
            var result = await _userManager.CheckPasswordAsync(user, password);
            if (!result)
                return await Task<Result>.FromResult(Result.Failure($"Invalid_credentials"));


            return await Task<Result>.FromResult(Result.Ok());
        }


        public async Task<Result> ChangePassword(Guid id, string newPassword, string oldPassword)
        {

            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return await Task<Result>.FromResult(Result.Failure($"Invalid_credentials"));

            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (!result.Succeeded)
                return await Task<Result>.FromResult(Result.Failure($"Invalid_credentials"));

            return await Task<Result>.FromResult(Result.Ok());
        }


        public async Task<Result> LogOut(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return await Task<Result>.FromResult(Result.Failure($"Invalud_user_id"));
            user.SetLastConnexionDate();

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return await Task<Result>.FromResult(Result.Failure($"User_Could_not_be_updated"));

            return await Task<Result>.FromResult(Result.Ok());
        }

        public async Task<JsonWebTokenResponse> IssueWebToken(string id = "", string email = "")
        {
            var user = new User();
            if (id == String.Empty)
                user = await _userManager.FindByEmailAsync(email);
            else
                user = await _userManager.FindByIdAsync(id);

            JsonWebToken token = _jwtHandler.Create(user.Id);

            var refreshToken = new RefreshToken(token);
            _refreshTokenRepository.Add(refreshToken);
            _refreshTokenRepository.Save();
            JsonWebTokenResponse tokenResp = new JsonWebTokenResponse { Token = token.Token, Expires = token.Expires };
            return tokenResp;
        }

        public async Task<Result<JsonWebTokenResponse>> RefreshToken(string token)
        {
            var validatedToken = _jwtHandler.GetPrincipalClaims(token);

            if (validatedToken == null)
            {
                return await Task<Result<JsonWebTokenResponse>>.FromResult(Result.Failure<JsonWebTokenResponse>($"invalid_token"));
            }

            var expiryDateInseconds =
                long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

            var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            expiryDateTimeUtc = expiryDateTimeUtc.AddSeconds(expiryDateInseconds);

            if (expiryDateTimeUtc > DateTime.UtcNow)
            {
                return await Task<Result<JsonWebTokenResponse>>.FromResult(Result.Failure<JsonWebTokenResponse>($"token_already_expired"));
            }

            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            var storedRefreshToken = _refreshTokenRepository.Get(token);


            if (storedRefreshToken == null)
            {
                return await Task<Result<JsonWebTokenResponse>>.FromResult(Result.Failure<JsonWebTokenResponse>($"refresh_token_not_valid"));
            }

            if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
            {
                return await Task<Result<JsonWebTokenResponse>>.FromResult(Result.Failure<JsonWebTokenResponse>($"token_already_expired"));
            }

            if (storedRefreshToken.Invalidated)
            {
                return await Task<Result<JsonWebTokenResponse>>.FromResult(Result.Failure<JsonWebTokenResponse>($"token_has_been_invalidated"));
            }

            if (storedRefreshToken.Used)
            {
                return await Task<Result<JsonWebTokenResponse>>.FromResult(Result.Failure<JsonWebTokenResponse>($"token_has_been_used"));
            }

            if (storedRefreshToken.JwtId != jti)
            {
                return await Task<Result<JsonWebTokenResponse>>.FromResult(Result.Failure<JsonWebTokenResponse>($"refresh_token_does_not_match_jwt"));
            }

            storedRefreshToken.Use();
            _refreshTokenRepository.Save();

            var userId = validatedToken.Claims.Single(x => x.Type == "id").Value;
            var jsonToken= await IssueWebToken(userId);

             return await Task<Result<JsonWebTokenResponse>>.FromResult(Result.Ok<JsonWebTokenResponse>(jsonToken));

        }

    
    }
}
