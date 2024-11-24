namespace Application.Interface.Repositories;

public interface IWriteReposirory<T> where T : class
{
    /// <summary>
    /// Репозиторий для операций чтения
    /// </summary>
    IReadOnlyList<T> ReadRepository { get; }
    
    /// <summary>
    /// Метод для добавления сущностей
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddAsync(T entity,CancellationToken cancellationToken=default);
    
    /// <summary>
    /// Метод для обновления сущности
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateAsync(T entity, CancellationToken cancellationToken=default);
    
    /// <summary>
    /// Метод для удаления сущности по идентификатору
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteAsync(Guid Id, CancellationToken cancellationToken=default);
}