using FluentValidation;
using Identity.Api.Contrat.AppServices.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.AppService
{
    public class DeleteAppServiceValidator : AbstractValidator<DeleteAppServiceRequest>
    {
        public DeleteAppServiceValidator()
        {
            RuleFor(x => x.AppServiceId).NotEmpty().WithMessage("AppService Id is mendatory.");
            RuleFor(x => x.Reason).NotEmpty().WithMessage("AppService : Deleting reason is mendatory.");
        }
    }
}
