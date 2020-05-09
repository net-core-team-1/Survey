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
    public class DisableRoleCommandHandler : ICommandHandler<DisableRoleCommand>
    {
        private readonly IRoleService _roleService;
        public DisableRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Result> Handle(DisableRoleCommand command)
        {
            var disabeleInfoResult = DisabeleInfo.Create(true, command.DisabledBy).Validate();
            var role = _roleService.FindRoleById(command.Id).Result;
            if (role == null)
                throw new IdentityException("ROLE_NOT_FOUND", "Role not found in database");

            role.Disable(disabeleInfoResult.Value);

            await _roleService.UpdateAsync(role);
            return await Task.FromResult(Result.Ok());
        }
    }
}
