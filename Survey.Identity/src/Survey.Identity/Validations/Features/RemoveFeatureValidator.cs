using FluentValidation;
using Survey.Identity.Contracts;

namespace Survey.Identity.API.Validations.Features
{
    public class RemoveFeatureValidator : AbstractValidator<RemoveFeatureRequest>
    {
        public RemoveFeatureValidator()
        {
            RuleFor(x => x.Reason)
           .NotEmpty()
           .WithMessage("Reason is mandatory.");

        }
    }
}
