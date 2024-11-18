using Domain.Entities;
using Domain.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace DomainTests.Tests;

public class DrugValidatorTests
{
    private readonly DrugValidator _validator = new();

    #region Позитивные тесты

    /// <summary>
    /// Успешная валидация корректного объекта Drug через конструктор.
    /// </summary>
    [Fact]
    public void DrugValidator_ShouldPass_ForValidDrug()
    {
        // Подготовка
        var drug = new Drug
        {
            Name = "Aspirin",
            Manufacturer = "Bayer",
            CountryCodeId = "DE"
        };


        // Проверка
        var result = _validator.TestValidate(drug);

        // Утверждение
        result.ShouldNotHaveAnyValidationErrors();
    }

    #endregion

    #region Негативные тесты

    /// <summary>
    /// Ошибка валидации при пустом имени.
    /// </summary>
    [Fact]
    public void DrugValidator_ShouldFail_WhenNameIsEmpty()
    {
        // Подготовка
        var drug = new Drug
        {
            Name = "",
            Manufacturer = "Bayer",
            CountryCodeId = "DE"
        };


        // Проверка
        var result = _validator.TestValidate(drug);

        // Утверждение
        result.ShouldHaveValidationErrorFor(d => d.Name)
            .WithErrorMessage(ValidationMessage.NotEmpty);
    }

    /// <summary>
    /// Ошибка валидации, когда Manufacturer содержит некорректные символы.
    /// </summary>
    [Fact]
    public void DrugValidator_ShouldFail_WhenManufacturerHasInvalidCharacters()
    {
        // Подготовка
        var drug = new Drug
        {
            Name = "Aspirin",
            Manufacturer = "Bayer@123",
            CountryCodeId = "DE"
        };


        // Проверка
        var result = _validator.TestValidate(drug);

        // Утверждение
        result.ShouldHaveValidationErrorFor(d => d.Manufacturer)
            .WithErrorMessage(ValidationMessage.InvalidCharacters);
    }

    /// <summary>
    /// Ошибка валидации при некорректном CountryCodeId.
    /// </summary>
    [Fact]
    public void DrugValidator_ShouldFail_WhenCountryCodeIdIsInvalid()
    {
        // Подготовка
        var drug = new Drug
        {
            Name = "Aspirin",
            Manufacturer = "Bayer",
            CountryCodeId = "ZZ"
        };


        // Проверка
        var result = _validator.TestValidate(drug);

        // Утверждение
        result.ShouldHaveValidationErrorFor(d => d.CountryCodeId)
            .WithErrorMessage("Должен существовать в списке допустимых кодов стран.");
    }

    #endregion
}