using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Users
{
    public interface IUserService
    {
        Task<Result> RegisterUser(string firstName, string lastName, string email, string password, List<Guid> roles);
        Task<Result> EditInfo(Guid userId,string firstName, string lastName,List<Guid> roles,bool deleteExising);

        Task<Result> ChangeEmail(Guid userId, string email);

        Task<Result> UnregisterUser(Guid userId, Guid by, string reason);

    }
}
