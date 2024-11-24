using Domain.Entities;
using Domain.ValueObject;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands.CreateProfileCommand;

/// <summary>
/// Создание Profile
/// </summary>
/// <param name="ExternalId">Внешний идентификатор (телеграм).</param>
/// <param name="Email">Электронная почта.</param>
public record CreateProfileCommand(string ExternalId, Email Email) : IRequest<Profile>;