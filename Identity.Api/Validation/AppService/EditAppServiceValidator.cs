using FluentValidation;
using Identity.Api.Contrat.AppServices.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.AppService
{
    public class EditAppServiceValidator : AbstractValidator<EditAppServiceRequest>
    {
        public EditAppServiceValidator()
        {
            RuleFor(x => x.AppServiceId).NotEmpty().WithMessage("AppService id is mendatory.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("AppService name is mendatory.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("AppService description is mendatory.");
        }
    }
}
