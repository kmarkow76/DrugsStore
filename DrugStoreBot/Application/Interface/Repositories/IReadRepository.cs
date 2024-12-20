using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.AspNetCore.OData.Query;

namespace Application.Interface.Repositories;

public interface IReadRepository<T> where T : class
{
    /// <summary>
    /// Получение сущности по идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<T> GetByIdAsync (Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получение запроса с помощью OData
    /// </summary>
    /// <param name="queryOptions"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IQueryable> GetQueryableAsync(ODataQueryOptions<T> queryOptions, CancellationToken cancellationToken=default);
}