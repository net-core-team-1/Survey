using FluentValidation;
using Identity.Api.Contrats.Roles.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.Role
{
    public class RegisterRoleFeatureValidator : AbstractValidator<RegisterRoleFeatureRequest>
    {
        public RegisterRoleFeatureValidator()
        {
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Role Id is mendatory.");
            RuleFor(x => x.FeatureId).NotEmpty().WithMessage("Feature Id is mendatory.");
        }
    }
}
