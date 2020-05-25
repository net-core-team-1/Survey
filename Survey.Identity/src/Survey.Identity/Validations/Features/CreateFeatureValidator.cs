using FluentValidation;
using Survey.Identity.Contracts;

namespace Survey.Identity.API.Validations.Features
{
    public class CreateFeatureValidator : AbstractValidator<CreateFeatureRequest>
    {
        public CreateFeatureValidator()
        {
            RuleFor(x => x.Label)
             .NotEmpty()
             .WithMessage("Label is mandatory.");

            RuleFor(x => x.Action)
             .NotEmpty()
             .WithMessage("Action is mandatory.");

        }
    }
}
