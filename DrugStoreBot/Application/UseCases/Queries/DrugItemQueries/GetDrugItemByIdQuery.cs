using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugItemQueries;
/// <summary>
/// Получение DrugItem по идентификатору
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record GetDrugItemByIdQuery(Guid Id): IRequest<DrugItem?>, IRequest<Country?>;
