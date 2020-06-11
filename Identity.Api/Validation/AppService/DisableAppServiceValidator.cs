using FluentValidation;
using Identity.Api.Contrat.AppServices.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.AppService
{
    public class DisableAppServiceValidator : AbstractValidator<DisableAppServiceRequest>
    {
        public DisableAppServiceValidator()
        {
            RuleFor(x => x.AppServiceId).NotEmpty().WithMessage("Appservice Id is mendatory.");
            RuleFor(x => x.Reason).NotEmpty().WithMessage("AppService : Disabling reason is mendatory.");
        }
    }
}
