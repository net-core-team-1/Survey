using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Data.Repositories.Structures;
using Identity.Api.Identity.Domain.Structure;
using Identity.Api.Identity.Domain.Structure.Commands;
using Identity.Api.Utils.ResultValidator;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Structures.Commands
{
    public class EditStructureCommandHandler : ICommandHandler<EditStructureCommand>
    {
        private readonly IStructureRepository _structureRepository;

        public EditStructureCommandHandler(IStructureRepository structureRepository)
        {
            _structureRepository = structureRepository;
        }

        public Task<Result> Handle(EditStructureCommand command)
        {
            var structure = _structureRepository.FindByKey(command.StructureId);
            if (structure == null)
                throw new IdentityException("Structure not found");

            var createStructureInfoResult = StructureInfo.Create(command.Name, command.Description).Validate();
            structure.EditInfo(createStructureInfoResult.Value);
            _structureRepository.Save();
            return Task.FromResult(Result.Success());
        }
    }
}
