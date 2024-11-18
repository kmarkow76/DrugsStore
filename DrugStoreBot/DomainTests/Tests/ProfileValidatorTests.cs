using Domain.Entities;
using Domain.Validators;
using FluentValidation.TestHelper;
using Domain.ValueObject;

using Xunit;

namespace DomainTests.Tests;

public class ProfileValidatorTests
{
    private readonly ProfileValidator _validator = new();

        #region Позитивные тесты

        /// <summary>
        /// Тест успешной валидации корректного объекта Profile.
        /// </summary>
        [Fact]
        public void ProfileValidator_ShouldPass_ForValidProfile()
        {
            // Подготовка
            var email = new Email("valid@example.com");
            var profile = new Profile("valid-external-id", email);

            // Действие
            var result = _validator.TestValidate(profile);

            // Проверка
            result.ShouldNotHaveAnyValidationErrors();
        }

        #endregion

        #region Негативные тесты

        /// <summary>
        /// Тест ошибки валидации, когда ExternalId пустой.
        /// </summary>
        [Fact]
        public void ProfileValidator_ShouldFail_WhenExternalIdIsEmpty()
        {
            // Подготовка
            var email = new Email("valid@example.com");
            var profile = new Profile("", email);
            
            // Действие
            var result = _validator.TestValidate(profile);

            // Проверка
            result.ShouldHaveValidationErrorFor(p => p.ExternalId)
                .WithErrorMessage(ValidationMessage.NotNull);
        }

        /// <summary>
        /// Тест ошибки валидации, когда Value не является корректным адресом электронной почты.
        /// </summary>
        [Fact]
        public void ProfileValidator_ShouldFail_WhenValueIsInvalidEmail()
        {
            // Подготовка
            var email = new Email("invalid-email");
            var profile = new Profile("12345", email);
            
            // Действие
            var result = _validator.TestValidate(profile);

            // Проверка
            result.ShouldHaveValidationErrorFor(p => p.Email)
                .WithErrorMessage("Значение Value не является электронной почтой.");
        }

        /// <summary>
        /// Тест ошибки валидации, когда Value слишком короткий.
        /// </summary>
        [Fact]
        public void ProfileValidator_ShouldFail_WhenValueIsTooShort()
        {
            // Подготовка
            var email = new Email("a@b");
            var profile = new Profile("12345", email);
           
            // Действие
            var result = _validator.TestValidate(profile);

            // Проверка
            result.ShouldHaveValidationErrorFor(p => p.Email)
                .WithErrorMessage(ValidationMessage.WrongLength);
        }

        /// <summary>
        /// Тест ошибки валидации, когда ExternalId слишком длинный.
        /// </summary>
        [Fact]
        public void ProfileValidator_ShouldFail_WhenExternalIdIsTooLong()
        {
            // Подготовка
            var externalId = new string('a', 256);
            var email = new Email("valid@example.com");
            var profile = new Profile("valid.email@example.com", email);
            
            // Действие
            var result = _validator.TestValidate(profile);

            // Проверка
            result.ShouldHaveValidationErrorFor(p => p.ExternalId)
                .WithErrorMessage(ValidationMessage.WrongLength);
        }

        #endregion
}