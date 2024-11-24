using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands.DeleteDrugStoreCommand;

/// <summary>
/// Удаление DrugStore
/// </summary>
/// <param name="DrugStoreId">Идентификатор DrugStore.</param>
public record DeleteDrugStoreCommand(Guid DrugStoreId) : IRequest;