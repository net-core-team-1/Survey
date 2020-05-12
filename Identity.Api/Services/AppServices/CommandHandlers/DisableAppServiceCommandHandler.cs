using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Data.Repositories.Services;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.AppServices.Commands;
using Identity.Api.Utils.ResultValidator;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.AppServices.CommandHandlers
{
    public class DisableAppServiceCommandHandler : ICommandHandler<DisableAppServiceCommand>
    {
        private readonly IAppServiceRepository _appServiceRepository;

        public DisableAppServiceCommandHandler(IAppServiceRepository appServiceRepository)
        {
            _appServiceRepository = appServiceRepository;
        }
        public Task<Result> Handle(DisableAppServiceCommand command)
        {
            var service = _appServiceRepository.FindByKey(command.AppServiceId);
            if (service == null)
                throw new IdentityException("Service not found");

            var disableInfoResult = DisabeleInfo.Create(true, command.DisableddBy).Validate();
            service.DisableService(disableInfoResult.Value);
            _appServiceRepository.Save();
            return Task.FromResult(Result.Success());
        }
    }
}
