using Common.Types.Types.ServiceBus;
using CSharpFunctionalExtensions;
using Identity.Api.Identity.Domain.Users.Commands;
using Survey.Common.Types;
using Survey.Identity.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Users.CommandHandlers
{
    public class AssignRolesToUserCommadHandler : ICommandHandler<AssignRolesToUserCommad>
    {
        private readonly IUserService _userService;
        private readonly IBusPublisher _busPublisher;

        public AssignRolesToUserCommadHandler(IUserService userService, IBusPublisher busPublisher)
        {
            _userService = userService;
            _busPublisher = busPublisher;
        }

        public async Task<Result> Handle(AssignRolesToUserCommad command)
        {
            await _userService.AssignRolesAsync(command.UserId, command.Roles);
          
            return await Task<Result>.FromResult(Result.Ok());
        }
    }
}
