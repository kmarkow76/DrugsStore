using MediatR;

namespace Application.UseCases.Commands.CountryCommands.DeleteCountryCommand;
/// <summary>
/// Удаление Country
/// </summary>
/// <param name="CountryId">Идентификатор Country.</param>
public record DeleteCountryCommand(Guid CountryId) : IRequest;