using Domain.Interface;
 using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Domain.Entities
{ 
/// <summary>
/// Представляет базовый класс сущности с уникальным идентификатором.
/// </summary>
public abstract class BaseEntities<T> where T : BaseEntities<T>
{
    private readonly List<IDomainEvent> _domainEvents = [];
    /// <summary>
    /// Получает уникальный идентификатор экземпляра сущности.
/// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="BaseEntities"/> с уникальным идентификатором.
    /// </summary>
    public BaseEntities()
    {
        Id = Guid.NewGuid();
    }
     
    /// <summary>
    /// Добавить доменное событие.
    /// </summary>
    /// <param name="domainEvent">Доменное событие.</param>
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    /// <summary>
    /// Получить доменные события.
    /// </summary>
    /// <returns>Список доменных событий</returns>
    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.AsReadOnly();
    }

    /// <summary>
    /// Очистить доменные события.
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
  
 
    /// <summary>
    /// Определяет, равен ли текущий объект другому объекту того же типа по идентификатору <see cref="Id"/>.
    /// </summary>
    /// <param name="other">Другой объект для сравнения с текущим объектом.</param>
    /// <returns>
    /// <c>true</c>, если текущий объект и <paramref name="other"/> указывают на одну область памяти или имеют одинаковый идентификатор;
    /// в противном случае — <c>false</c>.
    /// </returns>
    /// <remarks>
    /// Этот метод сначала проверяет, ссылаются ли оба объекта на одну и ту же область памяти.
    /// Если нет, то выполняется проверка на соответствие типа и сравнение значений <see cref="Id"/>.
    /// </remarks>
    public override bool Equals(object? other)
    {
        if (ReferenceEquals(this, other))
            return true;

        if (other is BaseEntities<T> otherEntity)
        {
            return Id == otherEntity.Id;
        }

        return false;
        
    }

    /// <summary>
    /// Используется в качестве стандартной хеш-функции.
    /// </summary>
    /// <returns>Хеш-код для текущего объекта.</returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    /// <summary>
    /// Определяет оператор равенства для сравнения двух объектов <see cref="BaseEntities"/>.
    /// </summary>
    /// <param name="entity1">Первая сущность для сравнения.</param>
    /// <param name="entity2">Вторая сущность для сравнения.</param>
    /// <returns>
    /// <c>true</c>, если две сущности равны; в противном случае — <c>false</c>.
    /// </returns>
    public static bool operator ==(BaseEntities<T>? entity1, BaseEntities<T>? entity2)
    {
        if (ReferenceEquals(entity1, entity2)) return true;
        if (entity1 is null || entity2 is null) return false;
        return Equals(entity1, entity2);
    }
    protected void ValidateEntity(AbstractValidator<T> validator)
    {
        var validationResult = validator.Validate((T)this);
        if (!validationResult.IsValid)
        {
            var errorMessages = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException(errorMessages);
        }
    }
    /// <summary>
    /// Определяет оператор неравенства для сравнения двух объектов <see cref="BaseEntities"/>.
    /// </summary>
    /// <param name="entity1">Первая сущность для сравнения.</param>
    /// <param name="entity2">Вторая сущность для сравнения.</param>
    /// <returns>
    /// <c>true</c>, если две сущности не равны; в противном случае — <c>false</c>.
    /// </returns>
    public static bool operator !=(BaseEntities<T>? entity1, BaseEntities<T>? entity2)
    {
        return !(entity1 == entity2);
    }

   
    
}

}