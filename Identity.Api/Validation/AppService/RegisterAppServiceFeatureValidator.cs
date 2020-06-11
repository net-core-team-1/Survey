using FluentValidation;
using Identity.Api.Contrat.AppServices.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.AppService
{
    public class RegisterAppServiceFeatureValidator : AbstractValidator<RegisterAppServiceFeatureRequest>
    {
        public RegisterAppServiceFeatureValidator()
        {
            RuleFor(x => x.AppServiceId).NotEmpty().WithMessage("AppServiceId is mendatory.");
            RuleFor(x => x.FeatureId).NotEmpty().WithMessage("FeatureId is mendatory.");
        }
    }
}
