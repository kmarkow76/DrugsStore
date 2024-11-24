using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

public class DrugItemValidator: AbstractValidator<DrugItem>
{
    public DrugItemValidator()
    {
        RuleFor(d => d.Cost)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .GreaterThan(0).WithMessage(ValidationMessage.PositiveNumber)
            .ScalePrecision(2, 18).WithMessage("Поле должно содержать не более двух знаков после запятой");
        
        RuleFor(d=> d.Count)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessage.PositiveNumber)
            .LessThanOrEqualTo(10000).WithMessage("Количество не должно превышать 10 000");
        
        RuleFor(d => d.DrugId)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

        RuleFor(d => d.DrugStoreId)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);
    }
    
}