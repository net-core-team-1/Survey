using FluentValidation;
using Identity.Api.Contrat.Users.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.User
{
    public class EditUserValidator : AbstractValidator<EditUserRequest>
    {
        public EditUserValidator()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("UserId is mendatory.");
            RuleFor(x => x.CivilityId).NotNull().WithMessage("CivilityId is mendatory.");
            RuleFor(x => x.FirstName).NotNull().WithMessage("FirstName is mendatory.");
            RuleFor(x => x.LastName).NotNull().WithMessage("LastName is mendatory.");
        }
    }
}
