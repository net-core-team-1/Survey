using Common.Types.Types.ServiceBus;
using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.Users;
using Identity.Api.Identity.Domain.Users.Commands;
using Identity.Api.Identity.Domain.Users.Events;
using Identity.Api.Utils.ResultValidator;
using Survey.Common.Types;
using Survey.Identity.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Users.CommandHandlers
{
    public class UnregisterUserCommandHandler : ICommandHandler<UnregisterUserCommand>
    {
        private readonly IUserService _userService;
        private readonly IBusPublisher _busPublisher;

        public UnregisterUserCommandHandler(IUserService userService, IBusPublisher busPublisher)
        {
            _userService = userService;
            _busPublisher = busPublisher;
        }

        public async Task<Result> Handle(UnregisterUserCommand command)
        {
            var deleteInfoResult = DeleteInfo.Create(true, command.DeletedBy, command.Reason).Validate();
            var user = _userService.FindUserByUserIdAsync(command.UserId).Result;
            if (user == null)
                throw new IdentityException("USER_NOT_FOUND", "User not found in database");

            user.MarkAsDeleted(deleteInfoResult.Value);
            await _userService.UpdateAsync(user);
            return await Task.FromResult(Result.Ok());
        }
    }
}
