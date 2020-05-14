using Common.Types.Types.ServiceBus;
using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain.Users.Commands;
using Identity.Api.Identity.Services.Roles;
using Survey.Common.Types;
using Survey.Identity.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Users.CommandHandlers
{
    public class EditUserRolesCommadHandler : ICommandHandler<EditUserRolesCommad>
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleservice;
        private readonly IBusPublisher _busPublisher;

        public EditUserRolesCommadHandler(IUserService userService, IRoleService roleservice,
            IBusPublisher busPublisher)
        {
            _userService = userService;
            _roleservice = roleservice;
            _busPublisher = busPublisher;
        }

        public async Task<Result> Handle(EditUserRolesCommad command)
        {
            var roles = command.Roles.Distinct().ToList();
            var rolesResult = _roleservice.FindRoleByIds(roles);
            if (rolesResult.Result.Count() != command.Roles.Count())
                throw new IdentityException("Invalid_Roles", "one or many roles not found in database, make sure that roles exists");

            await _userService.AssignRolesAsync(command.UserId, roles);

            return await Task<Result>.FromResult(Result.Ok());
        }
    }
}
