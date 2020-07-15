using CSharpFunctionalExtensions;
using Survey.Identity.Domain.Entities;
using Survey.Identity.Domain.Users.Commands;
using Survey.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Survey.Identity.Data.Seeding.Users
{
    public class UserSeeder : IUserSeeder
    {
        private readonly DispatcherAsync _dispatcher;
        private readonly IEntityRepository _entityRepository;

        public UserSeeder(DispatcherAsync dispatcher, 
                          IEntityRepository entityRepository)
        {
            _dispatcher = dispatcher;
            _entityRepository = entityRepository;
        }
        public async Task<Result> SeedAsync()
        {
            var entity = _entityRepository.GetAll().FirstOrDefault();

            if (entity != null)
            {
                var command = new RegisterUserCommand("firstName", "lastName",
                                                      "firstName.lastName@identity.com", "p@ssw0rd",
                                                      entity.Id);
                var result = await _dispatcher.Dispatch(command);
                return result;
            }
            return await Task<Result>.FromResult(Result.Failure($"error_seeding_user"));
        }
    }
}
