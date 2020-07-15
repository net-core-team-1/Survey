using CSharpFunctionalExtensions;
using Survey.Identity.Domain.Services.Commands;
using Survey.Identity.Services.MicroServices;
using Survey.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Data.Seeding.MicroServices
{
    public class MicroServiceSeeder : IMicroServiceSeeder
    {
        private readonly DispatcherAsync _dispatcher;

        public MicroServiceSeeder(DispatcherAsync dispatcher)
        {
            _dispatcher = dispatcher;
        }
        public Task<Result> SeedAsync()
        {
            var command = new CreateMicroServiceCommand("Identity", "Identity Service");
            var result = _dispatcher.Dispatch(command);
            return result;
        }
    }
}
