using Common.Types.Types.ServiceBus;
using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain.AppUserRoles;
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
    public class UnregisterUserRoleCommandHandler : ICommandHandler<UnregisterUserRoleCommand>
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleservice;
        private readonly IBusPublisher _busPublisher;

        public UnregisterUserRoleCommandHandler(IUserService userService, IRoleService roleservice,
            IBusPublisher busPublisher)
        {
            _userService = userService;
            _roleservice = roleservice;
            _busPublisher = busPublisher;
        }
        public async Task<Result> Handle(UnregisterUserRoleCommand command)
        {
            var user = _userService.FindUserByUserIdAsync(command.UserId).Result;
            if (user == null)
                throw new IdentityException("User_not_found", "user with the given id not found in database");
            var role = _roleservice.FindRoleById(command.RoleId).Result;
            if (role == null)
                throw new IdentityException("Role_not_found", "role with the given id not found in database");
            
            if(user.UserRoles.Where(x=>x.RoleId == role.Id).Count() == 0)
                throw new IdentityException("Role_not_found_for_user", "role with the given id not found in database for this given user");

            user.RemoveRole(new AppUserRole(role, user));

            await _userService.UpdateAsync(user);

            return await Task<Result>.FromResult(Result.Ok());
        }
    }
}
