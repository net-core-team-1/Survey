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

namespace Identity.Api.Services.AppServices.CommandHandlers
{
    public class EditAppServiceFeaturesCommandHandler : ICommandHandler<EditAppServiceFeaturesCommand>
    {
        private readonly IAppServiceRepository _appServiceRepository;
        public EditAppServiceFeaturesCommandHandler(IAppServiceRepository appServiceRepository)
        {
            _appServiceRepository = appServiceRepository;
        }
        public Task<Result> Handle(EditAppServiceFeaturesCommand command)
        {
            throw new NotImplementedException();
            //var service = _appServiceRepository.FindByKey(command.AppServiceId);
            //if (service == null)
            //    throw new IdentityException("Service not found");

            //var items = command.Features.Select(x => new AppServiceFeature(command.AppServiceId, x)).ToList();
            //var serviceFeatures = new AppServiceFeatureCollection(items);

            //service.EditFeatures(serviceFeatures);
            //_appServiceRepository.Update(service);
            //_appServiceRepository.Save();
            //return Task.FromResult(Result.Success());
        }
    }
}
