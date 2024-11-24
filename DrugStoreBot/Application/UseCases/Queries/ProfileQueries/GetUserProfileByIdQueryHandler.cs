using Application.Interface.Repositories;
using Application.Interface.Repositories.IProfileRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.ProfileQueries;
/// <summary>
/// Обработчик GetUserProfileByIdQuery
/// </summary>
public class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery,Profile>
{
    private readonly IProfileReadRepository _profileReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="profileReadRepository">Репозиторий чтения UserProfileReadRepository.</param>
    public GetUserProfileByIdQueryHandler(IProfileReadRepository profileReadRepository)
    {
        _profileReadRepository = profileReadRepository;
    }
    
    /// <summary>
    /// Обработка получения UserProfile по идентификатору
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>UserProfile.</returns>
    public async Task<Profile> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
    {
        var response =  await _profileReadRepository.GetByIdAsync(request.Id, cancellationToken);
        return response;
    }
}