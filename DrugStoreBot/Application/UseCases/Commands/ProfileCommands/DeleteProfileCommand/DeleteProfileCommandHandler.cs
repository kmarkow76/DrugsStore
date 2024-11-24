using Application.Interface.Repositories.IProfileRepositories;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands.DeleteProfileCommand;

/// <summary>
/// Обработчик DeleteProfileCommand
/// </summary>
public class DeleteProfileCommandHandler : IRequestHandler<DeleteProfileCommand>
{
    private readonly IProfileWriteRepository _profileWriteRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="profileWriteRepository">Репозиторий записи profileWriteRepository.</param>
    public DeleteProfileCommandHandler(IProfileWriteRepository profileWriteRepository)
    {
        _profileWriteRepository = profileWriteRepository;
    }
    
    /// <summary>
    /// Обработка удаления Profile
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
    {
        await _profileWriteRepository.DeleteAsync(request.ProfileId, cancellationToken);
    }
}