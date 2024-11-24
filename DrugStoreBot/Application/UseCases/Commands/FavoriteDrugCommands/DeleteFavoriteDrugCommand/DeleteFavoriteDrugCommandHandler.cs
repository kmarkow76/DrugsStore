using Application.Interface.Repositories.DrugStoreRepositories;
using Application.Interface.Repositories.FavoriteDrugRepositories;
using MediatR;

namespace Application.UseCases.Commands.FavoriteDrugCommands.DeleteFavoriteDrugCommand;

/// <summary>
/// Обработчик DeleteFavoriteDrugCommand
/// </summary>
public class DeleteFavoriteDrugCommandHandler : IRequestHandler<DeleteFavoriteDrugCommand>
{
    private readonly IFavouriteDrugWriteRepository _favouriteDrugWriteRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="favoriteDrugWriteRepository">Репозиторий чтения FavouriteDrugWriteRepository.</param>
    public DeleteFavoriteDrugCommandHandler(IFavouriteDrugWriteRepository favoriteDrugWriteRepository)
    {
        _favouriteDrugWriteRepository = favoriteDrugWriteRepository;
    }
    
    /// <summary>
    /// Обработка удаления FavoriteDrug
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task Handle(DeleteFavoriteDrugCommand request, CancellationToken cancellationToken)
    {
        await _favouriteDrugWriteRepository.DeleteAsync(request.FavouriteDrugId, cancellationToken);
    }
}