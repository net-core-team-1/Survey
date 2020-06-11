using FluentValidation;
using Identity.Api.Contrat.AppServices.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.AppService
{
    public class RegisterAppServiceValidator : AbstractValidator<RegisterAppServiceRequest>
    {
        public RegisterAppServiceValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("AppService name is mandatory.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("AppService description is mandatory.");
        }
    }
}
