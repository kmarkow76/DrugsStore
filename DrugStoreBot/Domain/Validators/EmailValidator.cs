using FluentValidation;
using Domain.ValueObject;

namespace Domain.Validators;

public class EmailValidator:AbstractValidator<Email>
{
    public EmailValidator()
    {
        // Валидация для Cost (стоимость)
        RuleFor(d => d.Value)
            .NotEmpty().WithMessage(ValidationMessage.NotNull)
            .Length(2, 255).WithMessage(ValidationMessage.WrongLength)
            .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").WithMessage("Значение {PropertyName} не является электронной почтой.");
    }
}