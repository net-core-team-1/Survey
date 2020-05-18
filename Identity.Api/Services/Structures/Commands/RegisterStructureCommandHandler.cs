using CSharpFunctionalExtensions;
using Identity.Api.Data.Repositories.Structures;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.Structures;
using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Utils.ResultValidator;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Structures.Commands
{
    public class RegisterStructureCommandHandler : ICommandHandler<RegisterStructureCommand>
    {
        private readonly IStructureRepository _structureRepository;

        public RegisterStructureCommandHandler(IStructureRepository structureRepository)
        {
            _structureRepository = structureRepository;
        }

        public Task<Result> Handle(RegisterStructureCommand command)
        {
            var count = _structureRepository.FindBy(x=>x.StructureInfo.Name==command.Name).Count();
            if (count != 0)
                throw new IdentityException("Structure already exist with this name");

            var structureInfoResult = StructureInfo.Create(command.Name,command.Description).Validate();
            var createdByResult = CreateInfo.Create(command.CreatedBy).Validate();
            var structure = new Structure(structureInfoResult.Value, createdByResult.Value);
            _structureRepository.Insert(structure);
            _structureRepository.Save();
            return Task.FromResult(Result.Success());
        }
    }
}
