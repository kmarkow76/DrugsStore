using MediatR;

namespace Application.UseCases.Commands.FavoriteDrugCommands.DeleteFavoriteDrugCommand;

/// <summary>
/// Удаление FavouriteDrug
/// </summary>
/// <param name="FavouriteDrugId">Идентификатор FavouriteDrug.</param>
public record DeleteFavoriteDrugCommand(Guid FavouriteDrugId) : IRequest;