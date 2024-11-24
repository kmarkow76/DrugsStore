using Application.Interface.Repositories.DrugStoreRepositories;
using Application.UseCases.Queries.DrugItemQueries;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugSroreQueries;
/// <summary>
/// Обработчик GetDrugStoreByIdQuery
/// </summary>
public class GetDrugStoreByIdQueryHandler : IRequestHandler<GetDrugStoreByIdQuery,DrugsStore?>
{
    private readonly IDrugStoreReadRepository _drugStoreReadRepository;
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugStoreReadRepository">Репозиторий чтения DrugStoreReadRepository.</param>
    public GetDrugStoreByIdQueryHandler(IDrugStoreReadRepository drugStoreReadRepository)
    {
        _drugStoreReadRepository = drugStoreReadRepository;
    }
    /// <summary>
    /// Обработка получения DrugStore по идентификатору
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>DrugStore.</returns>
    public async Task<DrugsStore?> Handle(GetDrugStoreByIdQuery request, CancellationToken cancellationToken)
    {
        var response  = await _drugStoreReadRepository.GetByIdAsync(request.Id,cancellationToken);
       
        return response;
    }
}