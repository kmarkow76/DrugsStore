using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugQueries;
/// <summary>
/// Запрос на получения сущности Drug по идентификатору
/// </summary>
public record GetDrugByIdQuery(Guid Id): IRequest<Drug?>;
