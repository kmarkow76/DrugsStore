using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands.CreateCountryCommand;

/// <summary>
/// Создание Country
/// </summary>
/// <param name="Name">Название.</param>
/// <param name="Code">Код страны.</param>
public record CreateCountryCommand(string Name, string Code) : IRequest<Country>;