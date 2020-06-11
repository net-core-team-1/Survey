using FluentValidation;
using Identity.Api.Contrat.Users.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.User
{
    public class EditUserRolesValidator : AbstractValidator<EditUserRolesRequest>
    {
        public EditUserRolesValidator()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("UserId is mendatory.");
            RuleFor(x => x.Roles).NotNull().WithMessage("Roles are mendatory.");
        }
    }
}
