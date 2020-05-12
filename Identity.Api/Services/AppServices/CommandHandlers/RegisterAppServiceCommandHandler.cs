using CSharpFunctionalExtensions;
using Identity.Api.Data.Repositories.Services;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.AppServices;
using Identity.Api.Identity.Domain.AppServices.Commands;
using Identity.Api.Utils.ResultValidator;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.AppServices.CommandHandlers
{
    public class RegisterAppServiceCommandHandler : ICommandHandler<RegisterAppServiceCommand>
    {
        private readonly IAppServiceRepository _appServiceRepository;

        public RegisterAppServiceCommandHandler(IAppServiceRepository appServiceRepository)
        {
            _appServiceRepository = appServiceRepository;
        }

        public Task<Result> Handle(RegisterAppServiceCommand command)
        {
            var creatServiceInfoResult = AppServiceInfo.Create(command.Name, command.Description).Validate();
            var createdByResult = CreateInfo.Create(command.CreatedBy).Validate();
            var service = new AppService(creatServiceInfoResult.Value, createdByResult.Value);
            _appServiceRepository.Insert(service);
            _appServiceRepository.Save();
            return Task.FromResult(Result.Success());
        }
    }
}
