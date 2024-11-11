namespace Domain.Entities
{ 
/// <summary>
/// Представляет базовый класс сущности с уникальным идентификатором.
/// </summary>
public class BaseEntities
{
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

        if (other is BaseEntities otherEntity)
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
    public static bool operator ==(BaseEntities? entity1, BaseEntities? entity2)
    {
        if (ReferenceEquals(entity1, entity2)) return true;
        if (entity1 is null || entity2 is null) return false;
        return Equals(entity1, entity2);
    }

    /// <summary>
    /// Определяет оператор неравенства для сравнения двух объектов <see cref="BaseEntities"/>.
    /// </summary>
    /// <param name="entity1">Первая сущность для сравнения.</param>
    /// <param name="entity2">Вторая сущность для сравнения.</param>
    /// <returns>
    /// <c>true</c>, если две сущности не равны; в противном случае — <c>false</c>.
    /// </returns>
    public static bool operator !=(BaseEntities? entity1, BaseEntities? entity2)
    {
        return !(entity1 == entity2);
    }
}

}