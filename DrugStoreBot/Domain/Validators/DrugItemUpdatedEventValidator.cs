using Domain.DomainEvents;
using FluentValidation;

namespace Domain.Validators;

public class DrugItemUpdatedEventValidator: AbstractValidator<DrugItemUpdatedEvent>
{
    public DrugItemUpdatedEventValidator()
    {
        RuleFor(x => x.DrugItemId)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);
        
        RuleFor(x => x.OldCount)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessage.PositiveNumber);

        RuleFor(x => x.NewCount)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessage.PositiveNumber);
    }
}