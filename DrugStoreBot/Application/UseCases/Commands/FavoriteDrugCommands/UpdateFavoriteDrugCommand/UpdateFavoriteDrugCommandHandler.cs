using Application.Interface.Repositories.DrugStoreRepositories;
using Application.Interface.Repositories.FavoriteDrugRepositories;
using Application.UseCases.Commands.DrugStoreCommands.UpdateDrugStoreCommand;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.FavoriteDrugCommands.UpdateFavoriteDrugCommand;

/// <summary>
/// Обработчик UpdateFavoriteDrugCommand
/// </summary>
public class UpdateFavouriteDrugCommandHandler : IRequestHandler<UpdateFavoriteDrugCommand, FavoriteDrug>
{
    private readonly IFavouriteDrugWriteRepository _favouriteDrugWriteRepository;
    private readonly IFavouriteDrugReadRepository _favouriteDrugReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="favouriteDrugWriteRepository">Репозиторий записи FavoriteDrugWriteRepository.</param>
    /// <param name="favouriteDrugReadRepository">Репозиторий чтения FavoriteDrugWriteRepository.</param>
    public UpdateFavouriteDrugCommandHandler(IFavouriteDrugWriteRepository favouriteDrugWriteRepository, IFavouriteDrugReadRepository favouriteDrugReadRepository)
    {
        _favouriteDrugWriteRepository = favouriteDrugWriteRepository;
        _favouriteDrugReadRepository = favouriteDrugReadRepository;
    }
    
    /// <summary>
    /// Обработка обновления FavoriteDrug
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный FavoriteDrug.</returns>
    public async Task<FavoriteDrug> Handle(UpdateFavoriteDrugCommand request, CancellationToken cancellationToken)
    {
        var favouriteDrug = await _favouriteDrugReadRepository.GetByIdAsync(request.FavoriteDrugId, cancellationToken);
        favouriteDrug.Update(
            request.ProfileId,
            request.DrugId,
            request.Profile,
            request.Drug,
            request.DrugStoreId,
            request.DrugStore);
        await _favouriteDrugWriteRepository.UpdateAsync(favouriteDrug, cancellationToken);
        return favouriteDrug;
    }
}