using FluentValidation;
using Identity.Api.Contrat.Structures.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.Structure
{
    public class DisableStructureValidator : AbstractValidator<DisableStructureRequest>
    {
        public DisableStructureValidator()
        {
            RuleFor(x => x.StructureId).NotEmpty().WithMessage("Structure Id is mendatory");
            RuleFor(x => x.Reason).NotEmpty().WithMessage("Disabling reason is mendatory");
        }
    }
}
