using Application.Interface.Repositories.FavoriteDrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.FavoriteDrugQueries;

/// <summary>
/// Обработчик GetFavouriteDrugByIdQuery
/// </summary>
public class GetFavouriteDrugByIdQueryHandler : IRequestHandler<GetFavouriteDrugByIdQuery, FavoriteDrug?>
{
    private readonly IFavouriteDrugReadRepository _favouriteDrugReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="favouriteDrugReadRepository">Репозиторий чтения FavouriteDrugReadRepository.</param>
    public GetFavouriteDrugByIdQueryHandler(
        IFavouriteDrugReadRepository favouriteDrugReadRepository)
    {
        _favouriteDrugReadRepository = favouriteDrugReadRepository;
    }

    /// <summary>
    /// Обработка получения FavouriteDrug по идентификатору
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>FavouriteDrug.</returns>
    public async Task<FavoriteDrug> Handle(GetFavouriteDrugByIdQuery request, CancellationToken cancellationToken)
    {
        var response =  await _favouriteDrugReadRepository.GetByIdAsync(request.Id, cancellationToken);
        return response;
    }
}
