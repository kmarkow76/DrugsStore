using Domain.Entities;
using Domain.ValueObject;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands.UpdateProfileCommand;

/// <summary>
/// Обновление Profile
/// </summary>
/// <param name="ProfileId">Идентификатор Profile.</param>
/// <param name="ExternalId">Внешний идентификатор (телеграм).</param>
/// <param name="Email">Электронная почта.</param>
public record UpdateProfileCommand(Guid ProfileId, string ExternalId, Email Email) : IRequest<Profile>;