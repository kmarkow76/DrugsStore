
using FluentValidation;
using Domain.Entities;


namespace Domain.Validators;

public class DrugValidator: AbstractValidator<Drug>
{
    public DrugValidator()
    { 
        //Объяснить BaseValueObj (подробно)
        RuleFor(d => d.Name)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 150).WithMessage(ValidationMessage.WrongLength)
            .Matches("^[a-zA-Z ]+$").WithMessage(ValidationMessage.InvalidCharacters); 
        
        RuleFor(d => d.Manufacturer)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLength)
            .Matches("^[a-zA-Z -]+$").WithMessage(ValidationMessage.InvalidCharacters);
        RuleFor(d => d.CountryCodeId)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Matches("^[A-Z]{2}$").WithMessage("Должен состоять только из 2 заглавных букв")
            .Must(BeAValidCountryCode).WithMessage("Должен существовать в списке допустимых кодов стран.");
    }
    private bool BeAValidCountryCode(string countryCodeId)
    {
        var countryCodes = new List<string> { "US", "CA", "FR", "DE", "GB", "RU", "JP", "CN" }; 
        return countryCodes.Contains(countryCodeId);
    }

}