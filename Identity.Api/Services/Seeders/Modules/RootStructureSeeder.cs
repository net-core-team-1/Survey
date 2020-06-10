using Identity.Api.Data.Repositories.Structures;
using Identity.Api.Identity.Domain.Structures.Commands;
using Survey.Common.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Seeders.Modules
{
    public class RootStructureSeeder : IRootStructureSeeder
    {
        private readonly IStructureRepository _structureRepository;
        private readonly Dispatcher _dispatcher;

        public RootStructureSeeder(IStructureRepository structureRepository
            , Dispatcher dispatcher)
        {
            _structureRepository = structureRepository;
            _dispatcher = dispatcher;
        }

        public async Task<List<RootSeederResult>> SeedAsync(Dictionary<SeederTypeName, RootSeederResult> rootValues)
        {
            RegisterStructureCommand command = new RegisterStructureCommand("Root_Structure", "the principal structure", Guid.NewGuid());
            _dispatcher.Dispatch(command);
            var structure = _structureRepository.FindBy(x => x.StructureInfo.Name == command.Name).FirstOrDefault();
            return await Task.FromResult<List<RootSeederResult>>(new List<RootSeederResult>() { new RootSeederResult() { Type = SeederTypeName.Structure, Value = structure.Id.ToString() } });

        }
    }
}
