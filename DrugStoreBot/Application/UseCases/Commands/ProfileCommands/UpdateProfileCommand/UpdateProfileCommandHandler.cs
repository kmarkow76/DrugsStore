using Application.Interface.Repositories.IProfileRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands.UpdateProfileCommand;

/// <summary>
/// Обработчик UpdateProfileCommand
/// </summary>
public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, Profile>
{
    private readonly IProfileWriteRepository _profileWriteRepository;
    private readonly IProfileReadRepository _profileReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    public UpdateProfileCommandHandler(IProfileWriteRepository profileWriteRepository, IProfileReadRepository profileReadRepository)
    {
        _profileWriteRepository = profileWriteRepository;
        _profileReadRepository = profileReadRepository;
    }
    
    /// <summary>
    /// Обработка обновления Profile
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный Profile.</returns>
    public async Task<Profile> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var userProfile = await _profileReadRepository.GetByIdAsync(request.ProfileId, cancellationToken);
        userProfile.Update(
            request.ExternalId,
            request.Email);
        await _profileWriteRepository.UpdateAsync(userProfile, cancellationToken);
        return userProfile;
    }
}