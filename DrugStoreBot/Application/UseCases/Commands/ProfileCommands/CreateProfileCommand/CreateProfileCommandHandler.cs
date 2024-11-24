using Application.Interface.Repositories.IProfileRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands.CreateProfileCommand;

/// <summary>
/// Обработчик CreateProfileCommand
/// </summary>
public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, Profile>
{
    private readonly IProfileWriteRepository _profileWriteRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="profileWriteRepository"></param>
    public CreateProfileCommandHandler(IProfileWriteRepository profileWriteRepository)
    {
        _profileWriteRepository = profileWriteRepository;
    }
    
    /// <summary>
    /// Обработка создания Profile
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданный Profile.</returns>
    public async Task<Profile> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
        var userProfile = new Profile(request.ExternalId, request.Email);
        await _profileWriteRepository.AddAsync(userProfile, cancellationToken);
        return userProfile;
    }
}