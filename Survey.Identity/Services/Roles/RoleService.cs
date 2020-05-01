using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using Survey.Identity.Domain;
using Survey.Identity.Domain.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<Result> Create(string name, Guid by, List<Guid> features)
        {
            var role = await _roleManager.FindByNameAsync(name);
            if (role != null)
                return await Task<Result>.FromResult(Result.Failure($"Role_name_already_in_use"));

            Result<CreateInfo> createInfoResult = CreateInfo.Create(by);
            if (createInfoResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure($"Role_create_info_invalid"));

            role = new Role(name, createInfoResult.Value, features);
            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
                return await Task<Result>.FromResult(Result.Failure("Role could not be saved"));
            return await Task<Result>.FromResult(Result.Ok());
        }

        public async Task<Result> Deactivate(Guid id, Guid by)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
                return await Task<Result>.FromResult(Result.Failure($"Role_does_not_exist"));

            Result<DisabeleInfo> disableInfoResult = DisabeleInfo.Create(by);
            if (disableInfoResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure($"Role_disable_info_invalid"));

            role.Deactivate(disableInfoResult.Value);

            var result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded)
                return await Task<Result>.FromResult(Result.Failure("Role could not be updated"));
            return await Task<Result>.FromResult(Result.Ok());

        }

        public async Task<Result> EditName(Guid id, string name)
        {

            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
                return await Task<Result>.FromResult(Result.Failure($"Role_does_not_exist"));

            var result = await _roleManager.SetRoleNameAsync(role, name);

            if (!result.Succeeded)
                return await Task<Result>.FromResult(Result.Failure("Role could not be updated"));
            return await Task<Result>.FromResult(Result.Ok());
        }

        public async Task<Result> Remove(Guid id, Guid by, string reason)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
                return await Task<Result>.FromResult(Result.Failure($"Role_does_not_exist"));

            Result<DeleteInfo> deleteInfoResult = DeleteInfo.Create(by);
            if (deleteInfoResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure($"Role_delete_info_invalid"));

            role.Remove(deleteInfoResult.Value);
            var result = await _roleManager.UpdateAsync(role);

            if (!result.Succeeded)
                return await Task<Result>.FromResult(Result.Failure("Role could not be removed"));

            return await Task<Result>.FromResult(Result.Ok());
        }

        public async Task<Result> UpdateFeatures(Guid id, List<Guid> features, bool deleteExisting)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
                return await Task<Result>.FromResult(Result.Failure($"Role_does_not_exist"));

            role.Update(features, deleteExisting);

            var result = await _roleManager.UpdateAsync(role);

            if (!result.Succeeded)
                return await Task<Result>.FromResult(Result.Failure("Role could not be removed"));

            return await Task<Result>.FromResult(Result.Ok());
        }
    }
}
