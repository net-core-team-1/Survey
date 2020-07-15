using CSharpFunctionalExtensions;
using Survey.Identity.Domain.Entities;
using Survey.Indentity.Domain.Roles.Commands;
using Survey.Messaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Data.Seeding.Roles
{
    public class RoleSeeder : IRoleSeeder
    {
        private readonly DispatcherAsync _dispatcher;
        private readonly IEntityRepository _entityRepository;

        public RoleSeeder(DispatcherAsync dispatcher, IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
            _dispatcher = dispatcher;
        }
        public async Task<Result> SeedAsync()
        {
            var entity = _entityRepository.GetAll().FirstOrDefault();
            if (entity != null)
            {
                var command1 = new CreateRoleCommand("End user", entity.Id);
                var command2 = new CreateRoleCommand("Admin IT", entity.Id);

                var result1 = await _dispatcher.Dispatch(command1);
                var result2 = await _dispatcher.Dispatch(command2);
                var result = Result.Combine(result1, result2);
                return result;
            }
            return await Task<Result>.FromResult(Result.Failure($"error_seeading_roles"));
        }
    }
}
