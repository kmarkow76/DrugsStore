using MediatR;

namespace Application.UseCases.Commands.ProfileCommands.DeleteProfileCommand;

/// <summary>
/// Удаление UserProfile
/// </summary>
/// <param name="ProfileId">Идентификатор UserProfile.</param>
public record DeleteProfileCommand(Guid ProfileId) : IRequest;