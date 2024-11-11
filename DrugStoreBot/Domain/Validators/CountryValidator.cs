using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

public class CountryValidator : AbstractValidator<Country>
{
    public CountryValidator()
    {
        RuleFor(c => c.Name)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLength)
            .Matches("^[a-zA-Z ]+$").WithMessage(ValidationMessage.InvalidCharacters);

        RuleFor(c => c.Code)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Matches("^[A-Z]{2}$").WithMessage("Должен состоять только из 2 заглавных букв");
    }
    
}