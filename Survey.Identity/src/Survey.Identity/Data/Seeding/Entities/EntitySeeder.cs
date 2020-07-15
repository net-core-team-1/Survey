using CSharpFunctionalExtensions;
using Survey.Identity.Domain.Entities.Commands;
using Survey.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Data.Seeding.Entities
{
    public class EntitySeeder : IEntitySeeder
    {
        private readonly DispatcherAsync _dispatcher;

        public EntitySeeder(DispatcherAsync dispatcher)
        {
            _dispatcher = dispatcher;
        }
        public async Task<Result> SeedAsync()
        {
            var command = new CreateEntityCommand("IT entity", "IT entity", null);
            var result = await _dispatcher.Dispatch(command);
            return result;
        }

    }
}
