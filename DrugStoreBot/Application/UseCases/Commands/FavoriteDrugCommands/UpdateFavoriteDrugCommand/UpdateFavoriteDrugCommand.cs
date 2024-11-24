using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.FavoriteDrugCommands.UpdateFavoriteDrugCommand;

/// <summary>
/// Обновление FavoriteDrug
/// </summary>
/// <param name="ProfileId">Идентификатор Profile.</param>
/// <param name="Profile">Profile.</param>
/// <param name="DrugId">Идентификатор Drug.</param>
/// <param name="Drug">Drug.</param>
/// <param name="DrugStoreId">Идентификатор DrugStore.</param>
/// <param name="DrugStore">DrugStore.</param>
public record UpdateFavoriteDrugCommand(Guid FavoriteDrugId,Guid ProfileId, Profile Profile, Guid DrugId, Drug Drug, Guid DrugStoreId, DrugsStore DrugStore) : IRequest<FavoriteDrug>;