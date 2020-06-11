using FluentValidation;
using Identity.Api.Contrat.Roles.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.Role
{
    public class EditRoleValidator : AbstractValidator<EditRoleRequest>
    {
        public EditRoleValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Role Id is mendatory.");
            RuleFor(x => x.AppServiceId).NotEmpty().WithMessage("AppService Id is mendatory.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is mendatory.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is mendatory.");
        }
    }
}
