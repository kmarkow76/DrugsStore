using Application.Interface.Repositories.CountryRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands.CreateCountryCommand;

/// <summary>
/// Обработчик команды на создание нового объекта сущности Country
/// </summary>
public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand,Country>
{
    private readonly ICountryWriteRepository _countryWriteRepository;
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="countryWriteRepository">Репозиторий записи CountryWriteRepository.</param>
    public CreateCountryCommandHandler(ICountryWriteRepository countryWriteRepository)
    {
        _countryWriteRepository = countryWriteRepository;

    }
    public async Task<Country> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = new Country(request.Name, request.Code);
        await _countryWriteRepository.AddAsync(country,cancellationToken);
        return country;
    }
}