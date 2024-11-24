using Domain.Entities;

namespace Application.Interface.Repositories.CountryRepositories;

/// <summary>
/// Репозиторий для операций записи сущности Country
/// </summary>
public interface ICountryWriteRepository  : IWriteReposirory<Country>
{
    
}