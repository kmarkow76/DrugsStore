namespace Application.Interface.Repositories;

public interface IWriteRepository<T> where T : class
{
  
    /// Метод для добавления сущносте
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