using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Data.Repositories.Structures;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.Structure.Commands;
using Identity.Api.Utils.ResultValidator;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Structures.Commands
{
    public class DeleteStructureCommandHandler : ICommandHandler<DeleteStructureCommand>
    {
        private readonly IStructureRepository _structureRepository;
        public DeleteStructureCommandHandler(IStructureRepository structureRepository)
        {
            _structureRepository = structureRepository;
        }

        public Task<Result> Handle(DeleteStructureCommand command)
        {
            var structure = _structureRepository.FindByKey(command.StructureId);
            if (structure == null)
                throw new IdentityException("Service not found");

            var deleteInfoResult = DeleteInfo.Create(true, command.DeletedBy, command.Reason).Validate();
            structure.Remove(deleteInfoResult.Value);
            _structureRepository.Save();
            return Task.FromResult(Result.Success());
        }
    }
}
