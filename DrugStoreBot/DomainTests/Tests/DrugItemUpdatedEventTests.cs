using FluentValidation.TestHelper;
using Domain.Validators;
using Domain.DomainEvents;
using FluentValidation;
using Xunit;

namespace DomainTests.Tests;

/// <summary>
/// Тесты для валидатора <see cref="DrugItemUpdatedEventValidator"/>.
/// </summary>
public class DrugItemUpdatedEventTests
{
    private readonly DrugItemUpdatedEventValidator _validator = new();

    #region Позитивные тесты

    /// <summary>
    /// Тестирует успешную валидацию объекта <see cref="DrugItemUpdatedEvent"/> с корректными данными.
    /// </summary>
    [Fact]
    public void DrugItemUpdatedEventValidator_ShouldPass_ForValidEvent()
    {
        // Подготовка
        var drugEvent = new DrugItemUpdatedEvent(Guid.NewGuid(), 10, 20);

        // Действие
        var result = _validator.TestValidate(drugEvent);

        // Проверка
        result.ShouldNotHaveAnyValidationErrors();
    }

    #endregion

    #region Негативные тесты

    /// <summary>
    /// Тестирует ошибку валидации, если <see cref="DrugItemUpdatedEvent.DrugItemId"/> пустой.
    /// </summary>
    [Fact]
    public void DrugItemUpdatedEventValidator_ShouldFail_WhenDrugItemIdIsEmpty()
    {
        // Подготовка
        var drugEvent = new DrugItemUpdatedEvent(Guid.Empty, 10, 20);

        // Действие
        var result = _validator.TestValidate(drugEvent);

        // Проверка
        result.ShouldHaveValidationErrorFor(x => x.DrugItemId)
            .WithErrorMessage(ValidationMessage.NotEmpty);
    }

    /// <summary>
    /// Тестирует ошибку валидации, если <see cref="DrugItemUpdatedEvent.OldCount"/> отрицательный.
    /// </summary>
    [Fact]
    public void DrugItemUpdatedEventValidator_ShouldFail_WhenOldCountIsNegative()
    {
        // Подготовка
        var drugEvent = new DrugItemUpdatedEvent(Guid.NewGuid(), -5, 20);

        // Действие
        var result = _validator.TestValidate(drugEvent);

        // Проверка
        result.ShouldHaveValidationErrorFor(x => x.OldCount)
            .WithErrorMessage(ValidationMessage.PositiveNumber);
    }

    /// <summary>
    /// Тестирует ошибку валидации, если <see cref="DrugItemUpdatedEvent.NewCount"/> отрицательный.
    /// </summary>
    [Fact]
    public void DrugItemUpdatedEventValidator_ShouldFail_WhenNewCountIsNegative()
    {
        // Подготовка
        var drugEvent = new DrugItemUpdatedEvent(Guid.NewGuid(), 10, -10);

        // Действие
        var result = _validator.TestValidate(drugEvent);

        // Проверка
        result.ShouldHaveValidationErrorFor(x => x.NewCount)
            .WithErrorMessage(ValidationMessage.PositiveNumber);
    }

    /// <summary>
    /// Тестирует ошибку валидации, если оба значения <see cref="DrugItemUpdatedEvent.OldCount"/> и <see cref="DrugItemUpdatedEvent.NewCount"/> отрицательные.
    /// </summary>
    [Fact]
    public void DrugItemUpdatedEventValidator_ShouldFail_WhenBothCountsAreNegative()
    {
        // Подготовка
        var drugEvent = new DrugItemUpdatedEvent(Guid.NewGuid(), -5, -10);

        // Действие
        var result = _validator.TestValidate(drugEvent);

        // Проверка
        result.ShouldHaveValidationErrorFor(x => x.OldCount)
            .WithErrorMessage(ValidationMessage.PositiveNumber);
        result.ShouldHaveValidationErrorFor(x => x.NewCount)
            .WithErrorMessage(ValidationMessage.PositiveNumber);
    }

   
    #endregion
}