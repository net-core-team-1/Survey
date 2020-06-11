using FluentValidation;
using Identity.Api.Contrat.AppServices.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.AppService
{
    public class EditAppServiceFeaturesValidator : AbstractValidator<EditAppServiceFeaturesRequest>
    {
        public EditAppServiceFeaturesValidator()
        {
            RuleFor(x => x.AppServiceId).NotEmpty().WithMessage("AppServiceId is mendatory.");
            RuleFor(x => x.Features).NotEmpty().WithMessage("Features are mendatory.");
        }
    }
}
