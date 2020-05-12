using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Data.Repositories.Services;
using Identity.Api.Identity.Domain.AppServices;
using Identity.Api.Identity.Domain.AppServices.Commands;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.AppServices.CommandHandlers
{
    public class RegisterAppServiceFeatureCommandHandler : ICommandHandler<RegisterAppServiceFeatureCommand>
    {
        private readonly IAppServiceRepository _appServiceRepository;
        public RegisterAppServiceFeatureCommandHandler(IAppServiceRepository appServiceRepository)
        {
            _appServiceRepository = appServiceRepository;
        }
        public Task<Result> Handle(RegisterAppServiceFeatureCommand command)
        {
            throw new NotImplementedException();
            //var service = _appServiceRepository.FindByKey(command.AppServiceId);
            //if (service == null)
            //    throw new IdentityException("App Service not found");

            //var appServiceFeature = new AppServiceFeature(command.AppServiceId, command.FeatureId);

            //service.AssignFeature(appServiceFeature);
            //_appServiceRepository.Update(service);
            //_appServiceRepository.Save();
            //return Task.FromResult(Result.Success());
        }
    }
}
