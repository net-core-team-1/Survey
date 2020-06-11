using FluentValidation;
using Identity.Api.Contrat.Features.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.Feature
{
    public class UnregisterFeatureValidator : AbstractValidator<UnregisterFeatureRequest>
    {
        public UnregisterFeatureValidator()
        {
            RuleFor(x => x.featureId).NotEmpty().WithMessage("Feature Id is mendatory.");
            RuleFor(x => x.Reason).NotEmpty().WithMessage("Deleting reason is mendatory.");
        }
    }
}
