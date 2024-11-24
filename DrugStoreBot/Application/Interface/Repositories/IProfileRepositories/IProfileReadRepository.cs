using Domain.Entities;

namespace Application.Interface.Repositories.IProfileRepositories;


/// <summary>
/// Репозиторий для операций чтения сущности Profile
/// </summary>
public interface IProfileReadRepository: IReadRepository<Profile>
{
    
}