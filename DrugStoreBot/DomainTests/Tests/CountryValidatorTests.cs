using Domain.Entities;
using Domain.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace DomainTests.Tests;

public class CountryValidatorTests
{
    private readonly CountryValidator _validator = new();

    #region Позитивные тесты

    /// <summary>
    /// Тестирует успешную валидацию объекта <see cref="Country"/> с корректными данными.
    /// </summary>
    [Fact]
    public void CountryValidator_ShouldPass_ForValidCountry()
    {
        // Подготовка
        var country = new Country("United States", "US");

        // Действие
        var result = _validator.TestValidate(country);

        // Проверка
        result.ShouldNotHaveAnyValidationErrors();
    }

    #endregion

    #region Негативные тесты
    /// <summary>
    ///Тестирует ошибку валидации,когда название страны не может быть Null
    /// </summary>
    [Fact]
    public void CountryValidator_ShouldFail_WhenNameIsNull()
    {
        // Подготовка
        var country = new Country(null, "US");

        // Действие
        var result = _validator.TestValidate(country);

        // Проверка
        result.ShouldHaveValidationErrorFor(c => c.Name)
            .WithErrorMessage(ValidationMessage.NotNull);
    }
    /// <summary>
    /// Тестирует ошибку валидации, когда название страны пустое
    /// </summary>
    [Fact]
    public void CountryValidator_ShouldFail_WhenNameIsEmpty()
    {
        // Подготовка
        var country = new Country("", "US");

        // Действие
        var result = _validator.TestValidate(country);

        // Проверка
        result.ShouldHaveValidationErrorFor(c => c.Name)
            .WithErrorMessage(ValidationMessage.NotEmpty);
    }
    /// <summary>
    /// Тестирует ошибку валидации, когда название страны короткое
    /// </summary>
    [Fact]
    public void CountryValidator_ShouldFail_WhenNameIsTooShort()
    {
        // Подготовка
        var country = new Country("A", "US");

        // Действие
        var result = _validator.TestValidate(country);

        // Проверка
        result.ShouldHaveValidationErrorFor(c => c.Name)
            .WithErrorMessage(ValidationMessage.WrongLength);
    }
    /// <summary>
    /// Тестирует ошибку валидации, когда название страны содержит не поддерживаемые пустое
    /// </summary>
    [Fact]
    public void CountryValidator_ShouldFail_WhenNameHasInvalidCharacters()
    {
        // Подготовка
        var country = new Country("France123", "FR");

        // Действие
        var result = _validator.TestValidate(country);

        // Проверка
        result.ShouldHaveValidationErrorFor(c => c.Name)
            .WithErrorMessage(ValidationMessage.InvalidCharacters);
    }

    [Fact]
    public void CountryValidator_ShouldFail_WhenCodeIsNull()
    {
        // Подготовка
        var country = new Country("Canada", null);

        // Действие
        var result = _validator.TestValidate(country);

        // Проверка
        result.ShouldHaveValidationErrorFor(c => c.Code)
            .WithErrorMessage(ValidationMessage.NotNull);
    }
    /// <summary>
    ///Тестирует ошибку валидации,когда код страны пустой
    /// </summary>
    [Fact]
    public void CountryValidator_ShouldFail_WhenCodeIsEmpty()
    {
        // Подготовка
        var country = new Country("Canada", "");

        // Действие
        var result = _validator.TestValidate(country);

        // Проверка
        result.ShouldHaveValidationErrorFor(c => c.Code)
            .WithErrorMessage(ValidationMessage.NotEmpty);
    }
    /// <summary>
    /// Тестирует ошибку валидации, когда код страны длинный
    /// </summary>
    [Fact]
    public void CountryValidator_ShouldFail_WhenCodeIsTooLong()
    {
        // Подготовка
        var country = new Country("Canada", "CAN");

        // Действие
        var result = _validator.TestValidate(country);

        // Проверка
        result.ShouldHaveValidationErrorFor(c => c.Code)
            .WithErrorMessage("Должен состоять только из 2 заглавных букв");
    }
    /// <summary>
    /// Тестирует ошибку валидации, когда код страны содержит маленькие буквы
    /// </summary>
    [Fact]
    public void CountryValidator_ShouldFail_WhenCodeHasLowerCaseLetters()
    {
        // Подготовка
        var country = new Country("Germany", "de");

        // Действие
        var result = _validator.TestValidate(country);

        // Проверка
        result.ShouldHaveValidationErrorFor(c => c.Code)
            .WithErrorMessage("Должен состоять только из 2 заглавных букв");
    }

    #endregion
}