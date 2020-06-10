using Identity.Api.Data.Repositories.Services;
using Identity.Api.Identity.Domain.AppServices.Commands;
using Survey.Common.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Seeders.Modules
{
    public class RootAppServiceSeeder : IRootAppServiceSeeder
    {
        private readonly IAppServiceRepository _appServiceRepository;
        private readonly Dispatcher _dispatcher;

        public RootAppServiceSeeder(IAppServiceRepository appServiceRepository, Dispatcher dispatcher)
        {
            _appServiceRepository = appServiceRepository;
            _dispatcher = dispatcher;
        }
        public async Task<List<RootSeederResult>> SeedAsync(Dictionary<SeederTypeName, RootSeederResult> rootValues)
        {
            var rootUserId = Guid.Parse(rootValues[SeederTypeName.RootUser].Value);
            var command = new RegisterAppServiceCommand("IdentityService", "Identity management service", rootUserId);

            _dispatcher.Dispatch(command);

            var appService = _appServiceRepository.FindBy(x => x.ServiceInfo.Name == command.Name).FirstOrDefault();
            return await Task.FromResult<List<RootSeederResult>>(new List<RootSeederResult>()
            {
                new RootSeederResult()
                {
                    Type = SeederTypeName.AppService, Value = appService.Id.ToString()
                }
            });
        }
    }
}
