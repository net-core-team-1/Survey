using CSharpFunctionalExtensions;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Services.Roles;
using Identity.Api.Utils.ResultValidator;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Roles.CommandHandlers
{
    public class RegisterRoleCommandHandler : ICommandHandler<RegisterRoleCommand>
    {
        private readonly IRoleService _roleService;

        public RegisterRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Result> Handle(RegisterRoleCommand command)
        {
            var createInfoResult = CreateInfo.Create(command.CreatedBy).Validate();
            var role = new AppRole(createInfoResult.Value, command.Name, command.Description);
            await _roleService.RegisterNewAsync(role);
            return await Task.FromResult(Result.Ok());
        }
    }
}
