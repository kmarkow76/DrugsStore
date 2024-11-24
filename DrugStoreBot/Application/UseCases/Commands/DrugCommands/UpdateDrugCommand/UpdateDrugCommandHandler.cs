using Application.Interface.Repositories.CountryRepositories;
using Application.Interface.Repositories.DrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands.UpdateDrugCommand;
/// <summary>
/// Обработчик UpdateDrugCommand
/// </summary>
public class UpdateDrugCommandHandler : IRequestHandler<UpdateDrugCommand, Drug?>
{
    private readonly IDrugWriteRepository _drugWriteRepository;
    private readonly IDrugReadRepository _drugReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugWriteRepository">Репозиторий записи DrugWriteRepository.</param>
    /// <param name="drugReadRepository"></param>
    public UpdateDrugCommandHandler(IDrugWriteRepository drugWriteRepository, IDrugReadRepository drugReadRepository)
    {
        _drugWriteRepository = drugWriteRepository;
        _drugReadRepository = drugReadRepository;
    }
    
    /// <summary>
    /// Обработка обновления Drug
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный Drug.</returns>
    public async Task<Drug?> Handle(UpdateDrugCommand request, CancellationToken cancellationToken)
    {
         var drug = await _drugReadRepository.GetByIdAsync(request.DrugId, cancellationToken);
        
        drug.Update(request.Name, request.Manufacturer, request.CountryCodeId, request.Country);
        
        await _drugWriteRepository.UpdateAsync(drug, cancellationToken);
        
        return drug;
    }
}