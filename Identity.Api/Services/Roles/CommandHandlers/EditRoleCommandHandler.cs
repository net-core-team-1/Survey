using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain.AppServices;
using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Services.Roles;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Roles.CommandHandlers
{
    public class EditRoleCommandHandler : ICommandHandler<EditRoleCommand>
    {
        private readonly IRoleService _roleService;

        public EditRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Result> Handle(EditRoleCommand command)
        {
            var role = _roleService.FindRoleById(command.Id).Result;
            if (role == null)
                throw new IdentityException("ROLE_NOT_FOUND", "Role not found in database");
            var appService = new AppService(command.AppServiceId);
            role.EditRoleInfo(command.Name, command.Description, appService);
            await _roleService.UpdateAsync(role);
            return await Task.FromResult(Result.Ok());
        }
    }
}
