using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands.UpdateCountryCommand;

/// <summary>
/// Обновление Country
/// </summary>
/// <param name="CountryId">Идентификатор Country.</param>
/// <param name="Name">Название.</param>
/// <param name="Code">Код страны.</param>
public record UpdateCountryCommand(Guid CountryId, string Name, string Code) : IRequest<Country>;