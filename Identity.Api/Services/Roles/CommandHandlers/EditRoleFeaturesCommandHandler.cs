using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain.Features;
using Identity.Api.Identity.Services.Roles;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Roles.CommandHandlers
{
    //public class EditRoleFeaturesCommandHandler : ICommandHandler<EditRoleFeaturesCommand>
    //{
    //    private readonly IRoleService _roleService;
    //    public EditRoleFeaturesCommandHandler(IRoleService roleService)
    //    {
    //        _roleService = roleService;
    //    }
    //    public async Task<Result> Handle(EditRoleFeaturesCommand command)
    //    {
    //        var role = _roleService.FindRoleById(command.RoleId).Result;
    //        if (role == null)
    //            throw new IdentityException("ROLE_NOT_FOUND", "Role not found in database");

    //        var features = command.Features.Select(x => new RoleAppServiceFeature(role.Id, x,
    //                                               DateTime.Now.ToUniversalTime(), command.AssignedBy))
    //                                       .ToList();
    //        role.EditFeatures(features);

    //        await _roleService.UpdateAsync(role);
    //        return await Task.FromResult(Result.Ok());
    //    }
    //}
}
