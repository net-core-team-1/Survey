using FluentValidation;
using Identity.Api.Contrats.Structures.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.Structure
{
    public class UnregisterUserStructureValidator : AbstractValidator<UnregisterUserStructureRequest>
    {
        public UnregisterUserStructureValidator()
        {
            RuleFor(x => x.StructureId).NotEmpty().WithMessage("Structure Id is mendatory");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User is is mendatory");
        }
    }
}
