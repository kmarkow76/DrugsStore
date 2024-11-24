using Application.Interface.Repositories.CountryRepositories;
using Application.UseCases.Queries.DrugQueries;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.CountryQueries;
/// <summary>
/// Обработчик события GetCountryByIdQuery
/// </summary>
public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, Country?>
{
    private readonly ICountryReadRepository _countryReadRepository;
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="countryReadRepository">Репозиторий чтения CountryReadRepository.</param>
    public GetCountryByIdQueryHandler(ICountryReadRepository countryReadRepository)
    {
        _countryReadRepository = countryReadRepository;
    }
    /// <summary>
    /// Обработка получения Country по идентификатору
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Country.</returns>
    public async Task<Country?> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        var response  = await _countryReadRepository.GetByIdAsync(request.Id,cancellationToken);
       
        return response;
    }
}