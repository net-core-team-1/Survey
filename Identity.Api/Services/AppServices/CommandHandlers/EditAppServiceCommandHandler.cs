using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Data.Repositories.Services;
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
    public class EditAppServiceCommandHandler : ICommandHandler<EditAppServiceCommand>
    {
        private readonly IAppServiceRepository _appServiceRepository;

        public EditAppServiceCommandHandler(IAppServiceRepository appServiceRepository)
        {
            _appServiceRepository = appServiceRepository;
        }
        public Task<Result> Handle(EditAppServiceCommand command)
        {
            var service = _appServiceRepository.FindByKey(command.AppServiceId);
            if (service == null)
                throw new IdentityException("Service not found");

            var creatServiceInfoResult = AppServiceInfo.Create(command.Name, command.Description).Validate();
            service.EditInfo(creatServiceInfoResult.Value);
            _appServiceRepository.Save();
            return Task.FromResult(Result.Success());
        }
    }
}
