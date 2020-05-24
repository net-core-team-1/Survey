using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Data.Repositories.Services;
using Identity.Api.Identity.Domain.AppServices;
using Identity.Api.Identity.Domain.AppServices.Commands;
using Identity.Api.Identity.Domain.Features;
using Identity.Api.Utils.ResultValidator;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Api.Data.Repositories.Features;

namespace Identity.Api.Services.AppServices.CommandHandlers
{
    public class EditAppServiceFeaturesCommandHandler : ICommandHandler<EditAppServiceFeaturesCommand>
    {
        private readonly IAppServiceRepository _appServiceRepository;
        private readonly IFeatureRepository _featureRepository;
        public EditAppServiceFeaturesCommandHandler(IAppServiceRepository appServiceRepository
            , IFeatureRepository featureRepository)
        {
            _appServiceRepository = appServiceRepository;
            _featureRepository = featureRepository;
        }
        public Task<Result> Handle(EditAppServiceFeaturesCommand command)
        {
            var service = _appServiceRepository.FindByKey(command.AppServiceId);
            if (service == null)
                throw new IdentityException("Service not found");
            var features = _featureRepository.FindByInclude(x => command.Features.Contains(x.Id)).ToList();
            if(features.Count() != command.Features.Count())
                throw new IdentityException("One or more features not found");

            foreach (var item in features)
                item.ChangeService(service);

            _featureRepository.Save();
            return Task.FromResult(Result.Success());
        }
    }
}
