using Application.Interface.Repositories.CountryRepositories;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands.DeleteCountryCommand;

/// <summary>
/// Обработчик DeleteCountryCommand
/// </summary>
public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand>
{
    private readonly ICountryWriteRepository _countryWriteRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="countryWriteRepository">Репозиторий записи CountryWriteRepository.</param>
    public DeleteCountryCommandHandler(
        ICountryWriteRepository countryWriteRepository)
    {
        _countryWriteRepository = countryWriteRepository;
    }
    
    /// <summary>
    /// Обработка удаления Country
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        await _countryWriteRepository.DeleteAsync(request.CountryId, cancellationToken);
    }
}