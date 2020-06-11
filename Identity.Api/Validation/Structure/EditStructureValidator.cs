﻿using FluentValidation;
using Identity.Api.Contrat.Structures.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.Structure
{
    public class EditStructureValidator : AbstractValidator<EditStructureRequest>
    {
        public EditStructureValidator()
        {
            RuleFor(x => x.StructureId).NotEmpty().WithMessage("Structure Id is mendatory");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is mendatory");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is mendatory");
        }
    }
}
