using FluentValidation;
using Identity.Api.Contrat.Users.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.User
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.CivilityId).NotNull().WithMessage("CivilityId is mendatory.");
            RuleFor(x => x.FirstName).NotNull().WithMessage("FirstName is mendatory.");
            RuleFor(x => x.LastName).NotNull().WithMessage("LastName is mendatory.");
            RuleFor(x => x.StructureId).NotNull().WithMessage("Structure id is mendatory.");
            RuleFor(x => x.Email).NotNull().WithMessage("Email id is mendatory.");
            RuleFor(x => x.Password).NotNull().WithMessage("Password id is mendatory.");
            RuleFor(x => x.UserName).NotNull().WithMessage("UserName id is mendatory.");
        }
    }
}
