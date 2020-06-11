using FluentValidation;
using Identity.Api.Contrats.Users.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.User
{
    public class UnregisterUserRoleValidator : AbstractValidator<UnregisterUserRoleRequest>
    {
        public UnregisterUserRoleValidator()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("UserId is mendatory.");
            RuleFor(x => x.RoleId).NotNull().WithMessage("RoleId is mendatory.");
        }
    }
}
