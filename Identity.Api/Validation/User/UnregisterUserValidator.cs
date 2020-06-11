using FluentValidation;
using Identity.Api.Contrat.Users.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.User
{
    public class UnregisterUserValidator : AbstractValidator<UnregisterUserRequest>
    {
        public UnregisterUserValidator()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("UserId is mendatory.");
            RuleFor(x => x.Reason).NotNull().WithMessage("Deleting reason is mendatory.");
        }
    }
}
