using Identity.Api.Data.Repositories.Structures;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.Structures;
using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Utils.ResultValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Seeders.Modules
{
    public class RootStructureSeeder : IRootStructureSeeder
    {
        private readonly IStructureRepository _structureRepository;
        public RootStructureSeeder(IStructureRepository structureRepository)
        {
            _structureRepository = structureRepository;
        }

        public IRootModuleSeeder RootModuleSeeder()
        {
            throw new NotImplementedException();
        }

        public async Task<List<RootSeederResult>> SeedAsync(Dictionary<SeederTypeName, RootSeederResult> rootValues)
        {
            RegisterStructureCommand command = new RegisterStructureCommand("Root_Structure", "the principal structure", Guid.NewGuid());
            var structure = _structureRepository.FindBy(x => x.StructureInfo.Name == command.Name).FirstOrDefault();
            if (structure != null)
                return await Task.FromResult<List<RootSeederResult>>(new List<RootSeederResult>() { new RootSeederResult() { Type = SeederTypeName.Structure, Value = structure.Id.ToString() } });

            var structureInfoResult = StructureInfo.Create(command.Name, command.Description).Validate();
            var createdByResult = CreateInfo.Create(command.CreatedBy).Validate();
            var rootStructure = new Structure(structureInfoResult.Value, createdByResult.Value);
            _structureRepository.Insert(rootStructure);
            _structureRepository.Save();

            return await Task.FromResult<List<RootSeederResult>>(new List<RootSeederResult>() { new RootSeederResult() { Type = SeederTypeName.Structure, Value = rootStructure.Id.ToString() } });
        }
    }
}
