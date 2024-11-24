using Application.Interface.Repositories.DrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugQueries;

/// <summary>
/// Обработчик события GetDrugByIdQuery
/// </summary>
public class GetDrugByIdQueryHandler : IRequestHandler<GetDrugByIdQuery, Drug?>
{
    private readonly IDrugReadRepository _drugReadRepository;
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugReadRepository">Репозиторий чтения DrugReadRepository.</param>
    public GetDrugByIdQueryHandler(IDrugReadRepository drugReadRepository)
    {
        _drugReadRepository = drugReadRepository;
    }
    /// <summary>
    /// Обработка получения Drug по идентификатору
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Drug.</returns>
    public async Task<Drug?> Handle(GetDrugByIdQuery request, CancellationToken cancellationToken)
    {
        var response  = await _drugReadRepository.GetByIdAsync(request.Id,cancellationToken);
       
        return response;
    }
}




