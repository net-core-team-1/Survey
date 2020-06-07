using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using Survey.Identity.Domain;
using Survey.Identity.Domain.Entities;
using Survey.Identity.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IEntityRepository _entityRepository;

        public UserService(UserManager<User> userManager, IEntityRepository entityRepository)
        {
            _userManager = userManager;
            _entityRepository = entityRepository;
        }
        public async Task<Result> RegisterUser(string firstName, string lastName, string email, string password, Guid entityId, List<Guid> roles)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
                return await Task<Result>.FromResult(Result.Failure($"user_email_already_in_use"));

            Result<FullName> fullNameResult = FullName.Create(firstName, lastName);
            if (fullNameResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure(fullNameResult.Error));

            var entity = _entityRepository.FindByKey(entityId);
            //if (entity == null)
            //    return await Task<Result>.FromResult(Result.Failure("invalid_entity_to_set"));

            var newUser = new User(fullNameResult.Value, email, entity, roles);

            var result = _userManager.CreateAsync(newUser, password);
            if (!result.Result.Succeeded)
                return await Task<Result>.FromResult(Result.Failure("could_not_save_user"));

            return await Task<Result>.FromResult(Result.Ok());

        }


        public async Task<Result> ChangeEmail(Guid userId, string email)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                return await Task<Result>.FromResult(Result.Failure($"User_not_exist "));

            if (user.DeleteInfo.Deleted)
                return await Task<Result>.FromResult(Result.Failure($"user_already_unregistred"));


            string token = await _userManager.GenerateChangeEmailTokenAsync(user, email);
            var result = await _userManager.ChangeEmailAsync(user, email, token);
            user.ChangeEmail(email);// added to rise the event from the domaine
            if (!result.Succeeded)
                return await Task<Result>.FromResult(Result.Failure("user_counld_not_change_email"));

            return await Task<Result>.FromResult(Result.Ok());
        }

        public async Task<Result> EditInfo(Guid userId, string firstName, string lastName, Guid entityId, List<Guid> roles = null)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
;
            if (user == null)
                return await Task<Result>.FromResult(Result.Failure($"user_not_exist "));

            if (user.DeleteInfo != null)
                if (user.DeleteInfo.Deleted)
                    return await Task<Result>.FromResult(Result.Failure($"user_already_unregistred"));

            Result<FullName> fullNameResult = FullName.Create(firstName, lastName);
            if (fullNameResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure(fullNameResult.Error));
            var entity = user.Entity;
            if (user.Entity?.Id != entityId || user.Entity == null)//to correct
            {
                entity = _entityRepository.FindByKey(entityId);
                if (entity == null)
                    return await Task<Result>.FromResult(Result.Failure("invalid_entity_to_set"));
            }

            user.EditUser(fullNameResult.Value, entity, roles);

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return await Task<Result>.FromResult(Result.Failure("user_editInfo_save_error"));

            return await Task<Result>.FromResult(Result.Ok());
        }


        public async Task<Result> UnregisterUser(Guid userId, Guid by, string reason)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return await Task<Result>.FromResult(Result.Failure($"No user found for Id= {userId}"));

            if (user.DeleteInfo.Deleted)
                return await Task<Result>.FromResult(Result.Failure($"user_already_unregistred"));

            Result<DeleteInfo> unregisterResult = DeleteInfo.Create(by, reason);
            if (unregisterResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure($"user_unregister_reason_not_valid"));

            user.Unregister(unregisterResult.Value);
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return await Task<Result>.FromResult(Result.Failure("user_unregister_error"));
            }
            return await Task<Result>.FromResult(Result.Ok());
        }
    }
}
