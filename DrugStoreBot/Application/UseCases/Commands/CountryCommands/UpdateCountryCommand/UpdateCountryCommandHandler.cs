using Application.Interface.Repositories.CountryRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands.UpdateCountryCommand;

/// <summary>
/// Обработчик команды обновления Country
/// </summary>
public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Country>
{
    private readonly ICountryWriteRepository _countryWriteRepository;
    private readonly ICountryReadRepository _countryReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="countryWriteRepository">Репозиторий записи.</param>
    /// <param name="countryReadRepository">Репозиторий чтения.</param>
    public UpdateCountryCommandHandler(ICountryWriteRepository countryWriteRepository, ICountryReadRepository countryReadRepository)
    {
        _countryWriteRepository = countryWriteRepository;
        _countryReadRepository = countryReadRepository;
    }

    /// <summary>
    /// Обработка команды обновления Country
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный Country.</returns>
    public async Task<Country> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        // Получение текущей сущности из базы данных
        var country = await _countryReadRepository.GetByIdAsync(request.CountryId, cancellationToken);

        // Обновление полей сущности
        country.Update(request.Name, request.Code);

        // Сохранение изменений
        await _countryWriteRepository.UpdateAsync(country, cancellationToken);

        return country;
    }
}