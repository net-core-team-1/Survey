using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Services.Roles;
using Identity.Api.Utils.ResultValidator;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Roles.CommandHandlers
{
    public class UnregisterRoleCommandHandler : ICommandHandler<UnregisterRoleCommand>
    {
        private readonly IRoleService _roleService;
        public UnregisterRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<Result> Handle(UnregisterRoleCommand command)
        {
            var deleteInfoResult = DeleteInfo.Create(true, command.DeletedBy, command.Reason).Validate();
            var role = _roleService.FindUserByRoleIdAsync(command.Id).Result;
            if (role == null)
                throw new IdentityException("ROLE_NOT_FOUND", "Role not found in database");

            role.Unregister(deleteInfoResult.Value);

            await _roleService.UpdateAsync(role);
            return await Task.FromResult(Result.Ok());
        }
    }
}
