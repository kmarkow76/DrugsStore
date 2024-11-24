using MediatR;

namespace Application.UseCases.Commands.DrugCommands.DeleteDrugCommand;

/// <summary>
/// Удаление Drug
/// </summary>
/// <param name="DrugId">Идентификатор Drug.</param>
public record DeleteDrugCommand(Guid DrugId) : IRequest;