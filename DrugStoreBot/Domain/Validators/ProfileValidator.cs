using FluentValidation;
using Domain.Entities;

namespace Domain.Validators;

public class ProfileValidator : AbstractValidator<Profile>
{
    public ProfileValidator()
    {
        // Валидация для ExternalId (внешнего идентификатора)
        RuleFor(d => d.ExternalId)
            .NotEmpty().WithMessage(ValidationMessage.NotNull)
            .Length(2, 255).WithMessage(ValidationMessage.WrongLength);
    }
}