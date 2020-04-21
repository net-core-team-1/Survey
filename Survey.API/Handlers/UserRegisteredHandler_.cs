using Common.Types.Types.Events;
using CSharpFunctionalExtensions;
using Survey.Api.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Api.Handlers
{
    public sealed class UserRegisteredHandler_ : IEventHandler<UserRegistered>
    {
        public Task<Result> Handle(UserRegistered @event)
        {
            Console.WriteLine($"Activity created: {@event.FirstName} {@event.LastName}");

            return Task<Result>.FromResult(Result.Ok());
        }
    }
}
