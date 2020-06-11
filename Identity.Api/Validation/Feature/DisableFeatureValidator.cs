using FluentValidation;
using Identity.Api.Contrat.Features.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.Feature
{
    public class DisableFeatureValidator : AbstractValidator<DisableFeatureRequest>
    {
        public DisableFeatureValidator()
        {
            RuleFor(x => x.featureId).NotEmpty().WithMessage("Feature Id is mendatory.");
            RuleFor(x => x.Reason).NotEmpty().WithMessage("Disabling reason is mendatory.");
        }
    }
}
