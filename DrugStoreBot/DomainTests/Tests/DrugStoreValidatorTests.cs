using Domain.Entities;
using Domain.Validators;
using FluentValidation.TestHelper;
using Domain.ValueObject;
using Xunit;

namespace DomainTests.Tests;

public class DrugStoreValidatorTests
{
      private readonly DrugStoreValidator _validator = new();

        #region Позитивные тесты

        /// <summary>
        /// Тестирует успешную валидацию для корректного объекта <see cref="DrugsStore"/>.
        /// </summary>
        [Fact]
        public void DrugStoreValidator_ShouldPass_ForValidDrugsStore()
        {
            // Подготовка
            var drugsStore = new DrugsStore(
                "Аптечная сеть",
                1,
                new Address("Ленина", "Москва", "123456", "12А", "RU"),
                "+71234567890"
            );

            // Действие
            var result = _validator.TestValidate(drugsStore);

            // Проверка
            result.ShouldNotHaveAnyValidationErrors();
        }

        #endregion

        #region Негативные тесты

        /// <summary>
        /// Тестирует ошибку валидации, когда DrugNetwork пустой.
        /// </summary>
        [Fact]
        public void DrugStoreValidator_ShouldFail_WhenDrugNetworkIsEmpty()
        {
            // Подготовка
            var drugsStore = new DrugsStore(
                "",
                1,
                new Address("Ленина", "Москва", "123456", "12А", "RU"),
                "+71234567890"
            );

            // Действие
            var result = _validator.TestValidate(drugsStore);

            // Проверка
            result.ShouldHaveValidationErrorFor(ds => ds.DrugNetwork)
                .WithErrorMessage(ValidationMessage.NotEmpty);
        }

        /// <summary>
        /// Тестирует ошибку валидации, когда Address.City слишком короткий.
        /// </summary>
        [Fact]
        public void DrugStoreValidator_ShouldFail_WhenCityIsTooShort()
        {
            // Подготовка
            var drugsStore = new DrugsStore(
                "Аптечная сеть",
                1,
                new Address("Ленина", "М", "123456", "12А", "RU"),
                "+71234567890"
            );

            // Действие
            var result = _validator.TestValidate(drugsStore);

            // Проверка
            result.ShouldHaveValidationErrorFor(ds => ds.Address.City)
                .WithErrorMessage(ValidationMessage.WrongLength);
        }

        /// <summary>
        /// Тестирует ошибку валидации, когда PostalCode содержит некорректные символы.
        /// </summary>
        [Fact]
        public void DrugStoreValidator_ShouldFail_WhenPostalCodeIsInvalid()
        {
            // Подготовка
            var drugsStore = new DrugsStore(
                "Аптечная сеть",
                1,
                new Address("Ленина", "Москва", "ABC123", "12А", "RU"),
                "+71234567890"
            );

            // Действие
            var result = _validator.TestValidate(drugsStore);

            // Проверка
            result.ShouldHaveValidationErrorFor(ds => ds.Address.PostalCode)
                .WithErrorMessage("Почтовый индекс должен представлять собой числовое значение, состоящее из 5–6 цифр.");
        }

        /// <summary>
        /// Тестирует ошибку валидации, когда Country не входит в список ISO-кодов.
        /// </summary>
        [Fact]
        public void DrugStoreValidator_ShouldFail_WhenCountryCodeIsInvalid()
        {
            // Подготовка
            var drugsStore = new DrugsStore(
                "Аптечная сеть",
                1,
                new Address("Ленина", "Москва", "123456", "12А", "ZZ"),
                "+71234567890"
            );

            // Действие
            var result = _validator.TestValidate(drugsStore);

            // Проверка
            result.ShouldHaveValidationErrorFor(ds => ds.Address.Country)
                .WithErrorMessage("Должен быть действительным кодом страны ISO.");
        }

        /// <summary>
        /// Тестирует ошибку валидации, когда PhoneNumber некорректный.
        /// </summary>
        [Fact]
        public void DrugStoreValidator_ShouldFail_WhenPhoneNumberIsInvalid()
        {
            // Подготовка
            var drugsStore = new DrugsStore(
                "Аптечная сеть",
                1,
                new Address("Ленина", "Москва", "123456", "12А", "RU"),
                "123-456"
            );

            // Действие
            var result = _validator.TestValidate(drugsStore);

            // Проверка
            result.ShouldHaveValidationErrorFor(ds => ds.PhoneNumber)
                .WithErrorMessage("Поле 'Телефон' должно содержать от 9 до 15 цифр, включая код страны и начинаясь с '+'");
        }

        #endregion
}