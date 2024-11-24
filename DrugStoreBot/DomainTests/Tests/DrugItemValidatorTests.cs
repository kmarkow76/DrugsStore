using Domain.Entities;
using Domain.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace DomainTests.Tests;

/// <summary>
/// Тестирует валидатор для объекта <see cref="DrugItem"/>.
/// </summary>
public class DrugItemValidatorTests
{
    private readonly DrugItemValidator _validator = new();

    #region Позитивные тесты

    /// <summary>
    /// Тестирует успешную валидацию для объекта <see cref="DrugItem"/>, когда все данные корректны.
    /// </summary>
    [Fact]
    public void DrugItemValidator_ShouldPass_ForValidDrugItem()
    {
        // Подготовка
        var drugItem = new DrugItem(
            Guid.NewGuid(),
            new Drug(),
            new DrugsStore(),
            Guid.NewGuid(),
            50,
            100.00M
        );

        // Действие
        var result = _validator.TestValidate(drugItem);

        // Проверка
        result.ShouldNotHaveAnyValidationErrors();
    }

    #endregion

    #region Негативные тесты

    /// <summary>
    /// Тестирует ошибку валидации, когда цена товара равна 0.
    /// </summary>
    [Fact]
    public void DrugItemValidator_ShouldFail_WhenCostIsZero()
    {
        // Подготовка
        var drugItem = new DrugItem(
            Guid.NewGuid(),
            new Drug(),
            new DrugsStore(),
            Guid.NewGuid(),
            50,
            0M
        );

        // Действие
        var result = _validator.TestValidate(drugItem);

        // Проверка
        result.ShouldHaveValidationErrorFor(d => d.Cost)
            .WithErrorMessage(ValidationMessage.PositiveNumber);
    }

    /// <summary>
    /// Тестирует ошибку валидации, когда количество товара меньше 0.
    /// </summary>
    [Fact]
    public void DrugItemValidator_ShouldFail_WhenCountIsNegative()
    {
        // Подготовка
        var drugItem = new DrugItem(
            Guid.NewGuid(),
            new Drug(),
            new DrugsStore(),
            Guid.NewGuid(),
            -1,
            100.00M
        );

        // Действие
        var result = _validator.TestValidate(drugItem);

        // Проверка
        result.ShouldHaveValidationErrorFor(d => d.Count)
            .WithErrorMessage(ValidationMessage.PositiveNumber);
    }

    /// <summary>
    /// Тестирует ошибку валидации, когда количество товара превышает 10 000.
    /// </summary>
    [Fact]
    public void DrugItemValidator_ShouldFail_WhenCountExceedsMax()
    {
        // Подготовка
        var drugItem = new DrugItem(
            Guid.NewGuid(),
            new Drug(),
            new DrugsStore(),
            Guid.NewGuid(),
            10001,
            100.00M
        );

        // Действие
        var result = _validator.TestValidate(drugItem);

        // Проверка
        result.ShouldHaveValidationErrorFor(d => d.Count)
            .WithErrorMessage("Количество не должно превышать 10 000");
    }

    /// <summary>
    /// Тестирует ошибку валидации, когда DrugID пустой.
    /// </summary>
    [Fact]
    public void DrugItemValidator_ShouldFail_WhenDrugIDIsEmpty()
    {
        // Подготовка
        var drugItem = new DrugItem(
            Guid.Empty,
            new Drug(),
            new DrugsStore(),
            Guid.NewGuid(),
            50,
            100.00M
        );

        // Действие
        var result = _validator.TestValidate(drugItem);

        // Проверка
        result.ShouldHaveValidationErrorFor(d => d.DrugId)
            .WithErrorMessage(ValidationMessage.NotNull);
    }

    /// <summary>
    /// Тестирует ошибку валидации, когда DrugStoreId пустой.
    /// </summary>
    [Fact]
    public void DrugItemValidator_ShouldFail_WhenDrugStoreIdIsEmpty()
    {
        // Подготовка
        var drugItem = new DrugItem(
            Guid.NewGuid(),
            new Drug(),
            new DrugsStore(),
            Guid.Empty,
            50,
            100.00M
        );

        // Действие
        var result = _validator.TestValidate(drugItem);

        // Проверка
        result.ShouldHaveValidationErrorFor(d => d.DrugStoreId)
            .WithErrorMessage(ValidationMessage.NotNull);
    }

    #endregion
}