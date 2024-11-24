using Domain.Entities;

namespace Application.Interface.Repositories.CountryRepositories;

/// <summary>
/// Репозиторий для операций чтения сущности Country
/// </summary>
public interface ICountryReadRepository: IReadRepository<Country>
{
    
}