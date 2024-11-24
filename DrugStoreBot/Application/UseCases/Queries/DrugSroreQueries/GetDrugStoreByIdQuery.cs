using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugSroreQueries;

/// <summary>
/// Получение DrugStore по идентификатору
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record GetDrugStoreByIdQuery(Guid Id) : IRequest<DrugsStore?>;
