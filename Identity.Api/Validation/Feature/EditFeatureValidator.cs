using FluentValidation;
using Identity.Api.Contrat.Features.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.Feature
{
    public class EditFeatureValidator : AbstractValidator<EditFeatureRequest>
    {
        public EditFeatureValidator()
        {
            RuleFor(x => x.AppServiceId).NotEmpty().WithMessage("Feature: AppServiceId is mendatory");
            RuleFor(x => x.FeatureId).NotEmpty().WithMessage("Feature: FeatureId is mendatory");
            RuleFor(x => x.Label).NotEmpty().WithMessage("Feature: Label is mendatory");
            RuleFor(x => x.Action).NotEmpty().WithMessage("Feature: Action is mendatory");
            RuleFor(x => x.ControllerActionName).NotEmpty().WithMessage("Feature: ControllerActionName is mendatory");
            RuleFor(x => x.ControllerName).NotEmpty().WithMessage("Feature: ControllerName is mendatory");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Feature: Description is mendatory");
        }
    }
}
