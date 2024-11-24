using Application.Interface.Repositories.FavoriteDrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.FavoriteDrugCommands.CreateFavoriteDrugCommand;
/// <summary>
/// Обработчик CreateFavoriteDrugCommand
/// </summary>
public class CreateFavoriteDrugCommandHandler : IRequestHandler<CreateFavoriteDrugCommand, FavoriteDrug>
{
    private readonly IFavouriteDrugWriteRepository _favouriteDrugWriteRepository;
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="favouriteDrugWriteRepository">Репозиторий чтения FavouriteDrugWriteRepository.</param>
    public CreateFavoriteDrugCommandHandler(IFavouriteDrugWriteRepository favouriteDrugWriteRepository)
    {
        _favouriteDrugWriteRepository = favouriteDrugWriteRepository;
    }
    /// <summary>
    /// Обработка создания FavoriteDrug
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданный FavouriteDrug.</returns>
    public async Task<FavoriteDrug> Handle(CreateFavoriteDrugCommand request, CancellationToken cancellationToken)
    {
        var favouriteDrug = new FavoriteDrug( request.ProfileId,
            request.DrugId,
            request.Profile,
            request.Drug,
            request.DrugStoreId,
            request.DrugStore);
        await _favouriteDrugWriteRepository.AddAsync(favouriteDrug, cancellationToken);
        return favouriteDrug;
    }
}