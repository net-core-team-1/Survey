using FluentValidation;
using Survey.Identity.Contracts;

namespace Survey.Identity.API.Validations.Features
{
    public class EditFeatureValidator : AbstractValidator<EditFeatureRequest>
    {
        public EditFeatureValidator()
        {
            RuleFor(x => x.Label)
             .NotEmpty()
             .WithMessage("Action is mandatory.");


        }
    }
}
