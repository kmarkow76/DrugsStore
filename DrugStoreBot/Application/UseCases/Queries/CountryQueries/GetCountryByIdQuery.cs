using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.CountryQueries;
/// <summary>
/// Запрос на получения сущности Country по идентификатору
/// </summary>
public record GetCountryByIdQuery(Guid Id): IRequest<Country?>;
