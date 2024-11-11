using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;


public class DrugStoreValidator:AbstractValidator<DrugsStore>
{
    public DrugStoreValidator()
    {
        RuleFor(d => d.DrugNetwork)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLength);
        RuleFor(d => d.Number)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessage.PositiveNumber);
        RuleFor(d => d.Address)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);
        RuleFor(d => d.Address.Street)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(3, 100).WithMessage(ValidationMessage.WrongLength);
        RuleFor(d=> d.Address.City)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 50).WithMessage(ValidationMessage.WrongLength);
        RuleFor(d => d.Address.PostalCode)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Matches("^[0-9]{5,6}$").WithMessage("Почтовый индекс должен представлять собой числовое значение, состоящее из 5–6 цифр.");
        RuleFor (d=>d.Address.House)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Matches(@"^\d+[a-zA-Zа-яА-Я]*$").WithMessage(ValidationMessage.NotCorrect);
        RuleFor(ds => ds.Address.Country)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Matches("^[A-Z]{2}$").WithMessage("Страна должна быть действительным кодом ISO, состоящим из двух заглавных латинских букв.")
            .Must(BeValidCountryCode).WithMessage("Должен быть действительным кодом страны ISO.");
        RuleFor(ds => ds.PhoneNumber)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Matches(@"^\+?\d{9,15}$").WithMessage("Поле 'Телефон' должно содержать от 9 до 15 цифр, включая код страны и начинаясь с '+'");
    }
    private bool BeValidCountryCode(string countryCode)
    {
        var validCountryCodes = new List<string> { "US", "CA", "FR", "DE", "GB", "RU", "JP", "CN" }; // Пример поддерживаемых ISO-кодов
        return validCountryCodes.Contains(countryCode);
    }
}