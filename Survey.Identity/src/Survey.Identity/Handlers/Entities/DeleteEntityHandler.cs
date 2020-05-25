using CSharpFunctionalExtensions;
using Survey.CQRS.Commands;
using Survey.Identity.Domain.Entities.Commands;
using Survey.Identity.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.Entities
{
    public class DeleteEntityHandler : ICommandHandler<DeleteEntityCommand>
    {
        private readonly IEntityService _entityService;

        public DeleteEntityHandler(IEntityService entityService)
        {
            _entityService = entityService;
        }
        public async Task<Result> Handle(DeleteEntityCommand command)
        {
            return await _entityService.Delete(command.Id, command.By, command.Reason);
        }
    }
}
