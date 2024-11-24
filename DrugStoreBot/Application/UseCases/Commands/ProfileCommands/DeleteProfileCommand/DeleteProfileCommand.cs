using MediatR;

namespace Application.UseCases.Commands.ProfileCommands.DeleteProfileCommand;

/// <summary>
/// Удаление UserProfile
/// </summary>
/// <param name="ProfileId">Идентификатор Profile.</param>
public record DeleteProfileCommand(Guid ProfileId) : IRequest;