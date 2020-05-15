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
using Identity.Api.Data.Repositories.Features;
using Identity.Api.Identity.Domain.Features.Commands;

namespace Identity.Api.Services.Features.CommandHandlers
{
    public class EditFeatureAppServiceCommandHandler : ICommandHandler<EditFeatureAppServiceCommand>
    {
        private readonly IAppServiceRepository _appServiceRepository;
        private readonly IFeatureRepository _featureRepository;
        public EditFeatureAppServiceCommandHandler(IAppServiceRepository appServiceRepository,
                         IFeatureRepository featureRepository)
        {
            _appServiceRepository = appServiceRepository;
            _featureRepository = featureRepository;
        }
        public Task<Result> Handle(EditFeatureAppServiceCommand command)
        {
            var service = _appServiceRepository.FindByKey(command.AppServiceId);
            if (service == null)
                throw new IdentityException("Service_not_found", "Service not found in database with the given Id");

            var feature = _featureRepository.FindByKey(command.FeatureId);
            if (feature == null)
                throw new IdentityException("Feature not found");

            feature.ChangeService(service);
            _featureRepository.Update(feature);
            _featureRepository.Save();
            return Task.FromResult(Result.Success());
        }
    }
}
