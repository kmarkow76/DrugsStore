using Domain.Validators;
using Domain.ValueObject;
using Domain.Entities;

namespace Domain.Entities;

/// <summary>
/// Профиль пользователя(тг)
/// </summary>
public class Profile:BaseEntities<Profile>
{
    public Profile(string externalId, Email? email)
    {
        ExternalId = externalId;
        Email = email;

        ValidateEntity(new ProfileValidator());
    }

    /// <summary>
    /// Внешний идентификатор.
    /// </summary>
    public string ExternalId { get; private set; }

    /// <summary>
    /// Электронная почта.
    /// </summary>
    public Email? Email { get; private set; }

    // Навигационное свойство для связи с FavoriteDrug.
    public List<FavoriteDrug> FavoriteDrugs { get; private set; } = [];
    public void Update(string externalId, Email? email)
    {
        ExternalId = externalId;
        Email = email;

        ValidateEntity(new ProfileValidator());
    }

}