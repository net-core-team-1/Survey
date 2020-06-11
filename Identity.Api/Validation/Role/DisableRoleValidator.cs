using FluentValidation;
using Identity.Api.Contrat.Roles.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.Role
{
    public class DisableRoleValidator : AbstractValidator<DisableRoleRequest>
    {
        public DisableRoleValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Role Id is mendatory.");
        }
    }
}
