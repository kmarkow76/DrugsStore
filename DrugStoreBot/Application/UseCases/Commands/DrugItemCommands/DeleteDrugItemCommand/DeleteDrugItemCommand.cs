using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands.DeleteDrugItemCommand;

/// <summary>
/// Удаление DrugItem
/// </summary>
/// <param name="DrugItemId">Идентификатор DrugItem.</param>
public record DeleteDrugItemCommand(Guid DrugItemId) : IRequest;