using Common.Types.Types.Events;
using CSharpFunctionalExtensions;
using Survey.Api.Domain.Models;
using Survey.Api.Events;
using Survey.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Api.Handlers
{
    public sealed class UserRegisteredHandler : IEventHandler<UserRegistered>
    {
        private readonly IUserDtoService _userDtoService;

        public UserRegisteredHandler(IUserDtoService userDtoService)
        {
            _userDtoService = userDtoService;
        }
        public async Task<Result> Handle(UserRegistered @event)
        {
            Console.WriteLine($"user created: {@event.FirstName} {@event.LastName}");

            var userDto = new UserDto(@event.Id, @event.FirstName, @event.LastName, @event.Email, @event.CreatedOn);

            await _userDtoService.AddUserDtoAsync(userDto);

            return await Task<Result>.FromResult(Result.Ok());
        }
    }
}
