using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain.Features;
using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Services.Roles;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Roles.CommandHandlers
{
    public class RegisterRoleFeatureCommandHandler : ICommandHandler<RegisterRoleFeatureCommand>
    {
        private readonly IRoleService _roleService;
        public RegisterRoleFeatureCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<Result> Handle(RegisterRoleFeatureCommand command)
        {
            var role = _roleService.FindRoleById(command.RoleId).Result;
            if (role == null)
                throw new IdentityException("ROLE_NOT_FOUND", "Role not found in database");

            var features = command.Features.Select(x => new Feature(x))
                                           .ToList();
            role.EditFeatures(command.AssignedBy, features);

            await _roleService.UpdateAsync(role);
            return await Task.FromResult(Result.Ok());
        }
    }
}
