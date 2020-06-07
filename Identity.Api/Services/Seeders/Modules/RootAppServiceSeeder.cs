using Identity.Api.Data.Repositories.Services;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.AppServices;
using Identity.Api.Identity.Domain.AppServices.Commands;
using Identity.Api.Utils.ResultValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Seeders.Modules
{
    public class RootAppServiceSeeder : IRootAppServiceSeeder
    {
        private readonly IAppServiceRepository _appServiceRepository;

        public RootAppServiceSeeder(IAppServiceRepository appServiceRepository)
        {
            _appServiceRepository = appServiceRepository;
        }
        public async Task<List<RootSeederResult>> SeedAsync(Dictionary<SeederTypeName, RootSeederResult> rootValues)
        {
            var rootUserId = Guid.Parse(rootValues[SeederTypeName.RootUser].Value);
            var command = new RegisterAppServiceCommand("IdentityService", "Identity management service", rootUserId);
            var appService = _appServiceRepository.FindBy(x => x.ServiceInfo.Name == command.Name).FirstOrDefault();
            if (appService != null)
                return await Task.FromResult<List<RootSeederResult>>(new List<RootSeederResult>() { new RootSeederResult() { Type = SeederTypeName.AppService, Value = appService.Id.ToString() } });

            var creatServiceInfoResult = AppServiceInfo.Create(command.Name, command.Description).Validate();
            var createdByResult = CreateInfo.Create(command.CreatedBy).Validate();
            var rootService = new AppService(creatServiceInfoResult.Value, createdByResult.Value);
            _appServiceRepository.Insert(rootService);
            _appServiceRepository.Save();
            return await Task.FromResult<List<RootSeederResult>>(new List<RootSeederResult>() { new RootSeederResult() { Type = SeederTypeName.AppService, Value = rootService.Id.ToString() } });
        }
    }
}
